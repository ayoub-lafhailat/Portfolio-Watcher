using Core.Data.Repository;
using Core.Domain.Interfaces;
using Core.Domain.Models;
using Core.Domain.Services;
using Core.Domain.Sorters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio_Watcher.Models;
using System.Linq.Expressions;

namespace Portfolio_Watcher.Pages
{
    //ToDo: eerst converteren van trade naar tradeview voordat je weergeeft in ui geen toegevoegde waarde? Extra code voor niks?
    public class TradeViewModel : PageModel
    {
        public List<Trade> Trades { get; private set; }
        public List<TradeView> ListTrades { get; private set; }

        private readonly TradeRepo tradeRepo;
        private readonly TradeService tradeService;

        
        public TradeViewModel()
        {
            tradeRepo = new TradeRepo();
            tradeService = new TradeService(tradeRepo);
        }
        public void OnGet()
        {

            //ToDo: omzetten van trade naar tradeviewmodel in design en keuzes document opschrijven wat je eerst had, waarom je niet goed vond, wat overweging was, uiteindelijke keuze met uitleg


            Trades = tradeService.GetAllTrades();
        }

        public IActionResult OnPostSorted(EnumSorters sorter)
        {
            ITradeSort tradeSort;
            switch (sorter)
            {
                case EnumSorters.Symbol:
                    tradeSort = new TradeSymbolSorterAsc();
                    
                    break;
                case EnumSorters.PositionSize:
                    tradeSort = new TradePositionSizeSorter();
                    break;
                //case EnumSorters.Date:
                //    tradeSort = new TradeDateSorterAsc();
                //    break;
                default:
                    // code block
                    tradeSort = new TradePositionSizeSorter();
                    break;
            }
            //ToDo: overweging maken of kiezen welke sorter gebruikt worden in ui of domain en aparte class van maken srp unit test

            Trades = tradeService.GetAllTradesSorted(tradeSort);
            return Page();
        }
    }
}