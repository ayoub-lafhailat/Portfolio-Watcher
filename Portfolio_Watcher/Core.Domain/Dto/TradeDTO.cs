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
        public int SymbolId { get; private set; }
        public double BuyPrice { get; private set; }
        //ToDo: sellprice moet optioneel
        public double SellPrice { get; private set; }
        public int Shares { get; private set; }
        public int PortfolioId { get; private set; }
            
        //ToDo: even voor werken met db alle setters public gemaakt


        //get want hij haalt data uit de database is nog allemaal primitive. trade kan hiermee een trade maken
        public TradeDTO(int id, int symbolId, double buyPrice, double sellPrice, int shares, int portfolioId)
        {
            Id = id;
            SymbolId = symbolId;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Shares = shares;
            PortfolioId = portfolioId;
        }

        //set want deze trade object parameter kan al in de view gemaakt worden
        public TradeDTO(Trade trade)
        {
            if (!trade.Portfolio.PortfolioId.HasValue)
            {
                throw new InvalidOperationException("Cannot create TradeDTO: Trade must be associated with a persisted Portfolio.");
            }
            SymbolId = trade.Symbol.SymbolId;
            BuyPrice = trade.BuyPrice;
            SellPrice= trade.SellPrice;
            Shares = trade.Shares;
            PortfolioId = trade.Portfolio.PortfolioId;
        }
    }
}
