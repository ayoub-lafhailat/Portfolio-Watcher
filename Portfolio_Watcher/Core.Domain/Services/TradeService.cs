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
    //ToDo: veel domain mag op internal
    public class TradeService
    {
        //ToDo: depdency van domein naar data - switchen naar data naar domein met interface, in design en keuzes document opschrijven wat je eerst had, waarom je niet goed vond, wat overweging was, uiteindelijke keuze met uitleg

        private readonly ITradeRepository _tradeRepository;
        private readonly SymbolService _symbolService;
        private readonly PortfolioService _portfolioService;

        public TradeService(ITradeRepository tradeRepository, PortfolioService portfolioService, SymbolService symbolService)
        {
            _tradeRepository = tradeRepository;
            _symbolService = symbolService;
            _portfolioService = portfolioService;
        }
        public TradeService(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;

        }

        public List<Trade> GetAllTrades()
        {
            List<TradeDTO> tradeDtoList = _tradeRepository.GetAllTrades();

            List<Trade> tradeList = new List<Trade>();
            foreach (var tradeDto in tradeDtoList)
            {
                Portfolio portfolio = _portfolioService.GetPortfolioById(tradeDto.PortfolioId);
                Symbol symbol = _symbolService.GetSymbolById(tradeDto.SymbolId);   
                Trade trade = new Trade(tradeDto, symbol, portfolio);
                tradeList.Add(trade);
            }
            return tradeList;

        }

        //ToDo: depedency inversion  in design en keuzes document opschrijven wat je eerst had, waarom je niet goed vond, wat overweging was, uiteindelijke keuze met uitleg


        //Je wilt toch niet sorteren op de dto je wilt sorteren op de trade
        public List<Trade> GetAllTradesSorted(ITradeSort tradeSort)
        {
            return tradeSort.SortTrades(GetAllTrades());
        }

        //ToDo: voeg getalltrades functie toe - om trades uit DAL op te halen

        //ToDo: hier maak je de objecten van de trade models

        //ToDo: voeg savetrade functie toe - om het domeinmodel te sturen naar de dal zodat die in de db gezet wordt. dan is die opgeslagen

        //ToDo: savetrade updaten zodat die ipv de data model en repository maakt. Dit allemaal 
        public void SaveTrade(Trade trade)
        {
            TradeDTO tradeDto = new TradeDTO(trade);
            _tradeRepository.SaveTrade(tradeDto);
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