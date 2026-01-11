using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{

    public class Trade
    {
        public int? Id { get; private set; }
        public Symbol Symbol { get; private set; }
        public Portfolio Portfolio { get; private set; }
        public double BuyPrice { get; private set; }
        public double SellPrice { get; private set; }
        public int Shares { get; private set; }
        //ToDo: de calculate methodes kan je eigenlijk gewoon in de get zetten, want de get is gewoon een methode die je kan defineren.
        public double PositionSize { get; private set; }
        public double ProfitLoss { get; private set; }
        public double ChangePercentage { get; private set; }
        //dit moet een field zijn? waarom moet je portfolio class in de trade class een property zijn?


        public Trade(Symbol symbol, double buyPrice, double sellPrice, int shares, Portfolio portfolio)
        {
            //deze validatie moet niet hier en moet weg. Is niet SRP verantwoordelijkheid van trade om te kijken of Symbol.Name goed is.
            if (Symbol.Name.Length < 3 || Symbol.Name.Length > 5)
            {
                throw new ArgumentException("Symbol moet tussen de 3 en 5 tekens lang zijn.", nameof(symbol));
            }

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

            Symbol = symbol;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Shares = shares;
            Portfolio = portfolio;
        }

        public Trade(int id, Symbol symbol, double buyPrice, double sellPrice, int shares, Portfolio portfolio)
        {
            Id = id;
            Symbol = symbol;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Shares = shares;
            Portfolio = portfolio;

            CalculatePositionSize();
            CalculateProfitLoss();
            CalculateChangePercentage();
        }

        public void CalculatePositionSize()
        {
            PositionSize = this.BuyPrice * this.Shares;
        }

        public void CalculateProfitLoss()
        {
            ProfitLoss = (this.SellPrice - this.BuyPrice) * this.Shares;
        }

        public void CalculateChangePercentage()
        {
            ChangePercentage = this.ProfitLoss / 100;
        }
    }
}
