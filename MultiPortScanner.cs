using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EgressChecker
{
    class MultiPortScanner
    {
        public static IEnumerable<ScannedPort> ScanPorts(IPAddress target, ushort startPort, ushort endPort)
        {
            int max = endPort - startPort + 1;
            PortScanner[] portScannerArray = new PortScanner[max];
            try
            {
                Parallel.For(0, max, i =>
                {
                    PortScanner ps = new PortScanner(target, i + startPort);
                    portScannerArray[i] = ps;
                    ps.ScanPort();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("[!] Exception: {0}", e.ToString());
            }
            return (from ps in portScannerArray select new ScannedPort(ps.Port, ps.IsOpen)).ToList();
        }
    }
}
