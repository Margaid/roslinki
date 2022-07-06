using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Repozytoria
{
    using Encje;
    class RepozytoriumOsoby
    {
        #region ZAPYTANIA
        private const string OSOBY = "SELECT * FROM osoba";
        //private const string DODAJ_ROSLINE = "INSERT INTO `rosliny_domowe` ( `id_rzedu`,`nazwa`, `maksymalna_wysokosc`, `trudnosc_uprawy`, `kwasowosc`, `id_naslo`) VALUES";
        #endregion

        public static List<Osoba> PobierzWszystkieOsoby()
        {
            List<Osoba> osoba = new List<Osoba>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(OSOBY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    osoba.Add(new Osoba(reader));
                }
                connection.Close();
            }
            return osoba;
        }
    }
}
