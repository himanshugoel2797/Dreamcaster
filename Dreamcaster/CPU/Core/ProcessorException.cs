using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreamcaster.CPU.Core
{
    public class ProcessorException : Exception
    {
        public ProcessorException(string msg) : base(msg)
        {

        }
    }
}
