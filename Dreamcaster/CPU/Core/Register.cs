using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamcaster.CPU.Core
{
    public class Register
    {
        public string Name
        {
            get; private set;
        }
        public int BitWidth
        {
            get; private set;
        }
        public long[] Values
        {
            get; private set;
        }
        public bool Banked
        {
            get; private set;
        }

        public Register(string name, int bitCount, bool banked, params long[] initVals)
        {
            Name = name;
            BitWidth = bitCount;
            Banked = banked;

            Values = new long[banked ? Enum.GetValues(typeof(ProcessorModes)).Cast<ProcessorModes>().Distinct().Count() : 1];
            for (int i = 0; i < initVals.Length && i < Values.Length; i++)
            {
                Values[i] = initVals[i];
            }
        }

        public long Get() { return Values[(int)(Banked ? CurrentProcessorMode : 0)]; }
        public void Set(long value) { Values[(int)(Banked ? CurrentProcessorMode : 0)] = value; }

        public static implicit operator long(Register a)
        {
            return a.Get();
        }

        public long this[ProcessorModes m]
        {
            get
            {
                if (!Banked && m != ProcessorModes.Any) throw new ArgumentException("Attempt to use banked access on unbanked register!");
                    return Values[(int)m];
            }
            set
            {
                if (!Banked && m != ProcessorModes.Any) throw new ArgumentException("Attempt to use banked access on unbanked register!");
                Values[(int)m] = value & ~(-1 << BitWidth);
            }
        }

        private static ProcessorModes CurrentProcessorMode;
        public static void SetCurrentProcessorMode(ProcessorModes m)
        {
            CurrentProcessorMode = m;
        }
    }
}
