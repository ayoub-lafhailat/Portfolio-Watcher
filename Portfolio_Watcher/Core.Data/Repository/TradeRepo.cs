using Core.Data.Connection;
using Core.Data.Dto.Core.Domain.Models;
using Core.Data.Dto.Core.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//ToDo: goed kijken welke data types je in de db selecteert price staat erin als float
namespace Core.Data.Repository
{
    public class TradeRepo : ITradeRepository
    {
        //ToDo: exception handling

        //deze maakt een lijst van dtos
        //die kan de service dan roepen want die kent de data laag
        //de service kan daar trade domein modellen van maken
        //de gui kan dan om die trade domein vragen in de onget want die kent de domein laag
        //de gui kan dan de domein modellen weergeven in de gui
        public List<TradeDTO> GetAll()
        {
            //alleen checken of connectie open is anders openen.
            DBConnection.EnsureOpen();

            const string sql = "SELECT Id, Symbol, BuyPrice, SellPrice, Shares FROM Trade;";
            //using is een ingebouwde c# functie die iets gebruikt, en nadat die er klaar mee is disposed die van de var.
            //dit is voor je cmd handig omdat je eigenlijk je connectie in een var zet en als je klaar bent met de connectie dispose je hem
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

        public void Add(TradeDTO tradeDTO)
        {
            DBConnection.EnsureOpen();

            const string sql = @"
            INSERT INTO Trade (Symbol, BuyPrice, SellPrice, Shares)
            VALUES (@symbol, @buyPrice, @sellPrice, @shares);
            ";

            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            cmd.Parameters.Add(new SqlParameter("@symbol", SqlDbType.NVarChar, 200) { Value = tradeDTO.Symbol });
            cmd.Parameters.Add(new SqlParameter("@buyPrice", SqlDbType.Float) { Value = tradeDTO.BuyPrice });
            cmd.Parameters.Add(new SqlParameter("@sellPrice", SqlDbType.Float) { Value = tradeDTO.SellPrice });
            cmd.Parameters.Add(new SqlParameter("@shares", SqlDbType.Int) { Value = tradeDTO.Shares });

            var idObj = cmd.ExecuteScalar();
        }
    }
}
