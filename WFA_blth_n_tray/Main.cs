using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectabeDevices;
using System.Net.NetworkInformation;
using System.Net;
using gma.System.Windows;
using WindowsInput;
using System.Threading;
using System.Diagnostics;

namespace WFA_blth_n_tray
{
    public partial class MainForm : Form
    {

        public class HotKeyCommands
        {
            public SortedSet<Keys> breakControl = new SortedSet<Keys>();

            public SortedSet<Keys> nextPC = new SortedSet<Keys>();
            public SortedSet<Keys> previousPC = new SortedSet<Keys>();

            public SortedSet<Keys> _1PC = new SortedSet<Keys>();
            public SortedSet<Keys> _2PC = new SortedSet<Keys>();
            public SortedSet<Keys> _3PC = new SortedSet<Keys>();
            public SortedSet<Keys> _4PC = new SortedSet<Keys>();
            public SortedSet<Keys> _5PC = new SortedSet<Keys>();

            public void Assign(HotKeyCommands other)
            {
                this._1PC = new SortedSet<Keys>(other._1PC);
                this._2PC = new SortedSet<Keys>(other._2PC);
                this._3PC = new SortedSet<Keys>(other._3PC);
                this._4PC = new SortedSet<Keys>(other._4PC);
                this._5PC = new SortedSet<Keys>(other._5PC);

                this.breakControl = new SortedSet<Keys>(other.breakControl);

                this.nextPC = new SortedSet<Keys>(other.nextPC);
                this.previousPC = new SortedSet<Keys>(other.previousPC);
            }

            public static bool pressedContainsCombo(SortedSet<Keys> pressed, SortedSet<Keys> combo)
            {
                return combo.All(key => pressed.Contains(key));
            }

            public void ClearAll()
            {
                breakControl.Clear();

                nextPC.Clear();
                previousPC.Clear();

                _1PC.Clear();
                _2PC.Clear();
                _3PC.Clear();
                _4PC.Clear();
                _5PC.Clear();
            }
        }

        public class PCsetings
        {
            public IPEndPoint remoute = null;
            public IPAddress localIP = null;
        }

        volatile private HotKeyCommands hotKeyCommands = new HotKeyCommands();
        private HotKeyForm hotKeyForm = null;

        private bool catchHotKeys = false;
        private bool isFirstSendedMessage = true;

        private Boolean closeAnyway = false;
        private Boolean allowClickNotifyIcon = true;
        private ConnectableInterfaces interfaces;
        private List<Listener> myListeners = new List<Listener>();
        private List<PCsetings> myPCs = new List<PCsetings>();
        private UserActivityHook hook = null;
        private Client rulerClient = new Client();
        private bool notifyAboutRemouteControlling = false;
        private volatile InputSimulator inputSim = null;
        private volatile Stopwatch stopwatch = new Stopwatch();
        private volatile bool weAreControl = false;

        public SortedSet<Keys> pressedKeys = new SortedSet<Keys>();

        private void ClearPressedKeysSet()
        {
            pressedKeys.Clear();
        }

        private void ControlPC()
        {
            if (rulerClient.numberOfPc.HasValue)
            {
                //all OK
            }
            else
            {
                if (MyComputersListBox.SelectedItem != null)
                {
                    rulerClient.numberOfPc = MyComputersListBox.SelectedIndex;
                }
                else
                {
                    MessageBox.Show("Please, select PC for remoute controlling!");
                }
            }

            if (rulerClient.numberOfPc.HasValue)
            {
                lock (MyComputersListBox)
                {
                    if (rulerClient.numberOfPc.Value < MyComputersListBox.Items.Count)
                    {
                        ClearPressedKeysSet();
                        var info = myPCs[rulerClient.numberOfPc.Value];
                        rulerClient.OpenConnection(info.localIP, info.remoute, notifyIcon);
                        weAreControl = true;
                        isFirstSendedMessage = true;
                    }
                    else
                    {
                        rulerClient.numberOfPc = null;
                        MessageBox.Show("Please, select PC for remoute controlling!");
                    }
                }
            }
        }

