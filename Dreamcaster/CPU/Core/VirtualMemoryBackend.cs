using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamcaster.CPU.Core
{
    public class VirtualMemoryBackend
    {
        public PhysicalMemoryBackend PhysicalMemory { get; set; }
        public List<MemoryMappedRegister> MMR { get; set; }

        private Dictionary<uint, int> AddrMMR_Map;
        private ProcessorModes CurrentProcessorMode;

        public bool AddressTranslation { get; set; }

        public VirtualMemoryBackend(PhysicalMemoryBackend pMem)
        {
            PhysicalMemory = pMem;
            MMR = new List<MemoryMappedRegister>();

            AddrMMR_Map = new Dictionary<uint, int>();
        }

        public void SetCurrentProcessorMode(ProcessorModes m)
        {
            CurrentProcessorMode = m;
            Register.SetCurrentProcessorMode(m);
        }

        public void AddMMR(MemoryMappedRegister mmr)
        {
            MMR.Add(mmr);
            if (!AddrMMR_Map.ContainsKey(mmr.PhysicalAddress)) AddrMMR_Map[mmr.PhysicalAddress] = MMR.Count - 1;
            else throw new ArgumentException("This MMR overwrites an existing MMR");
            if (!AddrMMR_Map.ContainsKey(mmr.PhysicalAddress)) AddrMMR_Map[mmr.TLBAddress] = MMR.Count - 1;
            else throw new ArgumentException("This MMR overwrites an existing MMR");
        }

        public uint ReadUInt32(uint addr)
        {
            if (AddrMMR_Map.ContainsKey(addr))
            {
                MemoryMappedRegister r = MMR[AddrMMR_Map[addr]];

                if (addr == r.PhysicalAddress && CurrentProcessorMode == ProcessorModes.System) return r.Value;
                else if (addr == r.TLBAddress && AddressTranslation) return r.Value;
                else throw new ProcessorException("Bad attempt to access MMR!");
            }
            else if (AddressTranslation)
            {
                //Parse page tables and determine what the physical address is
            }
            else
            {
                return PhysicalMemory.ReadUInt32(addr);
            }

            throw new Exception("Unexpected Error!");
        }
    }
}
