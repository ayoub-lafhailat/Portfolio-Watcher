using Core.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Portfolio_Watcher.Models
{
    public class TradeView
    {
        public int? Id { get; set; }

        [Range(1, 10000, ErrorMessage = "Selecteer een geldig Symbool.")]
        public int SymbolId { get; set; }

        [Range(1, 1000, ErrorMessage = "Selecteer een geldig Portfolio.")]
        public int PortfolioId { get; set; }

        [Required(ErrorMessage = "BuyPrice moet tussen 0.01 en 100000 liggen.")]
        public double BuyPrice { get; set; }

        [Required(ErrorMessage = "SellPrice moet tussen 0.01 en 100000 liggen.")]
        public double SellPrice { get; set; }

        [Range(1, 1000000, ErrorMessage = "Shares moet minimaal 1 zijn.")]
        public int Shares { get; set; }

        public double PositionSize { get; private set; }
        public double ProfitLoss { get; private set; }
        public double ChangePercentage { get; private set; }


        public TradeView() { }

        //user input constructor
        public TradeView(int symbolId, double buyPrice, double sellPrice, int shares, int portfolioId)
        {
            SymbolId = symbolId;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Shares = shares;
            PortfolioId = portfolioId;
        }
    }
}