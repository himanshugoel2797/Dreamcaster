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
        MemoryStream memory;

        public PhysicalMemoryBackend(int len)
        {
            memory = new MemoryStream(len);
        }

        #region Signed Access
        public int ReadInt32(uint offset)
        {
            memory.Seek(offset, SeekOrigin.Begin);
            byte[] tmp = new byte[sizeof(int)];
            memory.Read(tmp, 0, sizeof(int));
            return BitConverter.ToInt32(tmp, 0);
        }

        public short ReadInt16(uint offset)
        {
            memory.Seek(offset, SeekOrigin.Begin);
            byte[] tmp = new byte[sizeof(short)];
            memory.Read(tmp, 0, sizeof(short));
            return BitConverter.ToInt16(tmp, 0);
        }

        public sbyte ReadInt8(uint offset)
        {
            memory.Seek(offset, SeekOrigin.Begin);
            return (sbyte)memory.ReadByte();
        }
        #endregion

        #region Unsigned Access
        public uint ReadUInt32(uint offset)
        {
            memory.Seek(offset, SeekOrigin.Begin);
            byte[] tmp = new byte[sizeof(uint)];
            memory.Read(tmp, 0, sizeof(uint));
            return BitConverter.ToUInt32(tmp, 0);
        }

        public ushort ReadUInt16(uint offset)
        {
            memory.Seek(offset, SeekOrigin.Begin);
            byte[] tmp = new byte[sizeof(ushort)];
            memory.Read(tmp, 0, sizeof(ushort));
            return BitConverter.ToUInt16(tmp, 0);
        }

        public byte ReadUInt8(uint offset)
        {
            memory.Seek(offset, SeekOrigin.Begin);
            return (byte)memory.ReadByte();
        }
        #endregion

        #region Signed Write
        public void WriteInt8(uint addr, sbyte val)
        {
            memory.Seek(addr, SeekOrigin.Begin);
            memory.WriteByte((byte)val);
        }

        public void WriteInt16(uint addr, short val)
        {
            memory.Seek(addr, SeekOrigin.Begin);
            memory.Write(BitConverter.GetBytes(val), 0, sizeof(short));
        }

        public void WriteInt32(uint addr, int val)
        {
            memory.Seek(addr, SeekOrigin.Begin);
            memory.Write(BitConverter.GetBytes(val), 0, sizeof(int));
        }
        #endregion

        #region Unsigned Write
        public void WriteUInt8(uint addr, byte val)
        {
            memory.Seek(addr, SeekOrigin.Begin);
            memory.WriteByte(val);
        }

        public void WriteUInt16(uint addr, ushort val)
        {
            memory.Seek(addr, SeekOrigin.Begin);
            memory.Write(BitConverter.GetBytes(val), 0, sizeof(ushort));
        }

        public void WriteUInt32(uint addr, uint val)
        {
            memory.Seek(addr, SeekOrigin.Begin);
            memory.Write(BitConverter.GetBytes(val), 0, sizeof(uint));
        }
        #endregion

    }
}
