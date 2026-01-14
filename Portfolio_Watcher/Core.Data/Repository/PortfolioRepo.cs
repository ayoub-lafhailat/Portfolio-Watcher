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

            const string sql = "SELECT portfolio_id, name, description FROM Portfolio;";

            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            using var reader = cmd.ExecuteReader();

            var items = new List<PortfolioDTO>();
            while (reader.Read())
            {
                items.Add(new PortfolioDTO(
                    reader.GetInt32(reader.GetOrdinal("portfolio_id")),
                    reader.GetString(reader.GetOrdinal("name")),
                    reader.GetString(reader.GetOrdinal("description"))

                ));
            }
            return items;
        }

        public PortfolioDTO GetPortfolioById(int portfolioId)
        {
            DBConnection.EnsureOpen();

            const string sql = @"SELECT portfolio_id, name, description FROM Portfolio WHERE portfolio_id = @portfolioId;";

            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            cmd.Parameters.AddWithValue("@portfolioId", portfolioId);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            return new PortfolioDTO(
                reader.GetInt32(reader.GetOrdinal("portfolio_id")),
                reader.GetString(reader.GetOrdinal("name")),
                reader.GetString(reader.GetOrdinal("description"))
            );
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

            const string sql = @"INSERT INTO Portfolio (name, description) VALUES (@name, @description);";

            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 200) { Value = portfolioDTO.Name });
            cmd.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 200) { Value = portfolioDTO.Description });

            var idObj = cmd.ExecuteScalar();
        }
    }
}
