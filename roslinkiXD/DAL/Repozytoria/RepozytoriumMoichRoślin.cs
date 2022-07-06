using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Repozytoria
{
    using Encje;
    class RepozytoriumMoichRoślin
    {

        #region ZAPYTANIA
        private const string MOJE = "SELECT * FROM moje_rosliny";
       
        #endregion

        public static List<MojeRośliny> PobierzWszystkieMojeRośliny()
        {
            List<MojeRośliny> moje = new List<MojeRośliny>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(MOJE, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    moje.Add(new MojeRośliny(reader));
                }
                connection.Close();
            }
            return moje;
        }

        public static List<MojeRośliny> PobierzMojeRoslinyPoID(sbyte? idOsoby)
        {
            List<MojeRośliny> moje2 = new List<MojeRośliny>();
            using (var connection = DBConnection.Instance.Connection)
            {
                string WYSWIETL = $"select * from moje_rosliny WHERE id_osoby={idOsoby}";

                MySqlCommand command = new MySqlCommand(WYSWIETL, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    moje2.Add(new MojeRośliny(reader));
                }
                connection.Close();
            }
            return moje2;
        }
       
        //edytowanie rosliny w bazie
        public static bool EdytujMojaRoslineWBazie(MojeRośliny moje, int ilosc)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_ROSLINE = $"UPDATE moje_rosliny SET ilosc='{ilosc}' WHERE id_osoby='{moje.Id_osoby}' and id_rosliny='{moje.Id_rosliny}'";

                MySqlCommand command = new MySqlCommand(EDYTUJ_ROSLINE, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }

        //dodanie rosliny
        public static bool DodajRosline(MojeRośliny ros)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"INSERT INTO moje_rosliny VALUES({ros.Id_osoby},{ros.Id_rosliny},{ros.Ilosc})", connection);
                connection.Open();
                stan = true;
                int execute=command.ExecuteNonQuery();

                connection.Close();
            }
            return stan;
        }

    }
}
