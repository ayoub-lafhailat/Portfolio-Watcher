using Core.Data.Connection;
using Core.Domain.Dto;
using Core.Domain.Interfaces;
using Core.Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public class SymbolRepo : ISymbolRepository
    {
        public SymbolDTO GetSymbolById(int symbolId)
        {
            DBConnection.EnsureOpen();

            const string sql = @"SELECT symbol_id, ticker, name, current_price FROM Symbol WHERE symbol_id = @symbolId;";
            //using betekent als ik er klaar mee ben gaat het weg/ wordt opgeruimd
            using var cmd = new SqlCommand(sql, DBConnection.Connection);
            cmd.Parameters.AddWithValue("@symbolId", symbolId);

            using var reader = cmd.ExecuteReader();
            //dit moest van chatgpt?
            if (!reader.Read())
                return null;

            return new SymbolDTO(
                reader.GetInt32(reader.GetOrdinal("symbol_id")),
                reader.GetString(reader.GetOrdinal("ticker")),
                reader.GetString(reader.GetOrdinal("name")),
                //van deze price moet een random waarde gemaakt worden.
                reader.GetDouble(reader.GetOrdinal("current_price"))
            );
        }
    }
}
