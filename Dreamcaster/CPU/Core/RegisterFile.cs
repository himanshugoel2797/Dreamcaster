using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamcaster.CPU.Core
{
    public class RegisterFile
    {
        private Dictionary<int, Register> Registers;
        private ProcessorModes CurrentProcessorMode;
        public void SetCurrentProcessorMode(ProcessorModes m)
        {
            CurrentProcessorMode = m;
            Register.SetCurrentProcessorMode(m);
        }

        public RegisterFile(params Register[] regs)
        {
            Registers = new Dictionary<int, Register>();
            for (int i = 0; i < regs.Length; i++)
            {
                Registers[i] = regs[i];
            }
        }

        public void Add(int key, Register a)
        {
            Registers.Add(key, a);
        }

        public Register this[int a]
        {
            get
            {
                return Registers[a];
            }
            set
            {
                Registers[a] = value;
            }
        }

    }
}
