using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public class TradeCreateService
    {
        public TradeCreateService(Trade trade) 
        {
            //hier vul je al je logica van je UC-01 in, het maken van een trade.
            //hier maak je dan later ook weer de unit testen op.
            //hier het trade object maken?
            //dan zit het trade object in je domein laag
            //en kan je het in de domein laag gebruiken
            //je kan het altijd sturen naar de view en dal
            //dit zorgt ervoor dat als je ooit je view of dal wijzigt
            //de bll blijft werken

            Console.WriteLine(trade.Symbol);
            Console.WriteLine(trade.Shares);
            Console.WriteLine(trade.Price);

        }
    }
}  