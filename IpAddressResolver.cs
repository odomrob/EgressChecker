using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EgressChecker
{
    class IpAddressResolver
    {
        static bool IsAnIpAddress(string address)
        {
            IPAddress ipAddress = null;
            return IPAddress.TryParse(address, out ipAddress);
        }

        static IPAddress GetIpAddressFromHostName(string scanAddress)
        {
            IPHostEntry NameToIpAddress = Dns.GetHostEntry(scanAddress);

            if (NameToIpAddress.AddressList.Length > 0)
            {
                // filter out IPv6
                var address = NameToIpAddress.AddressList.Where(a => a.AddressFamily ==
                    System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();

                if (address != null)
                    return address;
            }

            throw new ArgumentException(string.Format("[!] Unable to lookup host name '{0}'.", scanAddress));
        }


        public static IPAddress ResolveIpAddress(string target)
        {
            if (IsAnIpAddress(target))
                return IPAddress.Parse(target);

            try
            {
                var ipAddress = GetIpAddressFromHostName(target);
                return ipAddress;
            }
            catch (ArgumentException)
            {
                // pass for now
            }

            return null;
        }
    }
}
