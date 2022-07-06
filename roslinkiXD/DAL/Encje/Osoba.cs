using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Encje
{
    class Osoba
    {
        #region Własności
        public sbyte? Id_osoby { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public string Status { get; set; }
        public string Haslo { get; set; }
        #endregion

        public Osoba (MySqlDataReader reader)
        {

            Id_osoby = sbyte.Parse(reader["id_osoby"].ToString());
        
            Imie = reader["imie"].ToString();
            
            Nazwisko = reader["nazwisko"].ToString();
            Status = reader["status"].ToString();
           Haslo = reader["haslo"].ToString();

    }
}
}
