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
        public PhysicalMemoryBackend PhysicalMemory { get; set; }

        public enum Registers
        {
            PTEH, PTEL, TTB, TEA, MMUCR, PTEA = 14
        }

        public MMUEntry[] UTLB { get; set; }
        public MMUEntry[] ITLB { get; set; }

        public uint[] RegisterValues;
        private ProcessorModes CurrentProcessorMode;
        public void SetCurrentProcessorMode(ProcessorModes m)
        {
            CurrentProcessorMode = m;
        }

        public bool Enabled { get; private set; }

        public uint ReadUInt32(uint addr)
        {
            if ((addr >> 24) == 0xFF && CurrentProcessorMode == ProcessorModes.System)
            {
                return RegisterValues[(addr - 0xFF000000) / sizeof(uint)];
            }
            else if ((addr >> 24) == 0x1F && Enabled)
            {
                return RegisterValues[(addr - 0x1F000000) / sizeof(uint)];
            }
            else throw new ArgumentException("Unexpected Error");
        }

        public int ReadInt32(uint addr)
        {
            if ((addr >> 24) == 0xFF && CurrentProcessorMode == ProcessorModes.System)
            {
                return (int)RegisterValues[(addr - 0xFF000000) / sizeof(uint)];
            }
            else if ((addr >> 24) == 0x1F && Enabled)
            {
                return (int)RegisterValues[(addr - 0x1F000000) / sizeof(uint)];
            }
            else throw new ArgumentException("Unexpected Error");
        }

        public void WriteInt32(uint addr, int val)
        {
            Registers reg;
            if ((addr >> 24) == 0xFF && CurrentProcessorMode == ProcessorModes.System)
            {
                reg = (Registers)((addr - 0xFF000000) / sizeof(uint));
                RegisterValues[(int)reg] = (uint)val;
            }
            else if ((addr >> 24) == 0x1F && Enabled)
            {
                reg = (Registers)((addr - 0x1F000000) / sizeof(uint));
                RegisterValues[(int)reg] = (uint)val;
            }
            else throw new ArgumentException("Unexpected Error");

            switch (reg)
            {
                case Registers.MMUCR:

                    break;
            }
        }

        public MMU(PhysicalMemoryBackend PhysicalMemory)
        {
            this.PhysicalMemory = PhysicalMemory;
            RegisterValues = new uint[0x38 / sizeof(uint)];

            UTLB = new MMUEntry[(1 << 6) - 1];  //The maximum number of entries is the number of bits for the MMUCR.URC field
            ITLB = new MMUEntry[(1 << 6) - 1];  //The ITLB is separate from the UTLB

            PhysicalMemoryMapping MMRs = new PhysicalMemoryMapping()
            {
                StartAddr = 0xFF000000,
                EndAddr = 0xFF000038,
                RequiredModePermissions = ProcessorModes.System,
                CanRead = true,
                CanWrite = true,
                ReadInt32 = ReadInt32,
                ReadUInt32 = ReadUInt32
            };

            PhysicalMemoryMapping TLB_MMRs = new PhysicalMemoryMapping()
            {
                StartAddr = 0x1F000000,
                EndAddr = 0x1F000038,
                RequiredModePermissions = ProcessorModes.Any,
                CanRead = true,
                CanWrite = true,
                ReadInt32 = ReadInt32,
                ReadUInt32 = ReadUInt32
            };
            this.PhysicalMemory.RegisterMapping(MMRs);
            this.PhysicalMemory.RegisterMapping(TLB_MMRs);
        }

        public void LDTLB()
        {
            MMUEntry entry = new MMUEntry()
            {
                PTEA = RegisterValues[(int)Registers.PTEA],
                PTEH = RegisterValues[(int)Registers.PTEH],
                PTEL = RegisterValues[(int)Registers.PTEL]
            };

            UTLB[(RegisterValues[(int)Registers.MMUCR] >> 10) & ((1 << 6) - 1)] = entry;    //Based on the MMUCR.URC field (bits 10->15) update the UTLB entries
        }



    }
}
