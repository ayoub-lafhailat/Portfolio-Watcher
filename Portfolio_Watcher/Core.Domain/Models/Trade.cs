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

        //Data validatie vooral belangrijk in deze constructor
        //Omdat deze constructor wordt voor nu gebruikt voor het versturen van user input naar database
        //Dus hier is validatie het belangrijkst want dit is het meest fout gevoelig
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
