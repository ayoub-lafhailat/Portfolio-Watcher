using Core.Data.Repository;
using Core.Domain.Interfaces;
using Core.Domain.Models;
using Core.Domain.Services;
using Core.Domain.Sorters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio_Watcher.Models;

namespace Portfolio_Watcher.Pages
{
    //ToDo: eerst converteren van trade naar tradeview voordat je weergeeft in ui geen toegevoegde waarde? Extra code voor niks?
    public class TradeViewModel : PageModel
    {
        public List<Trade> Trades { get; private set; } = new();
        public List<TradeView> ListTrades { get; private set; } = new();

        public void OnGet()
        {
            TradeRepo repo = new TradeRepo();
            TradeService tradeService = new TradeService(repo);
            Trades = tradeService.GetAllTrades();
        }
    }
}
