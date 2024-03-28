using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN.Utils.Exceptions
{
    public class ComputeException : Exception
    {
        public ComputeException() : base("Error during compute.") { }
        public ComputeException(string message) : base("Error during compute." + message) { }
    }
}
