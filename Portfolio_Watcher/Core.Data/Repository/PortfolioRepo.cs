using Core.Data.Connection;
using Core.Domain.Dto;
using Core.Domain.Interfaces;
using Core.Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public class PortfolioRepo : IPortfolioRepository
    {
        public List<PortfolioDTO> GetAllPortfolios()
        {
            //alleen checken of connectie open is anders openen.
            DBConnection.EnsureOpen();

            const string sql = "SELECT Id, Name, Description FROM Portfolio;";

            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            using var reader = cmd.ExecuteReader();

            var items = new List<PortfolioDTO>();
            while (reader.Read())
            {
                items.Add(new PortfolioDTO(
                    reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("Name")),
                    reader.GetString(reader.GetOrdinal("Description"))

                ));
            }
            return items;
        }

        public List<Symbol> GetSymbolsForPortfolio(Trade trade)
        {
            throw new NotImplementedException();
        }

        public List<Trade> GetTradesForPortfolio(Trade trade)
        {
            throw new NotImplementedException();
        }

        public void SavePortfolio(PortfolioDTO portfolioDTO)
        {
            DBConnection.EnsureOpen();

            const string sql = @"
            INSERT INTO Portfolio (Name, Description)
            VALUES (@name, @description);
            ";

            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 200) { Value = portfolioDTO.Name });
            cmd.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 200) { Value = portfolioDTO.Description });

            var idObj = cmd.ExecuteScalar();
        }
    }
}
