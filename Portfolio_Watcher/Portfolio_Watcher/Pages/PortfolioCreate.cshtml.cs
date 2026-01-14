using Core.Data.Repository;
using Core.Domain.Interfaces;
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
        public PortfolioModel PortfolioModel { get; set; }

        private readonly PortfolioService _portfolioService;

        public PortfolioCreateModel(PortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public void OnPost()
        {
            Portfolio portfolio = new Portfolio(PortfolioModel.Name, PortfolioModel.Description);
            _portfolioService.SavePortfolio(portfolio);
        }

    }
}
