using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    //internal?
    public class Symbol
    {
        public int SymbolId { get; private set; }
        public string Name { get; private set; }
        public string Ticker { get; private set; }
        public double CurrentPrice { get; private set; }
        public List<double> PriceHistory { get; private set; }
        public int Volume {  get; private set; }
    }

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
