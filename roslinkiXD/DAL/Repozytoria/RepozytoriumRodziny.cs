using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Repozytoria
{
    using Encje;
    class RepozytoriumRodziny
    {
        #region ZAPYTANIA
        private const string RZAD = "SELECT * FROM rodzina";
        private const string rzad_rodzina = "Select rodzina.nazwa from rodzina  join rzad on rodzina.id_rodziny=rzad.id_rzedu;";
        //private const string DODAJ_ROSLINE = "INSERT INTO `rosliny_domowe` ( `id_rzedu`,`nazwa`, `maksymalna_wysokosc`, `trudnosc_uprawy`, `kwasowosc`, `id_naslo`) VALUES";
        #endregion

        public static List<Rodzina> PobierzWszystkieRodziny()
        {
            List<Rodzina> rodzina = new List<Rodzina>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(RZAD, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rodzina.Add(new Rodzina(reader));
                }
                connection.Close();
            }
            return rodzina;
        }
        public static List<Rodzina2> PobierzRodzineZRzedu()
        {
            List<Rodzina2> rodzinaZRzedu = new List<Rodzina2>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(rzad_rodzina, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rodzinaZRzedu.Add(new Rodzina2(reader));
                }
                connection.Close();
            }
            return rodzinaZRzedu;
        }
    }
}
