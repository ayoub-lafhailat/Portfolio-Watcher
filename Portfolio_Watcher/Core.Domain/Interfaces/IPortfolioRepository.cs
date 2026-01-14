using Core.Domain.Dto;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface IPortfolioRepository
    {
        List<Trade> GetTradesForPortfolio(Trade trade);
        List<Symbol> GetSymbolsForPortfolio(Trade trade);
        List<PortfolioDTO> GetAllPortfolios();
        void SavePortfolio(PortfolioDTO portfolioDTO);
        PortfolioDTO GetPortfolioById(int id);

    }
}
