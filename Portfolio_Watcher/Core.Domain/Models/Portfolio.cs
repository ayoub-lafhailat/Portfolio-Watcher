using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    public class Portfolio
    {
        public int PortfolioId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Equity { get; private set; }
        public double Balance { get; private set; }
        public User User { get; private set; }

        //ToDo: validatie toevoegen
        public Portfolio(int portfolioId, string name, string description, double equity, double balance, User user)
        {
            PortfolioId = portfolioId;
            Name = name;
            Description = description;
            Equity = equity;
            Balance = balance;
            User = user;
        }
        
        private void CalculateEquity(List<Trade> trades)
        {
            double Equity = 0;
            foreach (Trade trade in trades) 
            {
             double profit = trade.SellPrice - trade.BuyPrice;
                Equity += profit;
            }

        }
    }
}