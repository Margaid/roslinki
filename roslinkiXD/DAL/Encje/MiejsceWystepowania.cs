using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Encje
{
    class MiejsceWystepowania
    {

        #region Własności
        public sbyte Id_rosliny { get; set; }
        public string Kontynent { get; set; }
        public string Klimat { get; set; }
        #endregion

        #region Konstruktory

        public MiejsceWystepowania(MySqlDataReader reader)
        {

            Id_rosliny = sbyte.Parse(reader["id_rosliny"].ToString());
            Kontynent = reader["kontynent"].ToString();
            Klimat = reader["klimat"].ToString();
        }
        #endregion
        #region Metody

        public override string ToString()
        {
            return $"{Kontynent},{Klimat}";
        }
        #endregion
    }
}
