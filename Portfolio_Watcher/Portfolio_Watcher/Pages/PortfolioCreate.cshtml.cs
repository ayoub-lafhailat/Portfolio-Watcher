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
        public void OnGet()
        {

        }

        public void OnPost()
        { 

        }

    }
}
