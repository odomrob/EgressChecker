using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgressChecker
{
    class ScannedPort
    {
        public int Port { get; private set; }
        public bool IsOpen { get; private set; }

        public ScannedPort(int port, bool isOpen)
        {
            this.Port = port;
            this.IsOpen = isOpen;
        }
    }
}
