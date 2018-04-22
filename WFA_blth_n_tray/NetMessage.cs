using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WFA_blth_n_tray
{

    public class MouseOptions
    {
        public MouseButtons button;
        public int delta;
        public int x;
        public int y;
        public int clicks;

        public MouseOptions(MouseButtons Button, int Clicks, int X, int Y, int Delta)
        {
            button = Button;
            clicks = Clicks;
            x = X;
            y = Y;
            delta = Delta;
        }
    }

    public class ControlEvents
    {
        public enum Event
        {
            KeyPressDown,
            KeyPressUp,
            MousePressDown,
            MousePressUp,
            MouseMove
        }
        public Event _event;
        public Keys keyEvent;
        public MouseOptions mouseEvent;
    }

    public class AddMeData
    {
        public string ipAddress;
        public string port;
    }

    public class NetMessage
    {
        public enum Type
        {
            Add_Me_Request,
            Control_Request,
            Response,
            Close,
            None
        };

        public enum Response
        {
            OK,
            FAIL
        };

        public Type typeRequest = Type.None;
        public ControlEvents ctrlEv = null;
        public AddMeData addMeData = null;
        public Response response = Response.OK;
        public string textClippboard = null;

        static public string ToJson(NetMessage msg)
        {
            return JsonConvert.SerializeObject(msg);
        }

        static public NetMessage FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<NetMessage>(json);
            }
            catch (Newtonsoft.Json.JsonException)
            {
                NetMessage stub = new NetMessage();
                stub.typeRequest = Type.None;
                return stub;
            }
        }
    }
}
