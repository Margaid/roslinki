using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using roslinkiXD.DAL.Encje;

namespace roslinkiXD.DAL.Repozytoria
{
    class RepozytoriumMiejscaWystepowania
    {

        #region ZAPYTANIA
        private const string podlewanie = "SELECT * FROM miejsce_wystepowania";

        #endregion

        public static List<MiejsceWystepowania> PobierzWszystkieMiejscaWystepowania()
        {
            List<MiejsceWystepowania> MiejsceWystepowania = new List<MiejsceWystepowania>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(podlewanie, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MiejsceWystepowania.Add(new MiejsceWystepowania(reader));
                }
                connection.Close();
            }
            return MiejsceWystepowania;
        }
    }
}
