using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace prog4._2
{
    public class DB
    {
        private IDbConnection _connection;

        public DB(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public IEnumerable<Spedytorzy> GetSpedytor()
        {
            return _connection.Query<Spedytorzy>("SELECT * FROM Spedytorzy");
        }

        private int GetMaxSpedytorzyId()
        {
            return _connection.ExecuteScalar<int>("SELECT MAX(IDspedytora) FROM Spedytorzy");
        }

        private bool AddSpedytorzy(Spedytorzy spedytorzy)
        {
            var result = _connection.Execute("INSERT INTO Spedytorzy(IDspedytora, NazwaFirmy, Telefon) VALUES (@id, @nazwa, @telefon)",
                new { id = spedytorzy.IDspedytora, nazwa = spedytorzy.NazwaFirmy, spedytorzy.Telefon });
            return result == 1;
        }

        public bool AddSpedytorzy(string nazwaFirmy, string telefon)
        {
            return AddSpedytorzy(new Spedytorzy()
            {
                IDspedytora = GetMaxSpedytorzyId() + 1,
                NazwaFirmy = nazwaFirmy,
                Telefon = telefon
            });
        }
        public void DeleteSpedytorzy(int id)
        {
            _connection.QuerySingleOrDefault("delete Spedytorzy where IDspedytora=@ID", new { ID = id });
        }
        public void UpdateSpedytorzy(int id,string nazwafirmy,string telefon)
        {
            _connection.QuerySingleOrDefault("update Spedytorzy set NazwaFirmy=@NazwaFirmy,Telefon=@Telefon where IDSpedytora=@ID", new { ID = id,NazwaFirmy=nazwafirmy,Telefon=telefon });
        }


    }
}
