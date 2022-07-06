using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Encje
{
    class Rodzina2
    {
        #region Własności
       
        public string Nazwa { get; set; }
        #endregion

        public Rodzina2(MySqlDataReader reader)
        {

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
