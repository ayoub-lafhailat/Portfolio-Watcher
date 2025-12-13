using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface ITradeSort
    {
        List<Trade> SortTrades(List<Trade> trade);
    }
}
