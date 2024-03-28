using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN.Utils.Exceptions
{
    public class NoCacheFoundException : Exception
    {
        public NoCacheFoundException() : base("No element found in the memory cache.") { }
    }
}
