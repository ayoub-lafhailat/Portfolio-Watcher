using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface ITradeRepository
    {
        List<Trade> GetAllTrades();

        void SaveTrade(Trade trade);

        //ToDo: update trade functie maken
        //void UpdateTrade(Trade trade);

    }
}
