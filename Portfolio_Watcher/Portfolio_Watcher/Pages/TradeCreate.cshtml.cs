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

            //ToDo: ipv met new alle classes te instantieren. Kan je met builder services gewoon de dependency injection vooraf al in program.cs defineren. Als je dan een field van die class in de class hebt. Kan je die overal gebruiken omdat je de benodigde dependency injection al hebt gedefineerd. En program.cs het in de setup al maakt.
            //ToDo: in design en keuzes document opschrijven wat je eerst had, waarom je niet goed vond, wat overweging was, uiteindelijke keuze met uitleg
            Trade trade = new Trade(TradeView.Symbol, TradeView.BuyPrice, TradeView.SellPrice, TradeView.Shares);

            ITradeRepository repo = new TradeRepo();   // direct hier maken

            //ToDo: tradeservice moet als arg _tradeRepository field meekrijgen?
            TradeService tradeService = new TradeService(repo);

            //ToDo: waarom moet deze constructor een trade argument hebben?
            tradeService.SaveTrade(trade);



        }
    }
}