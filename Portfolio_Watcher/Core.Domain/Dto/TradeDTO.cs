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
        public Symbol Symbol { get; private set; }
        public double BuyPrice { get; private set; }
        //ToDo: sellprice moet optioneel
        public double SellPrice { get; private set; }
        public int Shares { get; private set; }
        public Portfolio Portfolio { get; private set; }
            
        //ToDo: even voor werken met db alle setters public gemaakt


        //get want hij haalt data uit de database is nog allemaal primitive. trade kan hiermee een trade maken
        public TradeDTO(int id, Symbol symbol, double buyPrice, double sellPrice, int shares)
        {
            Id = id;
            Symbol = symbol;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Shares = shares;
        }

        //set want deze trade object parameter kan al in de view gemaakt worden
        public TradeDTO(Trade trade)
        {
            Symbol = trade.Symbol;
            BuyPrice = trade.BuyPrice;
            SellPrice= trade.SellPrice;
            Shares = trade.Shares;
            Portfolio = trade.Portfolio;
        }
    }
}
