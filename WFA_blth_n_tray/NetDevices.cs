using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Reflection;
using InTheHand.Net;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;

namespace WFA_blth_n_tray
{
    class ConnectableInterfaces
    {

        private IEnumerable<BluetoothRadio> _blthDv;
        private IEnumerable<NetworkInterface> _ntwkDv;

        public enum Mode
        {
            Bluetooth,
            Network
        };
         
        private Mode _mode;

        public ConnectableInterfaces(Mode mode = Mode.Bluetooth)
        {
            _mode = mode;
        }

        private void SetNetworkDevices(IEnumerable<NetworkInterface> ntwk)
        {
            _ntwkDv = ntwk;
        }
        private void SetBluetoothDevices(IEnumerable<BluetoothRadio> blth)
        {
            _blthDv = blth;
        }
        /*
        private NetworkInterface GetNetworkDevices(int index)
        {
            return _ntwkDv.ElementAt(index);
        }
        private BluetoothRadio GetBluetoothDevices(int index)
        {
            return _blthDv.ElementAt(index);
        }
        */
        public void SetDevices(object deviceList)
        {
            switch (_mode)
            {
                case Mode.Bluetooth:
                    SetBluetoothDevices(deviceList as IEnumerable<BluetoothRadio>);
                    break;
                case Mode.Network:
                    SetNetworkDevices(deviceList as IEnumerable<NetworkInterface>);
                    break;
                default:
                    break;
            }
        }

        public int GetDeviceCount()
        {
            switch (_mode)
            {
                case Mode.Bluetooth:
                    return _blthDv.Count(any => true);
                case Mode.Network:
                    return _ntwkDv.Count(any => true);
                default:
                    return 0;
            }
        }

        public string GetDeviceName(int index)
        {
            switch (_mode)
            {
                case Mode.Bluetooth:
                    var infoBl = new UserInfo.BluetoothRadioUserInfo(_blthDv.ElementAt(index));
                    return infoBl.Manufacturer + "(" + infoBl.MAC_address + ")";
                case Mode.Network:
                    var infoNt = new UserInfo.NetInterfaceUserInfo(_ntwkDv.ElementAt(index));
                    return infoNt.Name + "(" + infoNt.MAC_address + ")";
                default:
                    return null;
            }
        }

        public string GetDeviceInfo(int index)
        {
            switch (_mode)
            {
                case Mode.Bluetooth:
                    return UserInfo.StaticUserInfo.DictionaryToString(new UserInfo.BluetoothRadioUserInfo(_blthDv.ElementAt(index)).ToDictionary());
                case Mode.Network:
                    return UserInfo.StaticUserInfo.DictionaryToString(new UserInfo.NetInterfaceUserInfo(_ntwkDv.ElementAt(index)).ToDictionary());
                default:
                    return null;
            }
        }

        public string GetIPAdressString(int index)
        {
            switch (_mode)
            {
                case Mode.Bluetooth:
                    return null;
                case Mode.Network:
                    return new UserInfo.NetInterfaceUserInfo(_ntwkDv.ElementAt(index)).IP_address;
                default:
                    return null;
            }
        }
    }
}

namespace ConnectabeDevices
{
    public class StaticDvFinder
    {
        public static IEnumerable<NetworkInterface> nt()
        {
            var interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var intrfc in interfaces)
            {
                if (intrfc.OperationalStatus != OperationalStatus.Up)
                    continue;
                yield return intrfc;
            }
        }

        public static IEnumerable<BluetoothRadio> blth()
        {
            foreach (var item in BluetoothRadio.AllRadios)
            {
                yield return item;
            }
        }
    }
}
namespace UserInfo
{

    public class StaticUserInfo
    {
        private static IEnumerable<string> InternalDictionaryToString<Tkey, Tval>(Dictionary<Tkey, Tval> dict)
        {
            foreach (var item in dict)
            {
                yield return item.Key + "\r\n\t" + item.Value.ToString() + "\r\n";
            }
        }

        public static string DictionaryToString<Tkey, Tval>(Dictionary<Tkey, Tval> dict)
        {
            return StaticUserInfo.InternalDictionaryToString(dict).Aggregate((res, str) => res + str);
        }
    }

    public class BluetoothRadioUserInfo
    {
        public string Machine_name { get; private set; }
        public string Class_of_device { get; private set; }
        public string Manufacturer { get; private set; }
        public string MAC_address { get; private set; }
        public string Hardware_status { get; private set; }
        public string Mode { get; private set; }
        public string Software_manufacturer { get; private set; }
        public string Version_fingerprint { get; private set; }

        public BluetoothRadioUserInfo(BluetoothRadio bl_radio)
        {
            this.Fill(bl_radio);
        }

        public void Fill(BluetoothRadio bl_radio)
        {
            this.Machine_name = bl_radio.Name;
            this.Class_of_device = bl_radio.ClassOfDevice.Device.ToString();
            this.Manufacturer = bl_radio.Manufacturer.ToString();
            this.MAC_address = bl_radio.LocalAddress.ToString();
            this.Hardware_status = bl_radio.HardwareStatus.ToString();
            this.Mode = bl_radio.Mode.ToString();
            this.Software_manufacturer = bl_radio.SoftwareManufacturer.ToString();
            this.Version_fingerprint =
                bl_radio.HciVersion.ToString()
                + "/" + bl_radio.HciRevision.ToString()
                + "/" + bl_radio.LmpVersion.ToString()
                + "/" + bl_radio.LmpSubversion.ToString();
        }

        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Machine name", Machine_name);
            d.Add("Class of device", Class_of_device);
            d.Add("Manufacturer", Manufacturer);
            d.Add("MAC address", MAC_address);
            d.Add("Hardware status", Hardware_status);
            d.Add("Mode", Mode);
            d.Add("Software manufacturer", Software_manufacturer);
            d.Add("Version fingerprint", Version_fingerprint);
            return d;
        }

    }

    public class NetInterfaceUserInfo
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string MAC_address { get; private set; }
        public string IP_address { get; private set; }
        public string Network_interface_type { get; private set; }

        public NetInterfaceUserInfo(NetworkInterface nt_interface)
        {
            this.Fill(nt_interface);
        }

        public void Fill(NetworkInterface nt_interface)
        {
            this.Name = nt_interface.Name;
            this.Description = nt_interface.Description;
            this.MAC_address = nt_interface.GetPhysicalAddress().ToString();
            foreach (var address in nt_interface.GetIPProperties().UnicastAddresses)
            {
                if (address.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    this.IP_address = address.Address.ToString();
            }
            this.Network_interface_type = nt_interface.NetworkInterfaceType.ToString();
        }

        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Interface name", Name);
            d.Add("Description", Description);
            d.Add("MAC address", MAC_address);
            d.Add("IP address", IP_address);
            d.Add("Network interface type", Network_interface_type);
            return d;
        }

    }
}