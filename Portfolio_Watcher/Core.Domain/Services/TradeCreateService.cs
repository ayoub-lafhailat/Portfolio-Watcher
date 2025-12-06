using Core.Domain.Models;
using Core.Data.Dto;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data.Dto.Core.Domain.Models;
using Core.Data.Repository;

namespace Core.Domain.Services
{
    public class TradeCreateService
    {

        public TradeCreateService()
        {

        }

        public TradeCreateService(Trade trade)
        {

        }

        public List<Trade> GetAllTrades()
        {
            List<Trade> result = new List<Trade>();

            TradeRepo tradeRepo = new TradeRepo();
            List<TradeDTO> listTradeDTO = tradeRepo.GetAll();
            foreach (TradeDTO var in listTradeDTO)
            {
                Trade trade = new Trade(var.Id.Value, var.Symbol, var.Price, var.Shares);
                result.Add(trade);
            }
            return result;

        }

        //ToDo: voeg getalltrades functie toe - om trades uit DAL op te halen

        //ToDo: hier maak je de objecten van de trade models

        //ToDo: voeg savetrade functie toe - om het domeinmodel te sturen naar de dal zodat die in de db gezet wordt. dan is die opgeslagen
        public void SaveTrade(Trade trade)
        {
            //nu heb je een dto object
            TradeDTO tradeDTO = new TradeDTO(trade.Symbol, trade.Price, trade.Shares);
            TradeRepo tradeRepo = new TradeRepo();
            tradeRepo.Add(tradeDTO);

        }

        // ToDo: encapsulation - input validatie
        // ToDo: exception handling
        public double CalculatePositionSize(Trade trade)
        {
            if (trade.Symbol.Length < 3 || trade.Symbol.Length > 5)
            {
                throw new ArgumentException("Symbol moet tussen de 3 en 5 tekens lang zijn.", nameof(trade));
            }

            if (trade.Shares <= 0)
            {
                throw new ArgumentException("Shares moeten groter dan 0 zijn.", nameof(trade));
            }

            if (trade.Price <= 0)
            {
                throw new ArgumentException("Price moet groter dan 0 zijn.", nameof(trade));
            }

            double positionSize = trade.Shares * trade.Price;
            return positionSize;
        }

    }
}