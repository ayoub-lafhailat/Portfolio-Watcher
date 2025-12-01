using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    public class Trade
    {
        public string Symbol { get; private set; }
        public double Price { get; private set; }
        public int Shares { get; private set; } 

        public Trade(string symbol, double price, int shares)
        {
            Symbol = symbol;
            Price = price;
            Shares = shares;
        }
    }
}
