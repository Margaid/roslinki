using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Encje
{
    class Podlewanie
    {

        #region Własności
        public sbyte Id_podlewania { get; set; }
        public string Czestotliwosc { get; set; }
        public string Wilgotnosc { get; set; }
        public sbyte Id_rosliny { get; set; }
        #endregion

        #region Konstruktory

        //bardzo przydatny konstruktor tworzy obiekt na podstawie MySQLDataReader
        public Podlewanie(MySqlDataReader reader)
        {

            Id_podlewania = sbyte.Parse(reader["id_podlewania"].ToString());
            Czestotliwosc = reader["czestotliwosc"].ToString();
            Wilgotnosc = reader["wilgotnosc"].ToString();
            Id_rosliny = sbyte.Parse(reader["id_rosliny"].ToString());
        }
        #endregion
        #region Metody

        public override string ToString()
        {
            return $"{Czestotliwosc},{Wilgotnosc}";
        }
        #endregion
    }
}
