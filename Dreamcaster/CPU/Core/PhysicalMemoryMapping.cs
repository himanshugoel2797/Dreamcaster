using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamcaster.CPU.Core
{
    public struct PhysicalMemoryMapping
    {
        public uint StartAddr;
        public uint EndAddr;

        public ProcessorModes RequiredModePermissions;
        public bool CanWrite;
        public bool CanRead;

        public Func<uint, int> ReadInt32;
        public Func<uint, short> ReadInt16;
        public Func<uint, sbyte> ReadInt8;
        public Func<uint, uint> ReadUInt32;
        public Func<uint, ushort> ReadUInt16;
        public Func<uint, byte> ReadUInt8;

        public Action<uint, int> WriteInt32;
        public Action<uint, short> WriteInt16;
        public Action<uint, sbyte> WriteInt8;
        public Action<uint, uint> WriteUInt32;
        public Action<uint, ushort> WriteUInt16;
        public Action<uint, byte> WriteUInt8;
    }

}
