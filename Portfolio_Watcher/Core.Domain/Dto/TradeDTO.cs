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
        public double BuyPrice { get; private set; }
        public double SellPrice { get; private set; }
        public int Shares { get; private set; }
        public Portfolio Portfolio { get; private set; }
            
        //ToDo: even voor werken met db alle setters public gemaakt


        public TradeDTO(string symbol, double buyPrice, double sellPrice, int shares, Portfolio portfolio)
        {
            Symbol = symbol;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Shares = shares;
            Portfolio = portfolio;

        }

        public TradeDTO(int id, string symbol, double buyPrice, double sellPrice, int shares, Portfolio portfolio)
        {
            Id = id;
            Symbol = symbol;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Shares = shares;
            Portfolio = portfolio;
        }
    }
}
