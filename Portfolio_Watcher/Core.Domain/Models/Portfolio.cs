using Core.Domain.Dto;
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
        public int? PortfolioId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Balance { get; private set; }
        public double Equity { get; private set; }
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
            //Equity = CalculateEquity();

        }

        //get portfolio
        public Portfolio(PortfolioDTO portfolioDTO)
        {
            PortfolioId = portfolioDTO.PortfolioId;
            Name = portfolioDTO.Name;
            Description = portfolioDTO.Description;
            //User = portfolioDTO.User;

            //ToDo: balance en equity zijn waardes die we willen uitrekenen aan de hand van de trades

        }

        //set portfolio
        public Portfolio(string name, string description)
        {
            Name = name;
            Description = description;
            //hier doe je functie voor alle geslote trades balance

            //hier moet getalltradesforportfolio functie.
            //Equity = CalculateEquity();

        }


        //User = portfolioDTO.User;

        //ToDo: balance en equity zijn waardes die we willen uitrekenen aan de hand van de trades

        //ToDo: maak een getalltradesforportfolio functie,

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