using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Exceptions
{
    public class TradeServiceException : Exception
    {
        public TradeServiceException(string message) : base(message) { }

        public TradeServiceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
