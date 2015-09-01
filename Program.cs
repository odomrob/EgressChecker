using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EgressChecker
{   
    public class Program
    {
        public static int Main(String[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("[!] You must provide a listening server.");
                return -1;
            }

            IList<ScannedPort> portResults = null;
            try
            {
                IPAddress ip = IpAddressResolver.ResolveIpAddress(args[0]);
                if (ip == null)
                {
                    Console.WriteLine("[!] Listening server IP address could not be resolved.");
                    return -1;
                }

                PortScanController controller = new PortScanController();
                portResults = controller.ScanPorts(ip.ToString(), "1", "65535").ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("[!] Error: {0}", e.ToString());
            }
            return 0;
        }
    }
}
