using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Dreamcaster.FPU
{
    public class RegisterBank
    {
        public byte[] Storage;
        public bool FR { get; set; }    //Changes the bank ordering

        public RegisterBank()
        {
            Storage = new byte[32 * sizeof(float)]; //32 32-bit registers
        }

        public object Get(Registers name)
        {
            switch (name)
            {
                case Registers.FR0:
                case Registers.FR1:
                case Registers.FR2:
                case Registers.FR3:
                case Registers.FR4:
                case Registers.FR5:
                case Registers.FR6:
                case Registers.FR7:
                case Registers.FR8:
                case Registers.FR9:
                case Registers.FR10:
                case Registers.FR11:
                case Registers.FR12:
                case Registers.FR13:
                case Registers.FR14:
                case Registers.FR15:
                    if (!FR)
                        return BitConverter.ToSingle(Storage, (int)(name - Registers.FR0) * sizeof(float));
                    else
                        return BitConverter.ToSingle(Storage, (int)(name - Registers.FR0) * sizeof(float) + 16 * sizeof(float));
                case Registers.DR0:
                case Registers.DR2:
                case Registers.DR4:
                case Registers.DR6:
                case Registers.DR8:
                case Registers.DR10:
                case Registers.DR12:
                case Registers.DR14:
                    if (!FR)
                        return BitConverter.ToDouble(Storage, (int)(name - Registers.DR0) * sizeof(double));
                    else
                        return BitConverter.ToDouble(Storage, (int)(name - Registers.DR0) * sizeof(double) + 16 * sizeof(float));
                case Registers.FV0:
                case Registers.FV4:
                case Registers.FV8:
                case Registers.FV12:
                    return new Vector4((float)Get((Registers)((name - Registers.FV0) * 4)), (float)Get((Registers)((name - Registers.FV0) * 4 + 1)), (float)Get((Registers)((name - Registers.FV0) * 4 + 2)), (float)Get((Registers)((name - Registers.FV0) * 4 + 3)));

                case Registers.XF0:
                case Registers.XF1:
                case Registers.XF2:
                case Registers.XF3:
                case Registers.XF4:
                case Registers.XF5:
                case Registers.XF6:
                case Registers.XF7:
                case Registers.XF8:
                case Registers.XF9:
                case Registers.XF10:
                case Registers.XF11:
                case Registers.XF12:
                case Registers.XF13:
                case Registers.XF14:
                case Registers.XF15:
                    if (FR)
                        return BitConverter.ToSingle(Storage, (int)(name - Registers.XF0) * sizeof(float));
                    else
                        return BitConverter.ToSingle(Storage, (int)(name - Registers.XF0) * sizeof(float) + 16 * sizeof(float));
                case Registers.XD0:
                case Registers.XD2:
                case Registers.XD4:
                case Registers.XD6:
                case Registers.XD8:
                case Registers.XD10:
                case Registers.XD12:
                case Registers.XD14:
                    if (FR)
                        return BitConverter.ToDouble(Storage, (int)(name - Registers.XD0) * sizeof(double));
                    else
                        return BitConverter.ToDouble(Storage, (int)(name - Registers.XD0) * sizeof(double) + 16 * sizeof(float));
                case Registers.XMTRX:
                    return new Matrix4x4(
                                        (float)Get(Registers.XF0), (float)Get(Registers.XF4), (float)Get(Registers.XF8), (float)Get(Registers.XF12),
                                        (float)Get(Registers.XF1), (float)Get(Registers.XF5), (float)Get(Registers.XF9), (float)Get(Registers.XF13),
                                        (float)Get(Registers.XF2), (float)Get(Registers.XF6), (float)Get(Registers.XF10), (float)Get(Registers.XF14),
                                        (float)Get(Registers.XF3), (float)Get(Registers.XF7), (float)Get(Registers.XF11), (float)Get(Registers.XF15));
            }

            return null;
        }

        public void Set(Registers name, object val)
        {
            switch (name)
            {
                case Registers.FR0:
                case Registers.FR1:
                case Registers.FR2:
                case Registers.FR3:
                case Registers.FR4:
                case Registers.FR5:
                case Registers.FR6:
                case Registers.FR7:
                case Registers.FR8:
                case Registers.FR9:
                case Registers.FR10:
                case Registers.FR11:
                case Registers.FR12:
                case Registers.FR13:
                case Registers.FR14:
                case Registers.FR15:
                    if (!FR)
                        Array.Copy(BitConverter.GetBytes((float)val), 0, Storage, (int)(name - Registers.FR0) * sizeof(float), sizeof(float));
                    else
                        Array.Copy(BitConverter.GetBytes((float)val), 0, Storage, (int)(name - Registers.FR0) * sizeof(float) + 16 * sizeof(float), sizeof(float));
                    break;
                case Registers.DR0:
                case Registers.DR2:
                case Registers.DR4:
                case Registers.DR6:
                case Registers.DR8:
                case Registers.DR10:
                case Registers.DR12:
                case Registers.DR14:
                    if (!FR)
                        Array.Copy(BitConverter.GetBytes((double)val), 0, Storage, (int)(name - Registers.DR0) * sizeof(double), sizeof(double));
                    else
                        Array.Copy(BitConverter.GetBytes((double)val), 0, Storage, (int)(name - Registers.DR0) * sizeof(double) + 16 * sizeof(float), sizeof(double));
                    break;
                case Registers.FV0:
                case Registers.FV4:
                case Registers.FV8:
                case Registers.FV12:
                    Set((Registers)((name - Registers.FV0) * 4), ((Vector4)val).X);
                    Set((Registers)((name - Registers.FV0) * 4 + 1), ((Vector4)val).Y);
                    Set((Registers)((name - Registers.FV0) * 4 + 2), ((Vector4)val).Z);
                    Set((Registers)((name - Registers.FV0) * 4 + 3), ((Vector4)val).W);
                    break;
                case Registers.XF0:
                case Registers.XF1:
                case Registers.XF2:
                case Registers.XF3:
                case Registers.XF4:
                case Registers.XF5:
                case Registers.XF6:
                case Registers.XF7:
                case Registers.XF8:
                case Registers.XF9:
                case Registers.XF10:
                case Registers.XF11:
                case Registers.XF12:
                case Registers.XF13:
                case Registers.XF14:
                case Registers.XF15:
                    if (FR)
                        Array.Copy(BitConverter.GetBytes((float)val), 0, Storage, (int)(name - Registers.XF0) * sizeof(float), sizeof(float));
                    else
                        Array.Copy(BitConverter.GetBytes((float)val), 0, Storage, (int)(name - Registers.XF0) * sizeof(float) + 16 * sizeof(float), sizeof(float));
                    break;
                case Registers.XD0:
                case Registers.XD2:
                case Registers.XD4:
                case Registers.XD6:
                case Registers.XD8:
                case Registers.XD10:
                case Registers.XD12:
                case Registers.XD14:
                    if (FR)
                        Array.Copy(BitConverter.GetBytes((double)val), 0, Storage, (int)(name - Registers.XD0) * sizeof(double), sizeof(double));
                    else
                        Array.Copy(BitConverter.GetBytes((double)val), 0, Storage, (int)(name - Registers.XD0) * sizeof(double) + 16 * sizeof(float), sizeof(double));
                    break;
                case Registers.XMTRX:
                    {
                        var tmp = (Matrix4x4)val;
                        Set(Registers.XF0, tmp.M11); Set(Registers.XF4, tmp.M12); Set(Registers.XF8, tmp.M13); Set(Registers.XF12, tmp.M14);
                        Set(Registers.XF1, tmp.M21); Set(Registers.XF5, tmp.M22); Set(Registers.XF9, tmp.M23); Set(Registers.XF13, tmp.M24);
                        Set(Registers.XF2, tmp.M31); Set(Registers.XF6, tmp.M32); Set(Registers.XF10, tmp.M33); Set(Registers.XF14, tmp.M34);
                        Set(Registers.XF3, tmp.M41); Set(Registers.XF7, tmp.M42); Set(Registers.XF11, tmp.M43); Set(Registers.XF15, tmp.M44);
                    }
                    break;
            }
        }

    }
}
