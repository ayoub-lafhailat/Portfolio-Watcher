using System;
using System.Collections.Generic;
using System.Diagnostics;
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

<<<<<<< Updated upstream
        //Data validatie vooral belangrijk in deze constructor
        //Omdat deze constructor wordt voor nu gebruikt voor het versturen van user input naar database
        //Dus hier is validatie het belangrijkst want dit is het meest fout gevoelig
=======
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
        //Data validatie vooral belangrijk in deze constructor
        //Omdat deze constructor wordt voor nu gebruikt voor het versturen van user input naar database
        //Dus hier is validatie het belangrijkst want dit is het meest fout gevoelig

>>>>>>> Stashed changes
=======
        //Data validatie vooral belangrijk in deze constructor
        //Omdat deze constructor wordt voor nu gebruikt voor het versturen van user input naar database
        //Dus hier is validatie het belangrijkst want dit is het meest fout gevoelig
>>>>>>> development
>>>>>>> Stashed changes
        public Trade(string symbol, double price, int shares)
        {
            // inputvalidatie
            if (symbol.Length < 3 || symbol.Length > 5)
            {
                throw new ArgumentException("Symbol moet tussen de 3 en 5 tekens lang zijn.", nameof(symbol));
            }

            if (price <= 0)
            {
                throw new ArgumentException("Price moet groter dan 0 zijn.", nameof(price));
            }

            if (shares <= 0)
            {
                throw new ArgumentException("Shares moeten groter dan 0 zijn.", nameof(shares));
            }

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
