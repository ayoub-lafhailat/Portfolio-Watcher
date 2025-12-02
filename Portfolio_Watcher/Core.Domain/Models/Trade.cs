using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    public class Trade
    {
        public int? Id { get; private set; }
        public string Symbol { get; private set; }
        public double Price { get; private set; }
        public int Shares { get; private set; }

        //ToDo: even voor werken met db alle setters public gemaakt

        public Trade(string symbol, double price, int shares)
        {
            Symbol = symbol;
            Price = price;
            Shares = shares;
        }
       
        public Trade(int id, string symbol, double price, int shares)
        {
            Id = id;
            Symbol = symbol;
            Price = price;
            Shares = shares;
        }
    }
}
