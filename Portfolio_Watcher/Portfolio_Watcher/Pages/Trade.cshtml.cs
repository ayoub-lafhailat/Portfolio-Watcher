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
        public TradeCreate TradeCreate { get; set; }

        public void OnGet()
        {
        }

        public void OnPost() 
        {
            Console.WriteLine("kanker");
            Trade trade = new Trade(TradeCreate.Symbol, TradeCreate.Price, TradeCreate.Shares);
            TradeCreateService tradeCreate = new TradeCreateService(trade);
        }
    }
}
