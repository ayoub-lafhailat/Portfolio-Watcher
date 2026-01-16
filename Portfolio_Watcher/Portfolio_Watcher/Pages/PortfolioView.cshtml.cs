using Core.Domain.Models;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Portfolio_Watcher.Pages
{
    public class PortfolioViewModel : PageModel
    {
        public List<Portfolio> Portfolios { get; private set; } = new();

        private readonly PortfolioService _portfolioService;

        public PortfolioViewModel(PortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IActionResult OnGet()
        {
            try
            {
                Portfolios = _portfolioService.GetAllPortfolio();
                return Page();
            }
            catch (Exception)
            {
                TempData["Error"] = "Er ging iets mis bij het ophalen van portfolio's.";
                return RedirectToPage("/Error");
            }
        }
    }
}
