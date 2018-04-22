using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_blth_n_tray
{
    class Client
    {
        private volatile TcpClient ruler = null;
        public volatile IAsyncResult resultOfConnection = null;

        public int? numberOfPc = null;

        public static void AddRequest(IPAddress intefaceIpAddress, IPEndPoint serverPoint, IPEndPoint myConnectPoint)
        {
            TcpClient client = new TcpClient(new IPEndPoint(intefaceIpAddress, 0));
            NetMessage msg = new NetMessage();
            msg.typeRequest = NetMessage.Type.Add_Me_Request;
            msg.addMeData = new AddMeData();
            msg.addMeData.ipAddress = myConnectPoint.Address.ToString();
            msg.addMeData.port = myConnectPoint.Port.ToString();
            client.Connect(serverPoint);
            NetFunctions.WriteString(client.GetStream(), NetMessage.ToJson(msg));
            client.Close();
        }

        public void OpenConnection(IPAddress localAddress, IPEndPoint remoutePoint, NotifyIcon ntfIcon)
        {
            if (ruler == null)
            {
                ruler = new TcpClient(new IPEndPoint(localAddress, 0));
                resultOfConnection = ruler.BeginConnect(remoutePoint.Address, remoutePoint.Port,
                    new AsyncCallback(r =>
                        {
                            ntfIcon.BalloonTipTitle = "You have remoute control.";
                            ntfIcon.BalloonTipText = remoutePoint.ToString();
                            ntfIcon.ShowBalloonTip(3000);
                        })
                    , null);
            }
        }

        public void SendNetMessage(string msgJSON)
        {
            new Task(() =>
            {
                if (ruler == null)
                    return;
                lock (ruler)
                {
                    if (resultOfConnection.IsCompleted && ruler != null)
                    {
                        NetFunctions.WriteString(ruler.GetStream(), msgJSON);
                    }
                }
            }).Start();
        }

        public bool IsActive()
        {
            if (resultOfConnection == null)
                return false;
            return resultOfConnection.IsCompleted && ruler != null;
        }

        public void CloseConnection()
        {
            if (ruler != null)
            {
                if (!resultOfConnection.IsCompleted)
                {
                    resultOfConnection.AsyncWaitHandle.Close();
                }
                else
                {
                    //send close request
                    NetMessage closeMsg = new NetMessage();
                    closeMsg.typeRequest = NetMessage.Type.Close;
                    NetFunctions.WriteString(ruler.GetStream(), NetMessage.ToJson(closeMsg));

                    //read remoute clippboard data
//                    MessageBox.Show("read clippboard text");
                    //new Action(() => MessageBox.Show("read clippboard text")).BeginInvoke(null, null);
                    System.Threading.CancellationTokenSource cts = new System.Threading.CancellationTokenSource();
                    var task = NetFunctions.ReadString(ruler.GetStream(), cts);
                    if (task.Wait(10000)) //magic ten seconds
                    {
                        //MessageBox.Show("msg readed");
                        //new Action(() => MessageBox.Show("msg readed : " + task.Result)).BeginInvoke(null, null);
                        //set new clippboard
                        var msg = NetMessage.FromJson(task.Result);
                        if (!string.IsNullOrEmpty(msg.textClippboard))
                        {
                            //MessageBox.Show("clippboard not empty : " + msg.TextClippboard);
                            //new Action(() => MessageBox.Show("clippboard not empty : " + msg.textClippboard)).BeginInvoke(null, null);
                            Clipboard.SetText(msg.textClippboard);
                        }
                    }
                }
                    
                resultOfConnection = null;
                ruler.Close();
                ruler = null;
            }
        }
    }
}
