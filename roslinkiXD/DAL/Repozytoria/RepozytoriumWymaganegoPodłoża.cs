using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using roslinkiXD.DAL.Encje;

namespace roslinkiXD.DAL.Repozytoria
{
    class RepozytoriumWymaganegoPodłoża
    {

        #region ZAPYTANIA
        private const string podlewanie = "SELECT * FROM wymagane_podloze";

        #endregion

        public static List<WymaganePodłoże> PobierzWszystkieWymaganePodloza()
        {
            List<WymaganePodłoże> WymaganePodłoże = new List<WymaganePodłoże>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(podlewanie, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    WymaganePodłoże.Add(new WymaganePodłoże(reader));
                }
                connection.Close();
            }
            return WymaganePodłoże;
        }
    }
}
