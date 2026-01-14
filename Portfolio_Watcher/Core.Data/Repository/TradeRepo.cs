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

            const string sql = "SELECT trade_id, symbol_id, buy_price, sell_price, shares FROM Trade;";

            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            using var reader = cmd.ExecuteReader();

            var items = new List<TradeDTO>();
            while (reader.Read())
            {
                items.Add(new TradeDTO(
                    reader.GetInt32(reader.GetOrdinal("trade_id")),
                    reader.GetString(reader.GetOrdinal("symbol_id")),
                    reader.GetDouble(reader.GetOrdinal("buy_price")),
                    //ToDo: sellprice mag nullable zijn.
                    reader.GetDouble(reader.GetOrdinal("sell_price")),
                    reader.GetInt32(reader.GetOrdinal("shares"))
                ));
            }
            return items;
        }

        public void SaveTrade(TradeDTO tradeDTO)
        {
            DBConnection.EnsureOpen();

            const string sql = @"
            INSERT INTO Trade (symbol_id, buy_price, sell_price, shares, portfolio_id)
            VALUES (@symbol, @buyPrice, @sellPrice, @shares, @portfolio);
            ";

            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            cmd.Parameters.Add(new SqlParameter("@symbol", SqlDbType.NVarChar, 200) { Value = tradeDTO.Symbol });
            cmd.Parameters.Add(new SqlParameter("@buyPrice", SqlDbType.Decimal) { Value = tradeDTO.BuyPrice });
            //ToDo: sellprice mag nullable zijn
            cmd.Parameters.Add(new SqlParameter("@sellPrice", SqlDbType.Decimal) { Value = tradeDTO.SellPrice });
            cmd.Parameters.Add(new SqlParameter("@shares", SqlDbType.Int) { Value = tradeDTO.Shares });

            //ToDo: Je moet hier een portfolio id insert veld maken, die is nou verplicht en heeft FK naar portfolio table
            cmd.Parameters.Add(new SqlParameter("@portfolio", SqlDbType.Int) { Value = tradeDTO.Portfolio.PortfolioId});

            var idObj = cmd.ExecuteScalar();
        }

        //ToDo: update trade functie maken
        //public void UpdateTrade(TradeDTO tradeDTO)
        //{

        //}
    }
}
