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
        public List<TradeView> Trades { get; private set; } = new();
        public List<TradeView> ListTrades { get; private set; } = new();
        public readonly ITradeRepository _tradeRepository;

        private List<TradeView> GetAllTrades()
        {
            var result = new List<TradeView>();

            TradeService tradeCreateService = new TradeService(_tradeRepository);
            List<Trade> listTrades = tradeCreateService.GetAllTrades();

            foreach (Trade trade in listTrades)
            {
                TradeView tradeCreate = new TradeView(
                    //id hoeft/mag niet ingevuld te worden?
                    trade.Id!.Value,
                    trade.Symbol,
                    trade.BuyPrice,
                    trade.SellPrice,
                    trade.Shares
                );

                tradeCreate.PositionSize = tradeCreateService.CalculatePositionSize(trade);

                result.Add(tradeCreate);
                ListTrades.Add(tradeCreate);
            }

            return result;
        }



        public IActionResult OnPostSort()
        {
            var result = new List<TradeView>();

            //ToDo: list add alle trades met de getallfunctie van domein want je moet domein trades hebben voor je sort functie.
            TradeSymbolSorterAsc tradeSymbolSorterAsc = new TradeSymbolSorterAsc();
            TradeService tradeService = new TradeService(_tradeRepository);

            List<Trade> listTrades = tradeSymbolSorterAsc.SortTrades(tradeService.GetAllTrades());
            TradeService tradeCreateService = new TradeService(_tradeRepository);

            foreach (Trade trade in listTrades)
            {
                TradeView tradeCreate = new TradeView(
                    //id hoeft/mag niet ingevuld te worden?
                    trade.Id!.Value,
                    trade.Symbol,
                    trade.BuyPrice,
                    trade.SellPrice,
                    trade.Shares
                );

                tradeCreate.PositionSize = tradeCreateService.CalculatePositionSize(trade);

                result.Add(tradeCreate);
                ListTrades.Add(tradeCreate);

            }
            Trades = ListTrades;
            return Page();
        }




        public void OnGet()
        {
            Trades = GetAllTrades();

            

        }
    }
}
