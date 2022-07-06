using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Encje
{
    class Podłoże
    {
        #region Własności
        public sbyte Id_podloza { get; set; }
        public string Typ { get; set; }
        #endregion

        #region Konstruktory

        public Podłoże(MySqlDataReader reader)
        {

            Id_podloza = sbyte.Parse(reader["id_podloza"].ToString());
            Typ = reader["typ"].ToString();
        }
        #endregion
        #region Metody

        public override string ToString()
        {
            return $"{Typ}";
        }
        #endregion
    }
}
