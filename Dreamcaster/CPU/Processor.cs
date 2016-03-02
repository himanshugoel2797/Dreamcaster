using Dreamcaster.CPU.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamcaster.CPU
{
    public class Processor
    {
        public RegisterFile Registers { get; set; }

        public Processor()
        {
            Registers = new RegisterFile(
                //Banked GPRs
                new Register("R0", 32, true),
                new Register("R1", 32, true),
                new Register("R2", 32, true),
                new Register("R3", 32, true),
                new Register("R4", 32, true),
                new Register("R5", 32, true),
                new Register("R6", 32, true),
                new Register("R7", 32, true),

                //Unbanked GPRs
                new Register("R8", 32, false),
                new Register("R9", 32, false),
                new Register("R10", 32, false),
                new Register("R11", 32, false),
                new Register("R12", 32, false),
                new Register("R13", 32, false),
                new Register("R14", 32, false),
                new Register("R15", 32, false),

                //System Registers
                new Register("MACH", 32, false),
                new Register("MACL", 32, false),
                new Register("PR", 32, false),
                new Register("PC", 32, false),
                new Register("FPSCR", 32, false),
                new Register("FPUL", 32, false),

                //Control Registers
                new Register("SR", 32, false),
                new Register("SSR", 32, false),
                new Register("SPC", 32, false),
                new Register("GBR", 32, false),
                new Register("VBR", 32, false),
                new Register("SGR", 32, false),
                new Register("DBR", 32, false)
                );
        }
    }
}