        private void catchHotKeysMethod()
        {
            if (catchHotKeys)
            {
                this.hotKeyForm.updateKeys(pressedKeys);
            }
            else
            {
                this.hotKeyForm.finishKeys(pressedKeys);
                pressedKeys.Clear();
            }
        }

        private void hotKeyComboChecker()
        {
            //hotKeyCombos
            if ((!controledByPanel.Visible) && hotKeyForm == null)
            {
                if (HotKeyCommands.pressedContainsCombo(pressedKeys, hotKeyCommands.breakControl))
                {
                    breakControl();

                    notifyIcon.BalloonTipTitle = "Break remoute control.";
                    notifyIcon.BalloonTipText = "Now you control your own computer.";
                    notifyIcon.ShowBalloonTip(3000);
                }

                if (HotKeyCommands.pressedContainsCombo(pressedKeys, hotKeyCommands.nextPC))
                {
                    nextPC();
                }

                if (HotKeyCommands.pressedContainsCombo(pressedKeys, hotKeyCommands.previousPC))
                {
                    prevuiousPC();
                }

                if (HotKeyCommands.pressedContainsCombo(pressedKeys, hotKeyCommands._1PC))
                {
                    _1PC();
                }
                if (HotKeyCommands.pressedContainsCombo(pressedKeys, hotKeyCommands._2PC))
                {
                    _2PC();
                }
                if (HotKeyCommands.pressedContainsCombo(pressedKeys, hotKeyCommands._3PC))
                {
                    _3PC();
                }
                if (HotKeyCommands.pressedContainsCombo(pressedKeys, hotKeyCommands._4PC))
                {
                    _4PC();
                }
                if (HotKeyCommands.pressedContainsCombo(pressedKeys, hotKeyCommands._5PC))
                {
                    _5PC();
                }
            }
        }

        private void _5PC()
        {
            //throw new NotImplementedException();
            foreach (var item in this.hotKeyCommands._5PC)
            {
                NetMessage msg = new NetMessage();
                msg.typeRequest = NetMessage.Type.Control_Request;
                msg.ctrlEv = new ControlEvents();
                msg.ctrlEv._event = ControlEvents.Event.KeyPressUp;
                msg.ctrlEv.keyEvent = item;
                rulerClient.SendNetMessage(NetMessage.ToJson(msg));
            }
            Thread.Sleep(500);
            breakControl();
            rulerClient.numberOfPc = 4;
            ControlPC();
        }

        private void _4PC()
        {
            //throw new NotImplementedException();
            foreach (var item in this.hotKeyCommands._4PC)
            {
                NetMessage msg = new NetMessage();
                msg.typeRequest = NetMessage.Type.Control_Request;
                msg.ctrlEv = new ControlEvents();
                msg.ctrlEv._event = ControlEvents.Event.KeyPressUp;
                msg.ctrlEv.keyEvent = item;
                rulerClient.SendNetMessage(NetMessage.ToJson(msg));
            }
            Thread.Sleep(500);
            breakControl();
            rulerClient.numberOfPc = 3;
            ControlPC();
        }

        private void _3PC()
        {
            //throw new NotImplementedException();
            foreach (var item in this.hotKeyCommands._3PC)
            {
                NetMessage msg = new NetMessage();
                msg.typeRequest = NetMessage.Type.Control_Request;
                msg.ctrlEv = new ControlEvents();
                msg.ctrlEv._event = ControlEvents.Event.KeyPressUp;
                msg.ctrlEv.keyEvent = item;
                rulerClient.SendNetMessage(NetMessage.ToJson(msg));
            }
            Thread.Sleep(500);
            breakControl();
            rulerClient.numberOfPc = 2;
            ControlPC();
        }

