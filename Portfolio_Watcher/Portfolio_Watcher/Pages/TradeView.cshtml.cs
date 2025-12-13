using Core.Domain.Models;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio_Watcher.Models;

namespace Portfolio_Watcher.Pages
{
    public class TradeViewModel : PageModel
    {
        public List<TradeView> Trades { get; private set; } = new();

        private List<TradeView> GetAllTrades()
        {
            var result = new List<TradeView>();

            TradeService tradeCreateService = new TradeService();
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
            }

            return result;
        }

        public void OnGet()
        {
            Trades = GetAllTrades();
            

        }
    }
}
