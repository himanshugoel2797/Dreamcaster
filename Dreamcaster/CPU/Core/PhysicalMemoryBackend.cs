using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamcaster.CPU.Core
{
    public class PhysicalMemoryBackend
    {
        List<PhysicalMemoryMapping> Mappings;
        // The SH-4 supports a 29bit physical address space

        private PhysicalMemoryMapping TranslateAddress(uint addr)
        {
            for (int i = 0; i < Mappings.Count; i++)
            {
                if (Mappings[i].StartAddr <= addr && Mappings[i].EndAddr > addr) return Mappings[i];
            }
            throw new ProcessorException("Invalid Memory Access!");
        }

        public PhysicalMemoryBackend(int len)
        {
            Mappings = new List<PhysicalMemoryMapping>();
        }

        public void RegisterMapping(PhysicalMemoryMapping map)
        {
            for (int i = 0; i < Mappings.Count; i++)
            {
                if ((Mappings[i].StartAddr <= map.StartAddr && Mappings[i].EndAddr > map.StartAddr) | (Mappings[i].StartAddr <= map.EndAddr && Mappings[i].EndAddr >= map.EndAddr))
                    throw new Exception("Attempt to perform invalid mapping!");
            }

            Mappings.Add(map);
        }

        #region Read from memory
        public int ReadInt32(uint addr)
        {
            var tmp = TranslateAddress(addr);
            if (!tmp.CanRead) throw new Exception("Invalid Memory Access!");
            return tmp.ReadInt32(addr);
        }

        public short ReadInt16(uint addr)
        {
            var tmp = TranslateAddress(addr);
            if (!tmp.CanRead) throw new Exception("Invalid Memory Access!");
            return tmp.ReadInt16(addr);
        }

        public sbyte ReadInt8(uint addr)
        {
            var tmp = TranslateAddress(addr);
            if (!tmp.CanRead) throw new Exception("Invalid Memory Access!");
            return tmp.ReadInt8(addr);
        }

        public uint ReadUInt32(uint addr)
        {
            var tmp = TranslateAddress(addr);
            if (!tmp.CanRead) throw new Exception("Invalid Memory Access!");
            return tmp.ReadUInt32(addr);
        }

        public ushort ReadUInt16(uint addr)
        {
            var tmp = TranslateAddress(addr);
            if (!tmp.CanRead) throw new Exception("Invalid Memory Access!");
            return tmp.ReadUInt16(addr);
        }

        public byte ReadUInt8(uint addr)
        {
            var tmp = TranslateAddress(addr);
            if (!tmp.CanRead) throw new Exception("Invalid Memory Access!");
            return tmp.ReadUInt8(addr);
        }
        #endregion

        #region Write to memory
        public void WriteInt32(uint addr, int val)
        {
            var tmp = TranslateAddress(addr);
            if (!tmp.CanWrite) throw new Exception("Invalid Memory Write!");
            tmp.WriteInt32(addr, val);
        }

        public void WriteInt16(uint addr, short val)
        {
            var tmp = TranslateAddress(addr);
            if (!tmp.CanWrite) throw new Exception("Invalid Memory Write!");
            tmp.WriteInt16(addr, val);
        }

        public void WriteInt8(uint addr, sbyte val)
        {
            var tmp = TranslateAddress(addr);
            if (!tmp.CanWrite) throw new Exception("Invalid Memory Write!");
            tmp.WriteInt8(addr, val);
        }

        public void WriteUInt32(uint addr, uint val)
        {
            var tmp = TranslateAddress(addr);
            if (!tmp.CanWrite) throw new Exception("Invalid Memory Write!");
            tmp.WriteUInt32(addr, val);
        }

        public void WriteUInt16(uint addr, ushort val)
        {
            var tmp = TranslateAddress(addr);
            if (!tmp.CanWrite) throw new Exception("Invalid Memory Write!");
            tmp.WriteUInt16(addr, val);
        }

        public void WriteUInt8(uint addr, byte val)
        {
            var tmp = TranslateAddress(addr);
            if (!tmp.CanWrite) throw new Exception("Invalid Memory Write!");
            tmp.WriteUInt8(addr, val);
        }
        #endregion
    }
}
