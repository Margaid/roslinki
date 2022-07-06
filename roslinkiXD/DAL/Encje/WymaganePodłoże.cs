using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Encje
{
    class WymaganePodłoże
    {
        #region Własności
        public sbyte Id_podloza { get; set; }
        public sbyte Id_rosliny { get; set; }
        #endregion

        #region Konstruktory

        public WymaganePodłoże(MySqlDataReader reader)
        {

            Id_podloza = sbyte.Parse(reader["id_podloza"].ToString());
            Id_rosliny = sbyte.Parse(reader["id_rosliny"].ToString());
        }
        #endregion
        #region Metody

        public override string ToString()
        {
            return $"{Id_podloza},{Id_rosliny}";
        }
        #endregion
    }
}
