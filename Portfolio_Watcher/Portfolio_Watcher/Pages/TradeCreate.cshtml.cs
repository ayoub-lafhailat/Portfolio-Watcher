using Core.Domain.Exceptions;
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
        public TradeView TradeView { get; set; } = new();

        private readonly TradeService _tradeService;
        private readonly PortfolioService _portfolioService;
        private readonly SymbolService _symbolService;

        public TradeModel(
            TradeService tradeService,
            PortfolioService portfolioService,
            SymbolService symbolService)
        {
            _tradeService = tradeService;
            _portfolioService = portfolioService;
            _symbolService = symbolService;
        }

        public void OnGet(int portfolioId)
        {
            TradeView.PortfolioId = portfolioId;
        }

        public IActionResult OnPost(int portfolioId)
        {
            TradeView.PortfolioId = portfolioId;

            if (!ModelState.IsValid)
                return Page();

            try
            {
                var portfolio = _portfolioService.GetPortfolioById(TradeView.PortfolioId);
                var symbol = _symbolService.GetSymbolById(TradeView.SymbolId);

                var trade = new Trade(symbol, TradeView.BuyPrice, TradeView.SellPrice, TradeView.Shares, portfolio);
                _tradeService.SaveTrade(trade);

                return RedirectToPage("/TradeView", new { portfolioId = TradeView.PortfolioId });
            }
            catch (TradeModelException ex) // fixable
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
            catch (TradeServiceFixableException ex) // fixable
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
            catch (TradeServiceException) // niet-fixable
            {
                TempData["Error"] = "Er ging iets mis bij het opslaan van de trade.";
                return RedirectToPage("/Error");
            }
        }
    }
}
