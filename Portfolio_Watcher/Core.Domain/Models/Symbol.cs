using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    //internal?

    //ToDo: symbool werkt niet via DTO want in real life application is dit data die je via een api bijvoorbeeld zou krijgen dus die wil je alleen valideren.
    public class Symbol
    {
        public int? SymbolId { get; private set; }
        public string Name { get; private set; }
        public string Ticker { get; private set; }
        //maak een functie met random. in de database staat een currentprice die random method doet die prijs +/- x procent. zodat de equity en balance berekend kunnen worden
        //en als je de data uit een api zou halen het nog steeds werkt.
        public double CurrentPrice { get; private set; }
        public List<double> PriceHistory { get; private set; }
        public int Volume { get; private set; }
        //ToDo: validatie toevoegen

        public Symbol(int symbolId, string name, string ticker, double currentPrice, List<double> priceHistory, int volume)
        {
            SymbolId = symbolId;
            Name = name;
            Ticker = ticker;
            CurrentPrice = currentPrice;
            PriceHistory = priceHistory;
            Volume = volume;

        }
    }
}
