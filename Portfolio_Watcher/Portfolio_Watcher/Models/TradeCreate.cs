using System.ComponentModel.DataAnnotations;

namespace Portfolio_Watcher.Models
{
    //ToDo: deze 
    public class TradeCreate
    {
        //ToDo: hier moet je client side validatie toevoegen
        [Required(ErrorMessage = "Please enter a Symbol")]
        public string Symbol { get; set; }

        [Required(ErrorMessage = "Please enter a Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please enter amount of Shares")]
        public int Shares { get; set; }

    

    public TradeCreate(string symbol, double price, int shares)
        {
            Symbol = symbol;
            Price = price;
            Shares = shares;
        }

    public TradeCreate(int id, string symbol, double price, int shares)
        {
            Symbol = symbol;
            Price = price;
            Shares = shares;
        }


    }
}