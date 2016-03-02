using Dreamcaster.CPU.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamcaster.CPU
{
    public class MMU
    {
        public VirtualMemoryBackend VirtualMemory { get; set; }
        public PhysicalMemoryBackend PhysicalMemory { get; set; }

        public MMU()
        {
            PhysicalMemory = new PhysicalMemoryBackend(16 * 1024 * 1024);   //The Dreamcast had 16MB of physical CPU memory
            VirtualMemory = new VirtualMemoryBackend(PhysicalMemory);

            VirtualMemory.AddMMR(new MemoryMappedRegister("PTEH", 32, 0xFF000000, 0x1F000000, 0));
            VirtualMemory.AddMMR(new MemoryMappedRegister("PTEL", 32, 0xFF000004, 0x1F000004, 0));
            VirtualMemory.AddMMR(new MemoryMappedRegister("TTB", 32, 0xFF000008, 0x1F000008, 0));
            VirtualMemory.AddMMR(new MemoryMappedRegister("TEA", 32, 0xFF00000C, 0x1F00000C, 0));
            VirtualMemory.AddMMR(new MemoryMappedRegister("MMUCR", 32, 0xFF000010, 0x1F000010, 0));
        }
    }
}
