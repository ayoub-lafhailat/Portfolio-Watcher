using Core.Domain.Models;
using Core.Data.Dto;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data.Dto.Core.Domain.Models;
using Core.Data.Repository;

namespace Core.Domain.Services
{
    public class TradeCreateService
    {

        public TradeCreateService()
        {

        }

        public TradeCreateService(Trade trade) 
        {

        }

        public List<Trade> GetAllTrades()
        {
            List<Trade> result = new List<Trade>();

            TradeRepo tradeRepo = new TradeRepo();
            List<TradeDTO> listTradeDTO = tradeRepo.GetAll();
            foreach (TradeDTO var in listTradeDTO) 
            {
                Trade trade = new Trade(var.Id.Value, var.Symbol, var.Price, var.Shares);
                result.Add(trade);
            }
            return result;

        }

        //ToDo: voeg getalltrades functie toe - om trades uit DAL op te halen

        //ToDo: hier maak je de objecten van de trade models

        //ToDo: voeg savetrade functie toe - om het domeinmodel te sturen naar de dal zodat die in de db gezet wordt. dan is die opgeslagen
        public void SaveTrade(Trade trade)
        {
            //nu heb je een dto object
            TradeDTO tradeDTO = new TradeDTO(trade.Symbol, trade.Price, trade.Shares);
            TradeRepo tradeRepo = new TradeRepo();
            tradeRepo.Add(tradeDTO);
            
        }
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
<<<<<<< Updated upstream
=======

        // ToDo: encapsulation - input validatie
        // ToDo: exception handling
        public double CalculatePositionSize(Trade trade)
        {
            if (trade.Symbol.Length < 3 || trade.Symbol.Length > 5)
            {
                throw new ArgumentException("Symbol moet tussen de 3 en 5 tekens lang zijn.", nameof(trade));
            }
=======
>>>>>>> Stashed changes

        // ToDo: encapsulation + input validatie
        public double CalculatePositionSize(Trade trade)
        {
<<<<<<< Updated upstream
=======
>>>>>>> development
>>>>>>> Stashed changes
            //input validatie shares en price mag niet kleiner gelijk zijn aan 0
            if (trade.Shares <= 0)
            {
                throw new ArgumentException("Shares moeten groter dan 0 zijn.", nameof(trade));
            }

            if (trade.Price <= 0)
            {
                throw new ArgumentException("Price moet groter dan 0 zijn.", nameof(trade));
            }

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
            //ToDo: wat wordt er dan met die exception gedaan als die eenmaal er is. Daar ook iets voor maken user mag niet naar error page.

=======
>>>>>>> development
>>>>>>> Stashed changes
            //logica
            double positionSize = trade.Shares * trade.Price;
            return positionSize;
        }
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
>>>>>>> Stashed changes
=======
>>>>>>> development
>>>>>>> Stashed changes
    }
}

//hier vul je al je logica van je UC-01 in, het maken van een trade.
//hier maak je dan later ook weer de unit testen op.
//hier het trade object maken?  
//dan zit het trade object in je domein laag
//en kan je het in de domein laag gebruiken
//je kan het altijd sturen naar de view en dal
//dit zorgt ervoor dat als je ooit je view of dal wijzigt
//de bll blijft werken