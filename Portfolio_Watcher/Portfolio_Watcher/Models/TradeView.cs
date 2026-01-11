using System.ComponentModel.DataAnnotations;

namespace Portfolio_Watcher.Models
{
    public class TradeView
    {
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
        public double PositionSize { get; set; }

        public TradeView()
        {
        }

        public TradeView(string symbol, double buyPrice, double sellPrice, int shares)
        {
            Symbol = symbol;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Shares = shares;
        }

    public TradeView(int id, string symbol, double buyPrice, double sellPrice, int shares)
        {
            Symbol = symbol;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Shares = shares;
        }


    }
}