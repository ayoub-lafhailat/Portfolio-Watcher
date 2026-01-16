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
using Core.Data.Exceptions;


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
            var items = new List<TradeDTO>();
            try
            {
                //alleen checken of connectie open is anders openen.
                DBConnection.EnsureOpen();

                const string sql = "SELECT trade_id, symbol_id, buy_price, sell_price, shares, portfolio_id FROM Trade;";

                using var cmd = new SqlCommand(sql, DBConnection.Connection);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(new TradeDTO(
                        reader.GetInt32(reader.GetOrdinal("trade_id")),
                        reader.GetInt32(reader.GetOrdinal("symbol_id")),
                        reader.GetDouble(reader.GetOrdinal("buy_price")),
                        //ToDo: sellprice mag nullable zijn.
                        reader.GetDouble(reader.GetOrdinal("sell_price")),
                        reader.GetInt32(reader.GetOrdinal("shares")),
                        reader.GetInt32(reader.GetOrdinal("portfolio_id"))
                    ));
                }
            }
            //Vang SQL errors op, user mag geen technische details als error terugkrijgen.
            //Inner Exception is voor developer, string exception is voor de user.
            catch (SqlException exception)
            {
                throw new TradeRepositoryException("Error getting trades from database", exception);
            }
            //Vang resterende errors op
            catch (Exception ex)
            {
                throw new TradeRepositoryException("Unknown error getting trades from database.", ex);
            }

            return items;

        }

        public void SaveTrade(TradeDTO tradeDTO)
        {
            try
            {
                DBConnection.EnsureOpen();

                const string sql = @"INSERT INTO Trade (symbol_id, buy_price, sell_price, shares, portfolio_id)VALUES (@symbol_id, @buyPrice, @sellPrice, @shares, @portfolio_id);";

                using var cmd = new SqlCommand(sql, DBConnection.Connection);

                cmd.Parameters.Add(new SqlParameter("@symbol_id", SqlDbType.Int) { Value = tradeDTO.SymbolId });
                cmd.Parameters.Add(new SqlParameter("@buyPrice", SqlDbType.Decimal) { Value = tradeDTO.BuyPrice });

                // als sellPrice niet nullable is bij jou:
                cmd.Parameters.Add(new SqlParameter("@sellPrice", SqlDbType.Decimal) { Value = tradeDTO.SellPrice });

                cmd.Parameters.Add(new SqlParameter("@shares", SqlDbType.Int) { Value = tradeDTO.Shares });
                cmd.Parameters.Add(new SqlParameter("@portfolio_id", SqlDbType.Int) { Value = tradeDTO.PortfolioId });

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new TradeRepositoryException("Error saving trade to database.", ex);
            }
            catch (Exception ex)
            {
                throw new TradeRepositoryException("Unknown error saving trade to database.", ex);
            }
        }

        //ToDo: update trade functie maken
        //public void UpdateTrade(TradeDTO tradeDTO)
        //{
        //}
    }
}
