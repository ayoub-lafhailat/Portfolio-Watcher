using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Dto
{
    public class SymbolDTO
    {
        public int? SymbolId { get; private set; }
        public string Name { get; private set; }
        public string Ticker { get; private set; }
        //maak een functie met random. in de database staat een currentprice die random method doet die prijs +/- x procent. zodat de equity en balance berekend kunnen worden
        //en als je de data uit een api zou halen het nog steeds werkt.
        public double CurrentPrice { get; private set; }
        //ToDo: validatie toevoegen

        public SymbolDTO(int symbolId, string name, string ticker, double currentPrice)
        {
            SymbolId = symbolId;
            Name = name;
            Ticker = ticker;
            CurrentPrice = currentPrice;
        }
    }
}
