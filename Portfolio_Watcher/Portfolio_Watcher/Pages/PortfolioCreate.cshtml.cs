using Core.Domain.Exceptions;
using Core.Domain.Models;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio_Watcher.Models;

namespace Portfolio_Watcher.Pages
{
    public class PortfolioCreateModel : PageModel
    {
        [BindProperty]
        public PortfolioModel PortfolioModel { get; set; } = new();

        private readonly PortfolioService _portfolioService;

        public PortfolioCreateModel(PortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                var portfolio = new Portfolio(PortfolioModel.Name, PortfolioModel.Description);
                _portfolioService.SavePortfolio(portfolio);

                return RedirectToPage("/PortfolioView");
            }
            catch (Exception ex) // fixable: user kan dit oplossen
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}
