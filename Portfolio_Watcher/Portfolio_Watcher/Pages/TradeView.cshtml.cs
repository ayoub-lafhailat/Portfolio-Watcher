using Core.Domain.Models;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio_Watcher.Models;

namespace Portfolio_Watcher.Pages
{
    public class TradeViewModel : PageModel
    {
        public List<TradeCreate> Trades { get; private set; } = new();

        private List<TradeCreate> GetAllTrades()
        {
            var result = new List<TradeCreate>();

            TradeCreateService tradeCreateService = new TradeCreateService();
            List<Trade> listTrades = tradeCreateService.GetAllTrades();

            foreach (Trade trade in listTrades)
            {
                TradeCreate tradeCreate = new TradeCreate(
                    //id hoeft/mag niet ingevuld te worden?
                    trade.Id!.Value,
                    trade.Symbol,
                    trade.Price,
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
