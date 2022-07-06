using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using roslinkiXD.DAL.Encje;

namespace roslinkiXD.DAL.Repozytoria
{
    class RepozytoriumPodłoża
    {

        #region ZAPYTANIA
        private const string podlewanie = "SELECT * FROM podloze";

        #endregion

        public static List<Podłoże> PobierzWszystkiePodloza()
        {
            List<Podłoże> Podłoże = new List<Podłoże>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(podlewanie, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Podłoże.Add(new Podłoże(reader));
                }
                connection.Close();
            }
            return Podłoże;
        }
    }
}
