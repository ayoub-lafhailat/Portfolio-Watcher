using Core.Data.Connection;
using Core.Data.Dto.Core.Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Interfaces;
using Core.Domain.Models;


//ToDo: goed kijken welke data types je in de db selecteert price staat erin als float
namespace Core.Data.Repository
{
    //ToDo: eerst converteren naar dtos mag dat is goede reden want in je domain trade model doe je nog extra operaties jou dto is niet hetzelfde als domain model want je doet nog die calculate methods
    public class TradeRepo : ITradeRepository
    { 
        //ToDo: exception handling

        //ToDo: moet je eerst DTO's maken voordat je ze in de DB zet?

        //ToDo: connectie string in de constructor meegeven elke repo heeft een connectie nodig
        public TradeRepo() { }

        //deze methodes returnen nou geldige waardes voor mijn service. Deze kan ik met depedency injection gebruiken om services aan te roepen
        public List<Trade> GetAllTrades()
        {
            //alleen checken of connectie open is anders openen.
            DBConnection.EnsureOpen();

            const string sql = "SELECT Id, Symbol, BuyPrice, SellPrice, Shares FROM Trade;";
            //using is een ingebouwde c# functie die iets gebruikt, en nadat die er klaar mee is disposed die van de var.
            //dit is voor je cmd handig omdat je eigenlijk je connectie in een var zet en als je klaar bent met de connectie dispose je hem
            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            using var reader = cmd.ExecuteReader();

            var items = new List<Trade>();
            while (reader.Read())
            {
                items.Add(new Trade(
                    reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("Symbol")),
                    reader.GetDouble(reader.GetOrdinal("BuyPrice")),
                    reader.GetDouble(reader.GetOrdinal("SellPrice")),
                    reader.GetInt32(reader.GetOrdinal("Shares"))
                ));
            }
            return items;
        }

        public void SaveTrade(Trade trade)
        {
            DBConnection.EnsureOpen();

            const string sql = @"
            INSERT INTO Trade (Symbol, BuyPrice, SellPrice, Shares)
            VALUES (@symbol, @buyPrice, @sellPrice, @shares);
            ";

            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            cmd.Parameters.Add(new SqlParameter("@symbol", SqlDbType.NVarChar, 200) { Value = trade.Symbol });
            cmd.Parameters.Add(new SqlParameter("@buyPrice", SqlDbType.Float) { Value = trade.BuyPrice });
            cmd.Parameters.Add(new SqlParameter("@sellPrice", SqlDbType.Float) { Value = trade.SellPrice });
            cmd.Parameters.Add(new SqlParameter("@shares", SqlDbType.Int) { Value = trade.Shares });

            var idObj = cmd.ExecuteScalar();
        }

        //ToDo: update trade functie maken
        //public void UpdateTrade(TradeDTO tradeDTO)
        //{

        //}
    }
}
