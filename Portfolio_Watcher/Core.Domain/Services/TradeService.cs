using Core.Data.Exceptions;
using Core.Domain.Exceptions;
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
            try
            {
                foreach (var tradeDto in tradeDtoList)
                {
                    //ToDo: dit klopt niet tradeservice is niet verantwoordelijk voor het maken van de portfolios, method moet een portfolio en symbool krijgen, die in de verantwoordelijke class/service is gemaakt.
                    Portfolio portfolio = _portfolioService.GetPortfolioById(tradeDto.PortfolioId);
                    Symbol symbol = _symbolService.GetSymbolById(tradeDto.SymbolId);
                    Trade trade = new Trade(tradeDto, symbol, portfolio);
                    tradeList.Add(trade);
                }
            }
            //Omdat dit een traderepositoryexception is weet je dat deze catch er iets in de infra laag fout is gegaan.
            catch (TradeRepositoryException exception)
            {
                throw new TradeServiceException("Error retrieving the trades", exception);
            }
            return tradeList;

        }

        public List<Trade> GetAllTradesSorted(ITradeSort tradeSort)
        {
            return tradeSort.SortTrades(GetAllTrades());
        }


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
    }
}