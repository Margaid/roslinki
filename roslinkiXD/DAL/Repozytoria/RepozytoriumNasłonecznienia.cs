using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using roslinkiXD.DAL.Encje;
namespace roslinkiXD.DAL.Repozytoria
{
    class RepozytoriumNasłonecznienia
    {
        #region ZAPYTANIA
        private const string naslo = "SELECT * FROM naslonecznienie";
       
        #endregion

        public static List<Nasłonecznienie> PobierzWszystkieNas()
        {
            List<Nasłonecznienie> naslonecznienie = new List<Nasłonecznienie>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(naslo, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    naslonecznienie.Add(new Nasłonecznienie(reader));
                }
                connection.Close();
            }
            return naslonecznienie;
        }
    }
}
