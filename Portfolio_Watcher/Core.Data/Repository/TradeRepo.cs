using Core.Data.Connection;
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
    public class TradeRepo : ITradeRepository
    { 
        //ToDo: exception handling

        //ToDo: connectie string in de constructor meegeven elke repo heeft een connectie nodig
        public TradeRepo() { }

        //deze methodes returnen nou geldige waardes voor mijn service. Deze kan ik met depedency injection gebruiken om services aan te roepen
        public List<TradeDTO> GetAllTrades()
        {
            //alleen checken of connectie open is anders openen.
            DBConnection.EnsureOpen();

            const string sql = "SELECT Id, Symbol, BuyPrice, SellPrice, Shares FROM Trade;";

            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            using var reader = cmd.ExecuteReader();

            var items = new List<TradeDTO>();
            while (reader.Read())
            {
                items.Add(new TradeDTO(
                    reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("Symbol")),
                    reader.GetDouble(reader.GetOrdinal("BuyPrice")),
                    reader.GetDouble(reader.GetOrdinal("SellPrice")),
                    reader.GetInt32(reader.GetOrdinal("Shares"))
                ));
            }
            return items;
        }

        public void SaveTrade(TradeDTO tradeDTO)
        {
            DBConnection.EnsureOpen();

            const string sql = @"
            INSERT INTO Trade (Symbol, BuyPrice, SellPrice, Shares)
            VALUES (@symbol, @buyPrice, @sellPrice, @shares);
            ";

            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            cmd.Parameters.Add(new SqlParameter("@symbol", SqlDbType.NVarChar, 200) { Value = tradeDTO.Symbol });
            cmd.Parameters.Add(new SqlParameter("@buyPrice", SqlDbType.Decimal) { Value = tradeDTO.BuyPrice });
            cmd.Parameters.Add(new SqlParameter("@sellPrice", SqlDbType.Decimal) { Value = tradeDTO.SellPrice });
            cmd.Parameters.Add(new SqlParameter("@shares", SqlDbType.Int) { Value = tradeDTO.Shares });

            var idObj = cmd.ExecuteScalar();
        }

        //ToDo: update trade functie maken
        //public void UpdateTrade(TradeDTO tradeDTO)
        //{

        //}
    }
}