        private void _2PC()
        {
            //throw new NotImplementedException();
            foreach (var item in this.hotKeyCommands._2PC)
            {
                NetMessage msg = new NetMessage();
                msg.typeRequest = NetMessage.Type.Control_Request;
                msg.ctrlEv = new ControlEvents();
                msg.ctrlEv._event = ControlEvents.Event.KeyPressUp;
                msg.ctrlEv.keyEvent = item;
                rulerClient.SendNetMessage(NetMessage.ToJson(msg));
            }
            Thread.Sleep(500);
            breakControl();
            rulerClient.numberOfPc = 1;
            ControlPC();
        }

        private void _1PC()
        {
            //throw new NotImplementedException();
            foreach (var item in this.hotKeyCommands._1PC)
            {
                NetMessage msg = new NetMessage();
                msg.typeRequest = NetMessage.Type.Control_Request;
                msg.ctrlEv = new ControlEvents();
                msg.ctrlEv._event = ControlEvents.Event.KeyPressUp;
                msg.ctrlEv.keyEvent = item;
                rulerClient.SendNetMessage(NetMessage.ToJson(msg));
            }
            Thread.Sleep(500);
            breakControl();
            rulerClient.numberOfPc = 0;
            ControlPC();
        }

        private void prevuiousPC()
        {
            //throw new NotImplementedException();
            foreach (var item in this.hotKeyCommands.previousPC)
            {
                NetMessage msg = new NetMessage();
                msg.typeRequest = NetMessage.Type.Control_Request;
                msg.ctrlEv = new ControlEvents();
                msg.ctrlEv._event = ControlEvents.Event.KeyPressUp;
                msg.ctrlEv.keyEvent = item;
                rulerClient.SendNetMessage(NetMessage.ToJson(msg));
            }
            Thread.Sleep(500);
            breakControl();
            if (rulerClient.numberOfPc.HasValue)
            {
                rulerClient.numberOfPc = (rulerClient.numberOfPc.Value + MyComputersListBox.Items.Count - 1) % MyComputersListBox.Items.Count;
            }
            ControlPC();
        }

        private void nextPC()
        {
            //throw new NotImplementedException();
            foreach (var item in this.hotKeyCommands.nextPC)
            {
                NetMessage msg = new NetMessage();
                msg.typeRequest = NetMessage.Type.Control_Request;
                msg.ctrlEv = new ControlEvents();
                msg.ctrlEv._event = ControlEvents.Event.KeyPressUp;
                msg.ctrlEv.keyEvent = item;
                rulerClient.SendNetMessage(NetMessage.ToJson(msg));
            }
            Thread.Sleep(500);
            breakControl();
            if (rulerClient.numberOfPc.HasValue)
            {
                rulerClient.numberOfPc = (rulerClient.numberOfPc.Value + 1) % MyComputersListBox.Items.Count;
            }
            ControlPC();
        }

        private void breakControl()
        {
            //throw new NotImplementedException();
            weAreControl = false;
            foreach (var item in this.hotKeyCommands.breakControl)
            {
                NetMessage msg = new NetMessage();
                msg.typeRequest = NetMessage.Type.Control_Request;
                msg.ctrlEv = new ControlEvents();
                msg.ctrlEv._event = ControlEvents.Event.KeyPressUp;
                msg.ctrlEv.keyEvent = item;
                rulerClient.SendNetMessage(NetMessage.ToJson(msg));
            }
            Thread.Sleep(500);
            rulerClient.CloseConnection();
        }



        //private KeyboardHook kbHk;
       private void CloseMethod()
        {
            foreach (var item in myListeners)
            {
                item.StopListener();
            }
            closeAnyway = true;
            this.Close();
        }

