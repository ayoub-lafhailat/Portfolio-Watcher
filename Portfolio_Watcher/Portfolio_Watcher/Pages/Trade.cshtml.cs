using Core.Domain.Models;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio_Watcher.Models;

//ToDo: de input van de page binden aan mijn viewmodel
namespace Portfolio_Watcher.Pages
{
    public class TradeModel : PageModel
    {
        [BindProperty]
        public TradeCreate TradeCreate { get; set; }

        public void OnGet()
        {

        }

        public void OnPost() 
        {
            //ToDo: modelstate valid check toevoegen

            //hier maak ik een trade domein model met de viewmodel
            //dan roep ik een domein service en geef ik de domein model mee
            Trade trade = new Trade(TradeCreate.Symbol, TradeCreate.Price, TradeCreate.Shares);
            TradeCreateService tradeCreate = new TradeCreateService(trade);
            tradeCreate.SaveTrade(trade);

        }
    }
}

//TradeRepo tradeRepo = new TradeRepo();
//tradeRepo.Add(trade);