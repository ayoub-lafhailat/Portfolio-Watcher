using Core.Data.Connection;
using Core.Data.Dto.Core.Domain.Models;
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
    public class TradeRepo
    {

        //deze maakt een lijst van dtos
        //die kan de service dan roepen want die kent de data laag
        //de service kan daar trade domein modellen van maken
        //de gui kan dan om die trade domein vragen in de onget want die kent de domein laag
        //de gui kan dan de domein modellen weergeven in de gui
        public List<TradeDTO> GetAll()
        {
            //alleen checken of connectie open is anders openen.
            DBConnection.EnsureOpen();

            const string sql = "SELECT Id, Symbol, Price, Shares FROM Trade;";
            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            using var reader = cmd.ExecuteReader();

            var items = new List<TradeDTO>();
            while (reader.Read())
            {
                items.Add(new TradeDTO(
                    reader.GetString(reader.GetOrdinal("Symbol")),
                    reader.GetDouble(reader.GetOrdinal("Price")),
                    reader.GetInt32(reader.GetOrdinal("Shares"))
                ));
            }
            return items;
        }

        public int Add(TradeDTO tradeDTO)
        {
            DBConnection.EnsureOpen();

            const string sql = @"
            INSERT INTO Trade (Symbol, Price, Shares)
            VALUES (@symbol, @price, @shares);
            SELECT CAST(SCOPE_IDENTITY() AS int);
        ";

            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            cmd.Parameters.Add(new SqlParameter("@symbol", SqlDbType.NVarChar, 200) { Value = tradeDTO.Symbol });
            cmd.Parameters.Add(new SqlParameter("@price", SqlDbType.Float) { Value = tradeDTO.Price });
            cmd.Parameters.Add(new SqlParameter("@shares", SqlDbType.Bit) { Value = tradeDTO.Shares });

            var idObj = cmd.ExecuteScalar();
            return (int)idObj!;
        }
    }
}
