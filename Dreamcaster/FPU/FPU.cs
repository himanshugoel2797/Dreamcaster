using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamcaster.FPU
{
    public class FPU
    {
        RegisterBank Registers;

        #region FPSCR
        uint FPSCR_p;

        public RoundingMode RoundingMode { get; private set; }
        public FloatingExceptions Exceptions { get; private set; }
        public FloatingExceptions EnabledExceptions { get; private set; }
        public FloatingExceptions CauseExceptions { get; private set; }
        public DenormalizationMode DenormalizationMode { get; private set; }
        public PrecisionMode Precision { get; private set; }
        public PrecisionMode TransferSize { get; private set; }
        public int RegisterBankNumber { get; private set; }
        public bool IsError { get; private set; }
        public uint FPSCR
        {
            get
            {
                return FPSCR_p & ((1 << 22) - 1);   //Only bits 0-21 matter
            }
            set
            {
                FPSCR_p = value;
                RegisterBankNumber = (int)((FPSCR_p >> 21) & 1);
                Registers.FR = RegisterBankNumber != 0;  //Floating Register bank selection bit
                RoundingMode = (RoundingMode)(FPSCR_p & 0x3);   //Rounding Mode
                IsError = (FPSCR_p & (1 << 17)) != 0;
                CauseExceptions = (FloatingExceptions)((FPSCR_p >> 12) & 0x1f);     //Set to zero before executing an FPU instruction, set to 1 if the instruction caused an exception
                EnabledExceptions = (FloatingExceptions)((FPSCR_p >> 7) & 0x1f);    //Floating point exception enable bits
                Exceptions = (FloatingExceptions)((FPSCR_p >> 2) & 0x1f) & EnabledExceptions;   //Floating point exceptions
                DenormalizationMode = (DenormalizationMode)((FPSCR_p >> 18) & 1);
                Precision = (PrecisionMode)((FPSCR_p >> 19) & 1);
                TransferSize = (PrecisionMode)((FPSCR_p >> 20) & 1);
            }
        }
        #endregion

        public float FPUL { get; set; } //Floating Point Communication Register

        public FPU()
        {
            Registers = new RegisterBank();
            Reset();
        }

        public void Reset()
        {
            FPSCR = 0x00040001;
        }

    }
}
