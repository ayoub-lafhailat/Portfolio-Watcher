using Core.Domain.Interfaces;
using Core.Domain.Models;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Portfolio_Watcher.Pages
{
    public class PortfolioViewModel : PageModel
    {
        public List<Portfolio> Portfolios { get; set; }

        private readonly PortfolioService _portfolioService;

        public PortfolioViewModel(PortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }
        public void OnGet()
        {
            Portfolios = _portfolioService.GetAllPortfolio(); 
        }
    }
}
