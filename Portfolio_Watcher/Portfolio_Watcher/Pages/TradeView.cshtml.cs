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

            foreach (Trade t in listTrades)
            {
                TradeCreate tradeCreate = new TradeCreate(
                    t.Id!.Value,
                    t.Symbol,
                    t.Price,
                    t.Shares
                );

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
