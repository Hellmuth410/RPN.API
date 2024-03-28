using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN.Utils.Exceptions
{
    public class InvalidOperandException : Exception
    {
        public InvalidOperandException() : base($"Invalid operand used.") { }
    }
}
