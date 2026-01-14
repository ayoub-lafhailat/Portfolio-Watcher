using Core.Data.Repository;
using Core.Domain.Interfaces;
using Core.Domain.Models;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio_Watcher.Models;

namespace Portfolio_Watcher.Pages
{
    public class TradeModel : PageModel
    {
        [BindProperty]
        public TradeView TradeView { get; set; }

        private readonly TradeService _tradeService;
        private readonly PortfolioService _portfolioService;
        private readonly SymbolService _symbolService;

        public TradeModel(TradeService tradeService, PortfolioService portfolioService, SymbolService symbolService)
        {
            _tradeService = tradeService;
            _portfolioService = portfolioService;
            _symbolService = symbolService;
        }

        public void OnGet()
        {

        }

        public void OnPost() 
        {
            //ToDo: modelstate valid check toevoegen

            //hier maak ik een trade domein model met de viewmodel
            //dan roep ik een domein service en geef ik de domein model mee

            //jou trade class klopt gewoon die moet die symbol en portfolio objecten hebben
            //dus wat moet je doen je moet met een service die objecten halen op de id en maken en dan kan je die aan de trade geven
            Portfolio portfolio = _portfolioService.GetPortfolioById(TradeView.PortfolioId);
            Symbol symbol = _symbolService.GetSymbolById(TradeView.SymbolId);

            Trade trade = new Trade(symbol, TradeView.BuyPrice, TradeView.SellPrice, TradeView.Shares, portfolio);
            _tradeService.SaveTrade(trade);

        }
    }
}