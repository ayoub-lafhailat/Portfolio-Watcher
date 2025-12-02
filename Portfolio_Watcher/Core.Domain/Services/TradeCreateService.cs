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
        //
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