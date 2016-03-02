using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamcaster.CPU.Core
{
    public class MemoryMappedRegister
    {
        public uint PhysicalAddress { get; private set; }
        public uint TLBAddress { get; private set; }
        public string Name { get; private set; }
        public uint Value { get; private set; }
        public int BitWidth { get; private set; }

        public MemoryMappedRegister(string name, int bitWidth, uint physAddr, uint tlbAddr, uint val)
        {
            Name = name;
            PhysicalAddress = physAddr;
            TLBAddress = tlbAddr;
            Value = val;
            BitWidth = bitWidth;
        }
    }
}
