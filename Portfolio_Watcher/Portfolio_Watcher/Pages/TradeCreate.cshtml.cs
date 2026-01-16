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
        public TradeView TradeView { get; set; }

        private readonly TradeService _tradeService;
        private readonly PortfolioService _portfolioService;
        private readonly SymbolService _symbolService;
        private readonly ILogger<TradeModel> _logger;

        public TradeModel(
            TradeService tradeService,
            PortfolioService portfolioService,
            SymbolService symbolService,
            ILogger<TradeModel> logger)
        {
            _tradeService = tradeService;
            _portfolioService = portfolioService;
            _symbolService = symbolService;
            _logger = logger;
        }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                Portfolio portfolio = _portfolioService.GetPortfolioById(TradeView.PortfolioId);
                if (portfolio == null)
                    throw new TradeServiceFixableException("PortfolioId bestaat niet. Kies een geldig PortfolioId.");

                Symbol symbol = _symbolService.GetSymbolById(TradeView.SymbolId);
                if (symbol == null)
                    throw new TradeServiceFixableException("SymbolId bestaat niet. Kies een geldig SymbolId.");

                Trade trade = new Trade(symbol, TradeView.BuyPrice, TradeView.SellPrice, TradeView.Shares, portfolio);

                _tradeService.SaveTrade(trade);

                TempData["Success"] = "Trade opgeslagen.";
                return RedirectToPage("/Trades");
            }
            catch (TradeModelException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
            catch (TradeServiceFixableException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
            catch (TradeServiceException ex)
            {
                _logger.LogError(ex, ex.Message);
                TempData["Error"] = "Er ging iets mis. Probeer later opnieuw.";
                return RedirectToPage("/Error");
            }
        }
    }
}
