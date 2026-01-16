using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Exceptions
{
    public class TradeRepositoryException: Exception
    {
        public TradeRepositoryException(string message) : base(message) { }

        public TradeRepositoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
