using Core.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio_Watcher.Models
{
    public class TradeView
    {
        public int? Id { get; set; }
        //ToDo: je kan in de constructor trade meegeven die kan je in de constructor mappen naar viewmodel en dan die in je view laten zien
        //ToDo: hier moet je client side validatie toevoegen
        [Required(ErrorMessage = "Please enter a Symbol")]
        public string Symbol { get; set; }

        [Required(ErrorMessage = "Please enter a Price")]
        public double BuyPrice { get; set; }

        [Required(ErrorMessage = "Please enter a Price")]
        public double SellPrice { get; set; }

        [Required(ErrorMessage = "Please enter amount of Shares")]
        public int Shares { get; set; }

        //deze hoeft geen public set want wordt niet door user ingevuld
        public double PositionSize { get; private set; }
        public double ProfitLoss { get; private set; }
        public double ChangePercentage { get; private set; }

        public TradeView() { }

        //user input constructor
        public TradeView(string symbol, double buyPrice, double sellPrice, int shares)
        {
            Symbol = symbol;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Shares = shares;
        }

        //ToDo: get constructor, onnodige mapping?
        public TradeView(Trade trade)
        {
            Id = trade.Id;
            Symbol = trade.Symbol;
            BuyPrice = trade.BuyPrice;
            SellPrice = trade.SellPrice;
            Shares = trade.Shares;
            PositionSize = trade.PositionSize;
            ProfitLoss = trade.ProfitLoss;
            ChangePercentage = trade.ChangePercentage;
        }


    }
}