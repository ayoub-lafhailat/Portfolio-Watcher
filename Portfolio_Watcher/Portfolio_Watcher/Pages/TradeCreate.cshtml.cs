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
        private readonly ITradeRepository _tradeRepository;
        [BindProperty]
        public TradeView TradeView { get; set; }

        public void OnGet()
        {

        }

        public void OnPost() 
        {
            //ToDo: modelstate valid check toevoegen

            //hier maak ik een trade domein model met de viewmodel
            //dan roep ik een domein service en geef ik de domein model mee
            Trade trade = new Trade(TradeView.Symbol, TradeView.BuyPrice, TradeView.SellPrice, TradeView.Shares);

            ITradeRepository repo = new TradeRepo();   // direct hier maken
            TradeService tradeService = new TradeService(repo);

            //ToDo: waarom moet deze constructor een trade argument hebben?
            tradeService.SaveTrade(trade);

        }
    }
}