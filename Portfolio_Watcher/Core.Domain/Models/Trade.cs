using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    //Trademodel is een richmodel omdat de calculatemethodes erin alleen betrekking hebben op de trademodel en niet ergens erbuiten gebruikt hoeven te worden hanteert nog steeds SRP

    public class Trade
    {
        public int? Id { get; private set; }
        //ToDo: Symbol moet dalijk zijn eigen class worden trademodel krijgt dan zijn symbol daarvandaan.
        public string Symbol { get; private set; }
        public double BuyPrice { get; private set; }
        public double SellPrice { get; private set; }
        public int Shares { get; private set; }
        //ToDo: de calculate methodes kan je eigenlijk gewoon in de get zetten, want de get is gewoon een methode die je kan defineren.
        public double PositionSize { get; private set; }
        public double ProfitLoss { get; private set; }
        public double ChangePercentage { get; private set; }


        //ToDo: even voor werken met db alle setters public gemaakt


        //Data validatie vooral belangrijk in deze constructor
        //Omdat deze constructor wordt voor nu gebruikt voor het versturen van user input naar database
        //Dus hier is validatie het belangrijkst want dit is het meest fout gevoelig
        public Trade(string symbol, double buyPrice, double sellPrice, int shares)
        {
            // inputvalidatie
            //ToDo: deze validatie weer aanzetten
            //if (symbol.Length < 3 || symbol.Length > 5)
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

            Symbol = symbol;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Shares = shares;
        }

        public Trade(int id, string symbol, double buyPrice, double sellPrice, int shares)
        {
            Id = id;
            Symbol = symbol;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Shares = shares;
        }

        public double CalculatePositionSize()
        {
            double result = this.BuyPrice * this.Shares;
            return this.PositionSize;
        }

        public double CalculateProfitLoss()
        {
            double result = (this.SellPrice - this.BuyPrice) * this.Shares;
            return this.ProfitLoss;
        }

        public double CalculateChangePercentage()
        {
            double result = this.ProfitLoss / 100;
            return this.ChangePercentage;
        }
    }
}
