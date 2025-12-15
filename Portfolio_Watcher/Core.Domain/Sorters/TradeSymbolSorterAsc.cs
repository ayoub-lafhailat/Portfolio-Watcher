using Core.Domain.Interfaces;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Sorters
{
    public class TradeSymbolSorterAsc : ITradeSort
    {
        public List<Trade> SortTrades(List<Trade> trades)
        {
            List<Trade> result = trades.OrderBy(trade => trade.Symbol).ToList();
            return result;
        }
    }
}
