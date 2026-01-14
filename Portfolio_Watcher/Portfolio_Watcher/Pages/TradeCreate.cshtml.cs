using Core.Data.Repository;
using Core.Domain.Interfaces;
using Core.Domain.Models;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio_Watcher.Models;

namespace Portfolio_Watcher.Pages
{
    public class TradeModel : PageModel
    {
        [BindProperty]
        public TradeView TradeView { get; set; }

        private readonly TradeService _tradeService;

        public TradeModel(TradeService tradeService)
        {
            _tradeService = tradeService;
        }

        public void OnGet()
        {

        }

        public void OnPost() 
        {
            //ToDo: modelstate valid check toevoegen

            //hier maak ik een trade domein model met de viewmodel
            //dan roep ik een domein service en geef ik de domein model mee

            Trade trade = new Trade(TradeView.Symbol, TradeView.BuyPrice, TradeView.SellPrice, TradeView.Shares);
            _tradeService.SaveTrade(trade);

        }
    }
}