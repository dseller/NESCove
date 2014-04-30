using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.Core
{
    public class OpcodeExecutionException : ApplicationException
    {
        public OpcodeExecutionException(String message)
            : base(message) { }

        public OpcodeExecutionException(String message, Exception innerException)
            : base(message, innerException) { }
    }
}
