using Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{

    public class Trade
    {
        public int? Id { get; private set; }
        public Symbol Symbol { get; private set; }
        public double BuyPrice { get; private set; }
        //ToDo: sellprice moet optioneel of mag null zijn.
        public double SellPrice { get; private set; }
        public int Shares { get; private set; }
        //ToDo: de calculate methodes kan je eigenlijk gewoon in de get zetten, want de get is gewoon een methode die je kan defineren.
        //ToDo: moeten PositionSize/ProfitLoss/Changepercentage wel properties zijn? Heb je niet gewoon genoeg aan de methods?
        public double PositionSize { get; private set; }
        public double ProfitLoss { get; private set; }
        public double ChangePercentage { get; private set; }
        public Portfolio Portfolio { get; private set; }

        public Trade(Symbol symbol, double buyPrice, double sellPrice, int shares, Portfolio portfolio)
        {
            //deze validatie moet niet hier en moet weg. Is niet SRP verantwoordelijkheid van trade om te kijken of Symbol.Name goed is.
            //if (Symbol.Name.Length < 3 || Symbol.Name.Length > 5)
            //{
            //    throw new ArgumentException("Symbol moet tussen de 3 en 5 tekens lang zijn.", nameof(symbol));
            //}

            if (buyPrice <= 0)
            {
                throw new ArgumentException("Price moet groter dan 0 zijn.", nameof(buyPrice));
            }

            if (sellPrice <= 0)
            {
                throw new ArgumentException("Price moet groter dan 0 zijn.", nameof(sellPrice));
            }

            if (shares <= 0)
            {
                throw new ArgumentException("Shares moeten groter dan 0 zijn.", nameof(shares));
            }
            // Business rule: Trade kan alleen bestaan met een bestaande Portfolio, voor symbol geld ook maar die heeft een vaste int symbolid, portfolio niet want bij setten bestaat id nog niet.
            if (!portfolio.PortfolioId.HasValue)
            {
                throw new InvalidOperationException("Trade cannot be created without a persisted Portfolio.");
            }

            Symbol = symbol;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Shares = shares;
            Portfolio = portfolio;
        }

        //get-set dto constructor naar db
        public Trade(TradeDTO tradeDto, Symbol symbol, Portfolio portfolio)
        {
            Id = tradeDto.Id;                 // null bij create, gevuld bij load
            Symbol = symbol;
            BuyPrice = tradeDto.BuyPrice;
            SellPrice = tradeDto.SellPrice;
            Shares = tradeDto.Shares;
            Portfolio = portfolio;

            Recalculate();
        }

        private void CalculatePositionSize()
        {
            PositionSize = this.BuyPrice * this.Shares;
        }

        private void CalculateProfitLoss()
        {
            ProfitLoss = (this.SellPrice - this.BuyPrice) * this.Shares;
        }

        private void CalculateChangePercentage()
        {
            ChangePercentage = this.ProfitLoss / 100;
        }

        private void Recalculate()
        {
            CalculatePositionSize();
            CalculateProfitLoss();
            CalculateChangePercentage();
        }
    }
}