        private void NotifyIconMouseClick()
        {
            allowClickNotifyIcon = false;
            this.notifyMouseClickTimer.Start();
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void hi1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMethod();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            CloseMethod();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            notifyMouseClickTimer.Interval = SystemInformation.DoubleClickTime + 1;
            interfaces = null;
            //hook
            hook = new UserActivityHook();
            hook.KeyDown += hook_KeyDown;
            hook.KeyPress += hook_KeyPress;
            hook.KeyUp += hook_KeyUp;
            hook.OnMouseActivity += hook_OnMouseActivity;
            hook.OnMouseDown += hook_OnMouseDown;
            hook.OnMouseUp += hook_OnMouseUp;
            //hotkeys
            ResetHotKeys(hotKeyCommands);
            //balloon tip
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            //input simulator
            inputSim = new InputSimulator();
        }

        public static void ResetHotKeys(HotKeyCommands hkc)
        {
            hkc.ClearAll();

            hkc.breakControl.Add(Keys.LControlKey);
            hkc.breakControl.Add(Keys.Oemtilde);

            hkc.nextPC.Add(Keys.LShiftKey);
            hkc.nextPC.Add(Keys.PageDown);

            hkc.previousPC.Add(Keys.LShiftKey);
            hkc.previousPC.Add(Keys.PageUp);

            hkc._1PC.Add(Keys.LControlKey);
            hkc._2PC.Add(Keys.LControlKey);
            hkc._3PC.Add(Keys.LControlKey);
            hkc._4PC.Add(Keys.LControlKey);
            hkc._5PC.Add(Keys.LControlKey);

            hkc._1PC.Add(Keys.D1);
            hkc._2PC.Add(Keys.D2);
            hkc._3PC.Add(Keys.D3);
            hkc._4PC.Add(Keys.D4);
            hkc._5PC.Add(Keys.D5);
        }

        public static string GetAnyClippBoardText()
        {
            string formats = "";
            foreach (var item in Clipboard.GetDataObject().GetFormats(true))
            {
                if (!string.IsNullOrEmpty(item))
                    formats += ";" + item;
            }
            //new Action(() => MessageBox.Show(formats)).BeginInvoke(null, null);
            if (Clipboard.ContainsData(System.Windows.Forms.DataFormats.CommaSeparatedValue)
                || Clipboard.ContainsData(System.Windows.Forms.DataFormats.Html)
                || Clipboard.ContainsData(System.Windows.Forms.DataFormats.OemText)
                || Clipboard.ContainsData(System.Windows.Forms.DataFormats.Rtf)
                || Clipboard.ContainsData(System.Windows.Forms.DataFormats.StringFormat)
                || Clipboard.ContainsData(System.Windows.Forms.DataFormats.Text)
                || Clipboard.ContainsData(System.Windows.Forms.DataFormats.UnicodeText))
            {
                return Clipboard.GetDataObject().GetData(System.Windows.Forms.DataFormats.UnicodeText, true) as string;
            }
            return null;
        }

        void addClippboardText(NetMessage msg)
        {
            if (isFirstSendedMessage)
            {
                //MessageBox.Show("FM");
                //new Action(() => MessageBox.Show("FM")).BeginInvoke(null, null);
                isFirstSendedMessage = false;
                string text = GetAnyClippBoardText();
                if (!string.IsNullOrEmpty(text))
                {
                    ///MessageBox.Show("Added text");
                    //new Action(() => MessageBox.Show("Added text")).BeginInvoke(null, null);
                    msg.textClippboard = text;
                }
            }
        }

        void hook_OnMouseUp(object sender, HandledMouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (weAreControl && rulerClient.IsActive())
            {
                NetMessage msg = new NetMessage();
                msg.typeRequest = NetMessage.Type.Control_Request;
                msg.ctrlEv = new ControlEvents();
                msg.ctrlEv._event = ControlEvents.Event.MousePressUp;
                msg.ctrlEv.mouseEvent = new MouseOptions(e.Button, e.Clicks, e.X, e.Y, e.Delta);
                addClippboardText(msg);
                rulerClient.SendNetMessage(NetMessage.ToJson(msg));
            }
            if (weAreControl)
                e.Handled = true;
        }

