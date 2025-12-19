using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Connection
{
    //waarom is deze class static?
    //voordeel meest simpel te gebruiken/snappen
    //nadeel eigenlijk kan er maar een user tegelijk de connectie gebruiken of je krijgt errors.

    //ToDo: Connecties maken met een asynchronous factory. Alle methoden zelf connecties openen/sluiten (zie notes)
    //ToDo: in design en keuzes document opschrijven wat je eerst had, waarom je niet goed vond, wat overweging was, uiteindelijke keuze met uitleg

    public static class DBConnection
    {
        public static SqlConnection Connection =
            new SqlConnection("Server=LAPTOP-ER1GQBNL\\SQLEXPRESS01;Database=PortfolioWatcher;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");

        //simpele check om te kijken of de connectie open staat anders wordt die opengezet
        public static void EnsureOpen()
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
        }
    }

}
