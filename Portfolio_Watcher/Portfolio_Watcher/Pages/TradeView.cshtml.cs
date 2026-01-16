using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using Core.Domain.Models;
using Core.Domain.Services;
using Core.Domain.Sorters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Portfolio_Watcher.Pages
{
    public class TradeViewModel : PageModel
    {
        public int PortfolioId { get; private set; }
        public List<Trade> Trades { get; private set; } = new();

        private readonly TradeService _tradeService;

        public TradeViewModel(TradeService tradeService)
        {
            _tradeService = tradeService;
        }

        public IActionResult OnGet(int portfolioId)
        {
            PortfolioId = portfolioId;

            try
            {
                // zoals je al had: service haalt trades op, view filtert (of service doet dat)
                Trades = _tradeService.GetAllTrades()
                    .Where(t => t.Portfolio.PortfolioId == PortfolioId)
                    .ToList();

                return Page();
            }
            catch (TradeServiceException)
            {
                TempData["Error"] = "Er ging iets mis bij het ophalen van trades.";
                return RedirectToPage("/Error");
            }
        }

        public IActionResult OnPostSorted(int portfolioId, EnumSorters sorter)
        {
            PortfolioId = portfolioId;

            try
            {
                Trades = _tradeService.GetAllTrades()
                    .Where(t => t.Portfolio.PortfolioId == PortfolioId)
                    .ToList();

                ITradeSort tradeSort = sorter switch
                {
                    EnumSorters.Symbol => new TradeSymbolSorterAsc(),
                    EnumSorters.PositionSize => new TradePositionSizeSorter(),
                    _ => new TradePositionSizeSorter()
                };

                Trades = tradeSort.SortTrades(Trades);
                return Page();
            }
            catch (TradeServiceException)
            {
                TempData["Error"] = "Er ging iets mis bij het ophalen van trades.";
                return RedirectToPage("/Error");
            }
        }
    }
}
