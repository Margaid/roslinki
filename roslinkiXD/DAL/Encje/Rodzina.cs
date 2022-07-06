using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Encje
{
    class Rodzina
    {
        #region Własności
        public sbyte Id_rodziny { get; set; }
        public string Nazwa { get; set; }
        #endregion

        public Rodzina(MySqlDataReader reader)
        {

            Id_rodziny = sbyte.Parse(reader["id_rodziny"].ToString());
            Nazwa = reader["nazwa"].ToString();
           
        }
        

        #region Metody

        public override string ToString()
        {
            return $"{Nazwa}";
        }
        #endregion
    }
}
