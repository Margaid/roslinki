using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Encje
{
    class RoślinyDomowe
    {

        #region Własności
        public sbyte? Id_rosliny { get; set; }
        public sbyte Id_rzedu { get; set; }
        public string Nazwa { get; set; }

        public sbyte Maksymalna_wysokosc { get; set; }
        public string Trudnosc_uprawy { get; set; }
        public string Kwasowosc { get; set; }
        public sbyte Id_naslo { get; set; }

        internal static bool Contains(RoślinyDomowe rośliny)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Konstruktory

        //konstruktor tworzy obiekt na podstawie MySQLDataReader
        public RoślinyDomowe(MySqlDataReader reader)
        {
            
            Id_rosliny = sbyte.Parse(reader["id_rosliny"].ToString());
            Id_rzedu = sbyte.Parse(reader["id_rzedu"].ToString());
            Nazwa = reader["nazwa"].ToString();
            Maksymalna_wysokosc = sbyte.Parse(reader["maksymalna_wysokosc"].ToString());
            Trudnosc_uprawy = reader["trudnosc_uprawy"].ToString();
            Kwasowosc = reader["kwasowosc"].ToString();
            Id_naslo = sbyte.Parse(reader["id_naslo"].ToString());
            
        }
        public RoślinyDomowe(sbyte id_rzedu, string nazwa, sbyte maksymalna_wysokosc, string trudnosc_uprawy, string kwasowosc, sbyte id_naslo)
        {
            Id_rosliny = null;
            Id_rzedu = id_rzedu;
            Nazwa=nazwa.Trim();
            Maksymalna_wysokosc = maksymalna_wysokosc;
            Trudnosc_uprawy = trudnosc_uprawy.Trim();
            Kwasowosc = kwasowosc.Trim();
            Id_naslo = id_naslo;
        }

        public RoślinyDomowe(RoślinyDomowe r)
        {
            Id_rosliny = r.Id_rosliny;
            Id_rzedu = r.Id_rzedu;
            Nazwa = r.Nazwa;
            Maksymalna_wysokosc = r.Maksymalna_wysokosc;
            Trudnosc_uprawy = r.Trudnosc_uprawy;
            Kwasowosc = r.Kwasowosc;
            Id_naslo = r.Id_naslo;
        }

        #endregion

        #region Metody

        public override string ToString()
        {
            return $"{Id_rosliny} {Nazwa} {Maksymalna_wysokosc} {Trudnosc_uprawy} {Kwasowosc}";
        }
        
        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto)
        public string ToInsert()
        {
            return $",{Id_rzedu},\'{ Nazwa}\',{ Maksymalna_wysokosc},\'{ Trudnosc_uprawy}\',\'{ Kwasowosc}\', {Id_naslo})";
        }
        //dzięki przeciążeniu tej metody Contains w liście sprawdzi czy dany obiekt do niej należy
        public override bool Equals(object ros)
        {
            //nie porównujemy ID
            var r = ros as RoślinyDomowe;
            if (r is null) return false;
            if (Nazwa.ToLower() != r.Nazwa.ToLower()) return false;
            if (Maksymalna_wysokosc != r.Maksymalna_wysokosc) return false;
            if (Trudnosc_uprawy.ToLower() != r.Trudnosc_uprawy.ToLower()) return false;
            if (Kwasowosc.ToLower() != r.Kwasowosc.ToLower()) return false;
            return true;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        
    }
}
