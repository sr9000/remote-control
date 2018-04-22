using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WFA_blth_n_tray
{
    class Listener
    {
        private volatile bool doWork = true;
        private volatile SemaphoreSlim finalSignal = null;
        private volatile TcpListener _listener = null;
        private Func<NetMessage, TcpClient, bool> _proc = null;
        private volatile TcpClient _remoute = null;

        public Listener(IPAddress address, Func<NetMessage, TcpClient, bool> proc)
        {
            _listener = new TcpListener(new IPEndPoint(address, 0));
            _proc = proc;
        }

        public void StartListener()
        {
            var started = new SemaphoreSlim(0, 1);
            Thread thread = new Thread(new ThreadStart(() =>
            {
                finalSignal = new SemaphoreSlim(0, 1);
                _listener.Start();
                started.Release();
                IAsyncResult result = null;
                while (doWork)
                {
                    if (result == null)
                    {
                        result = _listener.BeginAcceptTcpClient(new AsyncCallback(x => { }), null);
                    }
                    if (result.IsCompleted)
                    {
                        _remoute = _listener.EndAcceptTcpClient(result);
                        processClient(_remoute);
                        _remoute = null;
                        result = null;
                    }
                    Thread.Sleep(1);
                }
                if (result != null)
                {
                    result.AsyncWaitHandle.Close();
                }
                _listener.Stop();
                finalSignal.Release();
            }));
            thread.Start();
            started.Wait();
            started.Release();
        }

        public void StopListener()
        {
            if (finalSignal != null)
            {
                doWork = false;
                finalSignal.Wait();
                finalSignal.Release();
                finalSignal = null;
            }
        }

        private void processClient(TcpClient client)
        {
            Task<string> result = null;
            CancellationTokenSource cts = null;
            int emptySteps = 0;
            int emptyStepsTrashold = 1000;
            while (doWork)
            {
                if (result == null)
                {
                    cts = new CancellationTokenSource();
                    result = NetFunctions.ReadString(client.GetStream(), cts);
                }
                if (result.IsCompleted)
                {
                    if (result.Result != null)
                    {
                        emptySteps = 0;
                        bool finish = !_proc(NetMessage.FromJson(result.Result), client);
                        result = null;
                        if (finish)
                            break;
                    }
                    result = null;
                }
                emptySteps += 1;
                Thread.Sleep(0);
                if (emptySteps > emptyStepsTrashold)
                {
                    emptySteps = 0;
                    Thread.Sleep(1);
                }
            }
            if (result != null)
            {
                cts.Cancel(false);
            }
            client.Close();
        }

        public IPEndPoint GetIPEndPoint()
        {
            return this._listener.LocalEndpoint as IPEndPoint;
        }

        public IPEndPoint GetRemouteIPEndPoint()
        {
            if (_remoute != null)
            {
                return _remoute.Client.RemoteEndPoint as IPEndPoint;
            }
            return null;
        }

        public override string ToString()
        {
            return this._listener.Server.LocalEndPoint.ToString();
        }

        ~Listener()
        {
            this.StopListener();
        }
    }
}
