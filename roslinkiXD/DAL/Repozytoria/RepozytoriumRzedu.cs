using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Repozytoria
{
    using Encje;
    class RepozytoriumRzedu
    {
        #region ZAPYTANIA
        private const string RZAD = "SELECT * FROM rzad";
        //private const string DODAJ_ROSLINE = "INSERT INTO `rosliny_domowe` ( `id_rzedu`,`nazwa`, `maksymalna_wysokosc`, `trudnosc_uprawy`, `kwasowosc`, `id_naslo`) VALUES";
        #endregion

        public static List<Rzad> PobierzWszystkieRzedy()
        {
            List<Rzad> rzad = new List<Rzad>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(RZAD, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rzad.Add(new Rzad(reader));
                }
                connection.Close();
            }
            return rzad;
        }
    }
}
