using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL.Encje
{
    class MojeRośliny
    {
        #region Własności
        public sbyte? Id_osoby { get; set; }
        public sbyte? Id_rosliny { get; set; }
        public int Ilosc { get; set; }
        #endregion

        public MojeRośliny(MySqlDataReader reader)
        {

            Id_osoby = sbyte.Parse(reader["id_osoby"].ToString());
            Id_rosliny = sbyte.Parse(reader["id_rosliny"].ToString());
            Ilosc = int.Parse(reader["ilosc"].ToString());


        }

        public MojeRośliny(sbyte? id, sbyte? id_rosliny, int ilosc)
        {
            Id_osoby = id;
            Id_rosliny = id_rosliny;
            Ilosc = ilosc;
        }
        public MojeRośliny(sbyte? id, sbyte? id_rosliny)
        {
            Id_osoby = id;
            Id_rosliny = id_rosliny;
        }

        public MojeRośliny(MojeRośliny r)
        {
            Id_osoby = r.Id_osoby;
            Id_rosliny = r.Id_rosliny;
            Ilosc = r.Ilosc;
        }

        public override string ToString()
        {
            return $"{Id_rosliny} {Ilosc}";
        }
        public string ToInsert()
        {
            return $"('{Id_osoby}', '{Id_rosliny}', {Ilosc})";
        }
        public override bool Equals(object obj)
        {
            //nie porównujemy ID
            var roslina = obj as MojeRośliny;
            if (roslina is null) return false;
            if (Id_osoby != roslina.Id_osoby) return false;
            if (Id_rosliny != roslina.Id_rosliny) return false;
            //if (Ilosc != roslina.Ilosc) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
      
    }
}