        void hook_OnMouseDown(object sender, HandledMouseEventArgs e)
        {
            //throw new NotImplementedException();
            
            if (weAreControl && rulerClient.IsActive())
            {
                NetMessage msg = new NetMessage();
                msg.typeRequest = NetMessage.Type.Control_Request;
                msg.ctrlEv = new ControlEvents();
                msg.ctrlEv._event = ControlEvents.Event.MousePressDown;
                msg.ctrlEv.mouseEvent = new MouseOptions(e.Button, e.Clicks, e.X, e.Y, e.Delta);
                addClippboardText(msg);
                rulerClient.SendNetMessage(NetMessage.ToJson(msg));
            }
            if (weAreControl)
                e.Handled = true;
        }

        void hook_OnMouseActivity(object sender, HandledMouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (weAreControl && rulerClient.IsActive())
            {
                int w = Screen.PrimaryScreen.Bounds.Width / 2;
                int h = Screen.PrimaryScreen.Bounds.Height / 2;
                NetMessage msg = new NetMessage();
                msg.typeRequest = NetMessage.Type.Control_Request;
                msg.ctrlEv = new ControlEvents();
                msg.ctrlEv._event = ControlEvents.Event.MouseMove;
                msg.ctrlEv.mouseEvent = new MouseOptions(e.Button, e.Clicks, e.X - w, e.Y - h, e.Delta);
                addClippboardText(msg);
                rulerClient.SendNetMessage(NetMessage.ToJson(msg));
                Cursor.Position = new Point(w, h);
            }
            if (weAreControl)
                e.Handled = true;
        }

