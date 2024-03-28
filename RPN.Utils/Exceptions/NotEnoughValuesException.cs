using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN.Utils.Exceptions
{
    public class NotEnoughValuesException : Exception
    {
        public NotEnoughValuesException() : base("Not enough values to proceed.") { }
    }
}
