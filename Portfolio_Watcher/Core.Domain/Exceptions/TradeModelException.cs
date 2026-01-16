using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Exceptions
{
    public class TradeModelException : Exception
    {
        public TradeModelException(string message) : base(message) { }

        public TradeModelException(string message, Exception innerException) : base(message, innerException) { }
    }
}
