using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Encje
{
    class Nasłonecznienie
    {
        #region Własności
        public sbyte Id_naslo { get; set; }
        public string Stopien { get; set; }
        #endregion

        #region Konstruktory

        //bardzo przydatny konstruktor tworzy obiekt na podstawie MySQLDataReader
        public Nasłonecznienie(MySqlDataReader reader)
        {

            Id_naslo = sbyte.Parse(reader["id_naslo"].ToString());
            Stopien = reader["stopien"].ToString();

        }
        #endregion
        #region Metody

        public override string ToString()
        {
            return $"{Stopien}";
        }
        #endregion

    }
}
