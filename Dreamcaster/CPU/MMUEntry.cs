using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamcaster.CPU
{
    public struct MMUEntry
    {
        public uint PTEA;
        public uint PTEL;
        public uint PTEH;
    }
}
