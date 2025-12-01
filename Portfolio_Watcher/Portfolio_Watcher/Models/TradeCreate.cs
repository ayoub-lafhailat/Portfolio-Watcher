using System.ComponentModel.DataAnnotations;

namespace Portfolio_Watcher.Models
{
    public class TradeCreate
    {
        //hier moet je client side validatie toevoegen
        [Required(ErrorMessage = "Please enter a Symbol")]
        public string Symbol { get; set; }

        [Required(ErrorMessage = "Please enter a Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please enter amount of Shares")]
        public int Shares { get; set; }

    }
}
