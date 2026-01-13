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
        List<TradeDTO> GetAllTrades();

        void SaveTrade(TradeDTO tradeDto);

        //ToDo: update trade functie maken
        //void UpdateTrade(Trade trade);

    }
}
