using Core.Domain.Interfaces;
using Core.Domain.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public class TradeService
    {
        private readonly ITradeRepository _tradeRepository;

        public TradeService(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public List<Trade> GetAllTrades()
        {
            List<Trade> trades = _tradeRepository.GetAllTrades();
            return trades;

        }

        public List<Trade> GetAllTradesSorted(ITradeSort tradeSort)
        {
            List<Trade> result = _tradeRepository.GetAllTrades();
            return tradeSort.SortTrades(result);
        }

        //ToDo: voeg getalltrades functie toe - om trades uit DAL op te halen

        //ToDo: hier maak je de objecten van de trade models

        //ToDo: voeg savetrade functie toe - om het domeinmodel te sturen naar de dal zodat die in de db gezet wordt. dan is die opgeslagen

        //ToDo: savetrade updaten zodat die ipv de data model en repository maakt. Dit allemaal 
        public void SaveTrade(Trade trade)
        {
            _tradeRepository.SaveTrade(trade);
        }

        //ToDo: update trade functie maken
        //public void UpdateTrade(Trade trade)
        //{

        //}

        // ToDo: encapsulation - input validatie
        // ToDo: exception handling
        // ToDo: deze methode hoort in trademodel

    }
}