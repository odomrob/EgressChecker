using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgressChecker
{
    interface IPortScanController
    {
        bool InputValuesAcceptable(string target, string startPort, string endPort);
        IEnumerable<ScannedPort> ScanPorts(string target, string startPort, string endPort);
    }
}
