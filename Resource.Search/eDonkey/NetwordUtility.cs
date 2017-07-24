using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Search.eDonkey
{
    public class NetwordUtility
    {
        public static bool IsGoodIPPort(ulong longIP, uint port)
        {
            IPAddress ip;
            var addr = IPAddress.Parse(longIP.ToString()).ToString();
            bool valid = !string.IsNullOrEmpty(addr) && IPAddress.TryParse(addr, out ip);
            return valid && port > 0;
        }
        public static string ConvertToAddress(ulong longIP)
        {
            return IPAddress.Parse(longIP.ToString()).ToString();
        }

        public static ulong ConvertToLong(string stringLong)
        {
            return (ulong)BitConverter.ToInt64(IPAddress.Parse(stringLong).GetAddressBytes(), 0);
        }

        public static bool IsLocalIpAddress(string host)
        {
            try
            {
                IPAddress[] hostIPs = Dns.GetHostAddresses(host);
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress hostIP in hostIPs)
                {
                    if (IPAddress.IsLoopback(hostIP)) return true;
                    foreach (IPAddress localIP in localIPs)
                    {
                        if (hostIP.Equals(localIP)) return true;
                    }
                }
            }
            catch { }
            return false;
        }
    }
}
