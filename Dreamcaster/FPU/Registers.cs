using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamcaster.FPU
{
    public enum Registers
    {
        FR0 = 0, FR1, FR2, FR3, FR4, FR5, FR6, FR7, FR8, FR9, FR10, FR11, FR12, FR13, FR14, FR15,
        DR0 = 16, DR2, DR4, DR6, DR8, DR10, DR12, DR14,
        FV0 = 24, FV4, FV8, FV12,
        XF0 = 28, XF1, XF2, XF3, XF4, XF5, XF6, XF7, XF8, XF9, XF10, XF11, XF12, XF13, XF14, XF15,
        XD0 = 44, XD2, XD4, XD6, XD8, XD10, XD12, XD14,
        XMTRX = 53
    }
}
