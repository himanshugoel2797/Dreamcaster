using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamcaster.FPU
{
    public enum FloatingExceptions
    {
        Inexact = (1 << 0),
        Underflow = (1 << 1),
        Overflow = (1 << 2),
        DivideByZero = (1 << 3),
        InvalidOperation = (1 << 4)
    }
}
