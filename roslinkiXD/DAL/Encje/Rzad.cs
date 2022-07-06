using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Encje
{
    class Rzad
    {
        #region Własności
        public sbyte Id_rzedu { get; set; }
        public string Nazwa { get; set; }
        public sbyte Id_rodziny { get; set; }
        #endregion

        #region Konstruktory

        //bardzo przydatny konstruktor tworzy obiekt na podstawie MySQLDataReader
        public Rzad(MySqlDataReader reader)
        {

            Id_rzedu = sbyte.Parse(reader["id_rzedu"].ToString());
            Nazwa = reader["nazwa"].ToString();
            Id_rodziny = sbyte.Parse(reader["id_rodziny"].ToString());

        }
        #endregion

        #region Metody

        public override string ToString()
        {
            return $"{Nazwa}";
        }
        #endregion



    }

}
