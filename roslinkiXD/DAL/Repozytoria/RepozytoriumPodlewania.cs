using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using roslinkiXD.DAL.Encje;
namespace roslinkiXD.DAL.Repozytoria
{
    class RepozytoriumPodlewania
    {
        #region ZAPYTANIA
        private const string podlewanie = "SELECT * FROM podlewanie";

        #endregion

        public static List<Podlewanie> PobierzWszystkiePod()
        {
            List<Podlewanie> Podlewanie = new List<Podlewanie>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(podlewanie, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Podlewanie.Add(new Podlewanie(reader));
                }
                connection.Close();
            }
            return Podlewanie;
        }
    }
}
