using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Core.Domain.Models
    {
        public class TradeDTO
        {
            public int? Id { get; private set; }
            public string Symbol { get; private set; }
            public double Price { get; private set; }
            public int Shares { get; private set; }

            //ToDo: even voor werken met db alle setters public gemaakt


            public TradeDTO(string symbol, double price, int shares)
            {
                Symbol = symbol;
                Price = price;
                Shares = shares;
            }

            public TradeDTO(int id, string symbol, double price, int shares)
            {
                Id = id;
                Symbol = symbol;
                Price = price;
                Shares = shares;
            }
        }
    }
}
