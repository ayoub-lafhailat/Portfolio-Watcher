using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Dto
{
    public class PortfolioDTO
    {
        public int? PortfolioId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Equity { get; private set; }
        public double Balance { get; private set; }
        public User User { get; private set; }

        //get constructor
        public PortfolioDTO(int portfolioId, string name, string description) 
        {
            PortfolioId = portfolioId;
            Name = name;
            Description = description;
        }   
        //set constructor
        public PortfolioDTO(Portfolio portfolio)
        {
            Name = portfolio.Name;
            Description = portfolio.Description;
        }
    }
}
