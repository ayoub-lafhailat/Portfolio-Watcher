using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Exceptions
{
    public class TradeServiceFixableException : Exception
    {
        public TradeServiceFixableException(string message) : base(message) { }

        public TradeServiceFixableException(string message, Exception innerException) : base(message, innerException) { }
    }
}
