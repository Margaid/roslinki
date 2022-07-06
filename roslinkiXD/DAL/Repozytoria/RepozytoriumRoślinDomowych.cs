using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Repozytoria
{
    using Encje;
    class RepozytoriumRoślinDomowych
    {

        #region ZAPYTANIA
        private const string PLANTS = "SELECT * FROM rosliny_domowe";
        //private const string DODAJ_ROSLINE = "INSERT INTO `rosliny_domowe` (`id_rzedu`, `nazwa`, `maksymalna_wysokosc`, `trudnosc_uprawy`, `kwasowosc`, `id_naslo`) VALUES";
        #endregion


        public static List<RoślinyDomowe> PobierzWszystkieRośliny()
        {
            List<RoślinyDomowe> ros = new List<RoślinyDomowe>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(PLANTS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ros.Add(new RoślinyDomowe(reader));
                }
                connection.Close();
            }
            return ros;
        }
        public static bool DodajRoslineDoBazy(RoślinyDomowe roślinyDomowe)
        {
            bool stan = false;

            using (var connection = DBConnection.Instance.Connection)
            {

                // MySqlCommand command = new MySqlCommand($"{DODAJ_ROSLINE} {roślinyDomowe.ToInsert()}", connection);
                MySqlCommand command1 = new MySqlCommand($"SELECT id_rosliny from rosliny_domowe order by 1 desc limit 1", connection);
                connection.Open();
                int id = Convert.ToInt32(command1.ExecuteScalar().ToString()) + 1;
                stan = true;
                roślinyDomowe.Id_rosliny = (sbyte)id;
                int execute = command1.ExecuteNonQuery();
                MySqlCommand command = new MySqlCommand($"INSERT INTO rosliny_domowe SET nazwa='{roślinyDomowe.Nazwa}', id_rzedu={roślinyDomowe.Id_rzedu}, maksymalna_wysokosc={roślinyDomowe.Maksymalna_wysokosc}, trudnosc_uprawy='{roślinyDomowe.Trudnosc_uprawy}', kwasowosc='{roślinyDomowe.Kwasowosc}',id_naslo={roślinyDomowe.Id_naslo}", connection);
                Console.WriteLine(command);
                connection.Close();
            }
            return stan;
        }
        public static bool EdytujRoslineWBazie(RoślinyDomowe roślinyDomowe, sbyte idRosliny)
        {
            bool stan = false;
            string us = DBConnection.Username;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_ROSLINE = $"UPDATE rosliny_domowe SET nazwa='{roślinyDomowe.Nazwa}', id_rzedu='{roślinyDomowe.Id_rzedu}', maksymalna_wysokosc='{roślinyDomowe.Maksymalna_wysokosc}', trudnosc_uprawy='{roślinyDomowe.Trudnosc_uprawy}', kwasowosc='{roślinyDomowe.Kwasowosc}',id_naslo='{roślinyDomowe.Id_naslo}' WHERE id_rosliny='{idRosliny}'";

                MySqlCommand command = new MySqlCommand(EDYTUJ_ROSLINE, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                Console.WriteLine(command);
                connection.Close();
            }
            return stan;
        }
        public static bool UsunRoslineWBazie(RoślinyDomowe roślinyDomowe, sbyte idRosliny)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string USUN_ROSLINE = $"DELETE FROM rosliny_domowe WHERE id_rosliny={idRosliny}";

                MySqlCommand command = new MySqlCommand(USUN_ROSLINE, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;
                connection.Close();
            }
            return stan;
        }
        //pobranie danych dla określonej rośliny
        public static List<RoślinyDomowe> PobierzRoslinyPoID(sbyte? idRośliny)
        {
            List<RoślinyDomowe> nazwa = new List<RoślinyDomowe>();
            using (var connection = DBConnection.Instance.Connection)
            {
                string WYSWIETL = $"select * from rosliny_domowe WHERE id_rosliny={idRośliny}";

                MySqlCommand command = new MySqlCommand(WYSWIETL, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nazwa.Add(new RoślinyDomowe(reader));
                }
                connection.Close();
            }
            return nazwa;
        }

    }
}
