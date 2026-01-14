using Core.Domain.Dto;
using Core.Domain.Interfaces;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public class PortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public void SavePortfolio(Portfolio portfolio)
        {
            PortfolioDTO portfolioDTO = new PortfolioDTO(portfolio);
            _portfolioRepository.SavePortfolio(portfolioDTO);
        }

        public List<Portfolio> GetAllPortfolio()
        {
            List<Portfolio> portfolioList = new List<Portfolio>();
            foreach (PortfolioDTO portfolioDTO in _portfolioRepository.GetAllPortfolios())
            {
                Portfolio portfolio = new Portfolio(portfolioDTO);
                portfolioList.Add(portfolio);
            }
            return portfolioList;
        }
    }
}