        void hook_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode);
            if (catchHotKeys)
            {
                catchHotKeys = false;
                this.catchHotKeysMethod();
                catchHotKeys = true;
            }
            if (weAreControl && rulerClient.IsActive())
            {
                NetMessage msg = new NetMessage();
                msg.typeRequest = NetMessage.Type.Control_Request;
                msg.ctrlEv = new ControlEvents();
                msg.ctrlEv._event = ControlEvents.Event.KeyPressUp;
                msg.ctrlEv.keyEvent = e.KeyCode;
                addClippboardText(msg);
                rulerClient.SendNetMessage(NetMessage.ToJson(msg));
            }
            if (weAreControl)
                e.Handled = true;
            //throw new NotImplementedException();
        }

        void hook_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            if (weAreControl && rulerClient.IsActive())
            {
                e.Handled = true;
            }
        }

        void hook_KeyDown(object sender, KeyEventArgs e)
        {
            //press Key
            pressedKeys.Add(e.KeyCode);

            //hotKeys
            if (catchHotKeys)
            {
                //rewritingCombos
                this.catchHotKeysMethod();
            }
            else
            {
                //check combos
                hotKeyComboChecker();
            }

            //remoute
            if (weAreControl && rulerClient.IsActive())
            {
                NetMessage msg = new NetMessage();
                msg.typeRequest = NetMessage.Type.Control_Request;
                msg.ctrlEv = new ControlEvents();
                msg.ctrlEv._event = ControlEvents.Event.KeyPressDown;
                msg.ctrlEv.keyEvent = e.KeyCode;
                addClippboardText(msg);
                rulerClient.SendNetMessage(NetMessage.ToJson(msg));
            }
            if (weAreControl)
                e.Handled = true;
            //throw new NotImplementedException();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeAnyway)
            {
                hook.Stop();
                notifyIcon.Visible = false;
            }
            else
            {
                e.Cancel = true;
            }
            
            this.Hide();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (allowClickNotifyIcon)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (this.Visible)
                    {
                        this.Close();
                    }
                    else 
                    {
                        this.Show();
                        this.Focus();
                    }
                    NotifyIconMouseClick();
                }
            }
        }

        private void notifyMouseClickTimer_Tick(object sender, EventArgs e)
        {
            allowClickNotifyIcon = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void RefreshDvLstButton_Click(object sender, EventArgs e)
        {
            //clear device list
            this.DvListBox.Items.Clear();
            //show progress bar
            this.FindDvProgressBar.Show();
            //clear text box
            this.DetailsDvTextBox.Text = "";
            //doWork
            FindDvBackgroundWorker.RunWorkerAsync();
        }

        private void FindDvBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            (sender as BackgroundWorker).ReportProgress(0);
            
            //do work
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(10);
            if (this.AllNtDvRadioButton.Checked)
            {
                //find net interfaces
                interfaces = new ConnectableInterfaces(ConnectableInterfaces.Mode.Network);
                worker.ReportProgress(20);
                interfaces.SetDevices(StaticDvFinder.nt());
            }
            else
            {
                //async work
                interfaces = new ConnectableInterfaces(ConnectableInterfaces.Mode.Bluetooth);
                worker.ReportProgress(20);
                interfaces.SetDevices(StaticDvFinder.blth());
            }
            worker.ReportProgress(100);
        }

        private void FindDvBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.FindDvProgressBar.Value = e.ProgressPercentage;
        }

        private void FindDvBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int i = 0; i < interfaces.GetDeviceCount(); i++)
            {
                this.DvListBox.Items.Add(interfaces.GetDeviceName(i));
            }
            this.FindDvProgressBar.Hide();
        }

        private void DvListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DvListBox.SelectedItem != null)
            {
                this.DetailsDvTextBox.Text = interfaces.GetDeviceInfo(this.DvListBox.SelectedIndex);
            }
        }

        private static void SafeInvoke(Form frm, Action action)
        {
            if (frm.InvokeRequired)
            {
                frm.Invoke(new Action(() =>
                {
                    action.Invoke();
                }));
            }
            else
            {
                action.Invoke();
            }
        }

        private bool addMeRequest(NetMessage msg, Listener listener)
        {
            lock (MyComputersListBox)
            {
                IPEndPoint newPC = new IPEndPoint(IPAddress.Parse(msg.addMeData.ipAddress), int.Parse(msg.addMeData.port));
                var pcSettings = new PCsetings();
                pcSettings.remoute = newPC;
                pcSettings.localIP = listener.GetIPEndPoint().Address;
                myPCs.Add(pcSettings);
                SafeInvoke(this, new Action(() =>
                {
                    this.MyComputersListBox.Items.Add(newPC.ToString());
                }));
                return false;
            }
        }

        private bool controlRequest(NetMessage msg, IPEndPoint remoute)
        {
            if (!notifyAboutRemouteControlling)
            {
                notifyAboutRemouteControlling = true;
                SafeInvoke(this, new Action(() =>
                {
                    //notyfy about remoute controll
                    controledByPanel.Visible = true;
                    controledByTextBox.Text = remoute.ToString();
                    notifyIcon.BalloonTipTitle = "Controlling by";
                    notifyIcon.BalloonTipText = remoute.ToString();
                    notifyIcon.ShowBalloonTip(3000);

                    //MessageBox.Show("first control request");
                    //new Action(() => MessageBox.Show("first control request")).BeginInvoke(null, null);
                    //fill clippboard
                    if (!string.IsNullOrEmpty(msg.textClippboard))
                    {
                        //new Action(()=> MessageBox.Show("text not empty")).BeginInvoke(null, null);
                        Clipboard.SetText(msg.textClippboard);
                    }
                }));
            }
            switch (msg.ctrlEv._event)
            {
                case ControlEvents.Event.KeyPressDown:
                    simKeyPressDown(msg);
                    break;
                case ControlEvents.Event.KeyPressUp:
                    simKeyPressUp(msg);
                    break;
                case ControlEvents.Event.MousePressDown:
                    simMousePressDown(msg);
                    break;
                case ControlEvents.Event.MousePressUp:
                    simMousePressUp(msg);
                    break;
                case ControlEvents.Event.MouseMove:
                    simMouseMove(msg);
                    break;
                default:
                    break;
            }
            return true;
        }

        public volatile int freeIncrement = 0;

        private void simMouseMove(NetMessage msg)
        {
            //throw new NotImplementedException();
            inputSim.Mouse.MoveMouseBy(msg.ctrlEv.mouseEvent.x, msg.ctrlEv.mouseEvent.y);
            /*Cursor.Position = new Point(Cursor.Position.X + msg.ctrlEv.mouseEvent.x,
                Cursor.Position.Y + msg.ctrlEv.mouseEvent.y);*/
            inputSim.Mouse.VerticalScroll(Math.Sign(msg.ctrlEv.mouseEvent.delta) * 2);
            stopwatch.Reset();
            stopwatch.Start();
            while(stopwatch.ElapsedTicks < (Stopwatch.Frequency / this.numericUpDown1.Value))
            { }
            stopwatch.Stop();
            
        }

        private void simMousePressUp(NetMessage msg)
        {
            //throw new NotImplementedException();
            switch (msg.ctrlEv.mouseEvent.button)
            {
                case MouseButtons.Left:
                    inputSim.Mouse.LeftButtonUp();
                    break;
                case MouseButtons.Middle:
                    //noone middle button
                    break;
                case MouseButtons.None:
                    //empty
                    break;
                case MouseButtons.Right:
                    inputSim.Mouse.RightButtonUp();
                    break;
                case MouseButtons.XButton1:
                    inputSim.Mouse.XButtonUp(0);
                    break;
                case MouseButtons.XButton2:
                    inputSim.Mouse.XButtonUp(1);
                    break;
                default:
                    break;
            }
        }

        private void simMousePressDown(NetMessage msg)
        {
            //throw new NotImplementedException();
            switch (msg.ctrlEv.mouseEvent.button)
            {
                case MouseButtons.Left:
                    inputSim.Mouse.LeftButtonDown();
                    break;
                case MouseButtons.Middle:
                    //noone middle button
                    break;
                case MouseButtons.None:
                    //empty
                    break;
                case MouseButtons.Right:
                    inputSim.Mouse.RightButtonDown();
                    break;
                case MouseButtons.XButton1:
                    inputSim.Mouse.XButtonDown(0);
                    break;
                case MouseButtons.XButton2:
                    inputSim.Mouse.XButtonDown(1);
                    break;
                default:
                    break;
            }
        }

        private static WindowsInput.Native.VirtualKeyCode convertKey(Keys key)
        {
            WindowsInput.Native.VirtualKeyCode ret = (WindowsInput.Native.VirtualKeyCode)((int)key);
            return ret;
        }

        private void simKeyPressUp(NetMessage msg)
        {
            //throw new NotImplementedException();
            inputSim.Keyboard.KeyUp(convertKey(msg.ctrlEv.keyEvent));
        }

        private void simKeyPressDown(NetMessage msg)
        {
            //throw new NotImplementedException();
            inputSim.Keyboard.KeyDown(convertKey(msg.ctrlEv.keyEvent));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DvListBox.SelectedItem != null)
            {
                var ip = this.interfaces.GetIPAdressString(DvListBox.SelectedIndex);
                Listener lstnr = null;
                lstnr = new Listener(IPAddress.Parse(ip), (net, client) =>
                 {
                     if (net.typeRequest == NetMessage.Type.Add_Me_Request)
                     {
                         return addMeRequest(net, lstnr);
                     }
                     if (net.typeRequest == NetMessage.Type.Control_Request)
                     {
                         return controlRequest(net, lstnr.GetRemouteIPEndPoint());
                     }
                     if (net.typeRequest == NetMessage.Type.None)
                     {
                         return true;
                     }
                     if (net.typeRequest == NetMessage.Type.Close)
                     {
                         NetMessage msg = new NetMessage();
//                         MessageBox.Show("Recv Closse msg");
                         //new Action(() => MessageBox.Show("Recv Closse msg")).BeginInvoke(null, null);
                         string text = null;
                         SafeInvoke(this, new Action(() =>
                         {
                             text = GetAnyClippBoardText();
                         }));
                         if (!string.IsNullOrEmpty(text))
                         {
                             //MessageBox.Show("Add text");
                             //new Action(() => MessageBox.Show("Add text")).BeginInvoke(null, null);
                             msg.textClippboard = text;
                         }
                         else
                         {
                             //MessageBox.Show("add empty");
                             //new Action(() => MessageBox.Show("add empty")).BeginInvoke(null, null);
                             msg.textClippboard = string.Empty;
                         }
                         string strmsg = NetMessage.ToJson(msg);
                         //MessageBox.Show("Send : " + strmsg);
                         //new Action(() => MessageBox.Show("Send : " + strmsg)).BeginInvoke(null, null);
                         for (int i = 0; i < 5; ++i) //send 5 times for more safety
                         {
                             NetFunctions.WriteString(client.GetStream(), strmsg);
                         }
                         //MessageBox.Show("Invoke");
                         //new Action(() => MessageBox.Show("Invoke")).BeginInvoke(null, null);
                         SafeInvoke(this, new Action(() =>
                         {
                             notifyAboutRemouteControlling = false;
                             controledByPanel.Visible = false;
                         }));
                         return false;
                     }
                     return false;
                 });
                lstnr.StartListener();
                myListeners.Add(lstnr);
                connectPointsListBox.Items.Add(lstnr.ToString());
            }
            else
            {
                MessageBox.Show("Please, select any device!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connectPointsListBox.SelectedItem != null)
            {
                myListeners[connectPointsListBox.SelectedIndex].StopListener();
                myListeners.RemoveAt(connectPointsListBox.SelectedIndex);
                connectPointsListBox.Items.RemoveAt(connectPointsListBox.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please, select any connect point!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IPAddress addr = null;
            int port = 0;
            var filter = IPAddressMaskedTextBox.Text.Where(s => s != IPAddressMaskedTextBox.PromptChar);
            var finIP = string.Concat(filter);
            var absoluteFinIP = finIP.Split('.').Select(s => s.TrimStart('0')).Select(s => {
                if (string.IsNullOrWhiteSpace(s))
                    return "0";
                return s;
            });
            var absoluteFinIPString = string.Join(".", absoluteFinIP);
            bool f = IPAddress.TryParse(absoluteFinIPString, out addr);
            f = f && int.TryParse(string.Concat(PortMaskedTextBox.Text.Where(s => s != PortMaskedTextBox.PromptChar)), out port);
            f = f && (this.connectPointsListBox.SelectedItem != null);
            //f = f && (this.DvListBox.SelectedItem != null);
            if (f)
            {
                IPEndPoint myEndPoint = myListeners[connectPointsListBox.SelectedIndex].GetIPEndPoint();
                Client.AddRequest(myEndPoint.Address, new IPEndPoint(addr, port), myEndPoint);
            }
            else
            {
                MessageBox.Show("You should write IP address and port of server and select listener.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MyComputersListBox.SelectedItem == null)
            {
                MessageBox.Show("Please, select any PC in \"" + ServerLabel.Text + "\"");
                return;
            }
            lock (MyComputersListBox)
            {
                int ind = MyComputersListBox.SelectedIndex;
                myPCs.RemoveAt(ind);
                MyComputersListBox.Items.RemoveAt(ind);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.pressedKeys.Clear();
            catchHotKeys = true;
            hotKeyForm = new HotKeyForm();
            hotKeyForm.actualHotKeyCommads = hotKeyCommands;
            hotKeyForm.ShowDialog(this);
            this.hotKeyForm = null;
            catchHotKeys = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ControlPC();
        }

        private void notifyMessageTimer_Tick(object sender, EventArgs e)
        {
        }
    }
}
