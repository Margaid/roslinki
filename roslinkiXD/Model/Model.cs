using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roslinkiXD.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;
    using System.Windows;
    using ViewModel;
    class Model
    {
        public ObservableCollection<RoślinyDomowe> Rośliny { get; set; } = new ObservableCollection<RoślinyDomowe>();
        public ObservableCollection<RoślinyDomowe> RoślinyID { get; set; } = new ObservableCollection<RoślinyDomowe>();

        public ObservableCollection<Rzad> Rzedy { get; set; } = new ObservableCollection<Rzad>();
        public ObservableCollection<Rzad> Rzedy2 { get; set; } = new ObservableCollection<Rzad>();
        public ObservableCollection<Rodzina> Rodzina { get; set; } = new ObservableCollection<Rodzina>();
        public ObservableCollection<Rodzina2> RodzinaZRzedu { get; set; } = new ObservableCollection<Rodzina2>();
        public ObservableCollection<Rodzina> PustaRodzina { get; set; } = new ObservableCollection<Rodzina>();

        public ObservableCollection<Osoba> Osoby { get; set; } = new ObservableCollection<Osoba>();


        public ObservableCollection<MojeRośliny> MojeRosliny { get; set; } = new ObservableCollection<MojeRośliny>();
        public ObservableCollection<MojeRośliny> PusteMojeRosliny { get; set; } = new ObservableCollection<MojeRośliny>();
        public ObservableCollection<MojeRośliny> PomocniczeMojeRosliny { get; set; } = new ObservableCollection<MojeRośliny>();

        public ObservableCollection<Nasłonecznienie> Nasłonecznienie { get; set; } = new ObservableCollection<Nasłonecznienie>();
        public ObservableCollection<Nasłonecznienie> PusteNasłonecznienie { get; set; } = new ObservableCollection<Nasłonecznienie>();

        public ObservableCollection<Podlewanie> Podlewanie { get; set; } = new ObservableCollection<Podlewanie>();
        public ObservableCollection<Podlewanie> PustePodlewanie { get; set; } = new ObservableCollection<Podlewanie>();

        public ObservableCollection<Podłoże> Podłoże { get; set; } = new ObservableCollection<Podłoże>();
        public ObservableCollection<Podłoże> PustePodłoże { get; set; } = new ObservableCollection<Podłoże>();

        public ObservableCollection<WymaganePodłoże> WymaganePodłoże { get; set; } = new ObservableCollection<WymaganePodłoże>();

        public ObservableCollection<MiejsceWystepowania> MiejsceWystepowania { get; set; } = new ObservableCollection<MiejsceWystepowania>();
        public ObservableCollection<MiejsceWystepowania> PusteMiejsceWystepowania { get; set; } = new ObservableCollection<MiejsceWystepowania>();


        public Model()
        {
            //pobranie dabych z bazy do kolekcji
            var rośliny = RepozytoriumRoślinDomowych.PobierzWszystkieRośliny();
            foreach (var r in rośliny)
                Rośliny.Add(r);

            var rzedy = RepozytoriumRzedu.PobierzWszystkieRzedy();
            foreach (var r in rzedy)
                Rzedy.Add(r);

            var rodzina = RepozytoriumRodziny.PobierzWszystkieRodziny();
            foreach (var r in rodzina)
                Rodzina.Add(r);

            var rodzinaZRzedu = RepozytoriumRodziny.PobierzRodzineZRzedu();
            foreach (var r in rodzinaZRzedu)
                RodzinaZRzedu.Add(r);

            var osoby = RepozytoriumOsoby.PobierzWszystkieOsoby();
            foreach (var o in osoby)
                Osoby.Add(o);

            var mojerosliny = RepozytoriumMoichRoślin.PobierzWszystkieMojeRośliny();
            foreach (var m in mojerosliny)
                MojeRosliny.Add(m);

            var naslo = RepozytoriumNasłonecznienia.PobierzWszystkieNas();
            foreach (var n in naslo)
                Nasłonecznienie.Add(n);

            var podlewanie = RepozytoriumPodlewania.PobierzWszystkiePod();
            foreach (var p in podlewanie)
                Podlewanie.Add(p);

            var podloze = RepozytoriumPodłoża.PobierzWszystkiePodloza();
            foreach (var p in podloze)
                Podłoże.Add(p);

            var wymaganepodloze = RepozytoriumWymaganegoPodłoża.PobierzWszystkieWymaganePodloza();
            foreach (var p in wymaganepodloze)
                WymaganePodłoże.Add(p);

            var miejsce = RepozytoriumMiejscaWystepowania.PobierzWszystkieMiejscaWystepowania();
            foreach (var m in miejsce)
                MiejsceWystepowania.Add(m);

        }
        //Edycja Roślin
        public bool CzyRoslinaJestJuzWRepozytorium(RoślinyDomowe roślina) => Rośliny.Contains(roślina);
        public bool DodajRoslineDoBazy(RoślinyDomowe roślina)
        {
            if (!CzyRoslinaJestJuzWRepozytorium(roślina))
            {
                if (RepozytoriumRoślinDomowych.DodajRoslineDoBazy(roślina))
                {
                    Rośliny.Add(roślina);
                    return true;
                }
            }
            return false;

        }
        public bool EdytujRoslineWBazie(RoślinyDomowe roślina, sbyte idRośliny)
        {
            if (RepozytoriumRoślinDomowych.EdytujRoslineWBazie(roślina, idRośliny))
            {
                for (int i = 0; i < Rośliny.Count; i++)
                {
                    if (Rośliny[i].Id_rosliny == idRośliny)
                    {
                        roślina.Id_rosliny = idRośliny;
                        Rośliny[i] = new RoślinyDomowe(roślina);
                    }
                }
                return true;
            }
            return false;
        }
        public bool UsunRoslineWBazie(RoślinyDomowe roślina, sbyte idRośliny)
        {
            if (CzyRoslinaJestJuzWRepozytorium(roślina))
            {
                if (RepozytoriumRoślinDomowych.UsunRoslineWBazie(roślina, idRośliny))
                {
                    for (int i = 0; i < Rośliny.Count; i++)
                    {
                        if (Rośliny[i].Id_rosliny == idRośliny)
                        {
                            bool v = Rośliny.Remove(roślina);
                        }
                    }
                    return true;
                }
            }
            return false;

        }
        #region wyświetlanie
        //RZAD
        private Rzad ZnajdzRzadPoId(sbyte id)
        {
            foreach (var r in Rzedy)
            {
                if (r.Id_rzedu == id)
                    return r;
            }
            return null;
        }

        public ObservableCollection<Rzad> PobierzRzadRosliny(RoślinyDomowe ros)
        {
            var rzad = new ObservableCollection<Rzad>();
            foreach (var id in Rzedy)
            {
                if (id.Id_rzedu == ros.Id_rzedu)
                {
                    rzad.Add(ZnajdzRzadPoId(id.Id_rzedu));
                }
            }

            return rzad;
        }
        public ObservableCollection<Nasłonecznienie> PobierzNasłonecznienieRosliny(RoślinyDomowe ros)
        {
            var naslo = new ObservableCollection<Nasłonecznienie>();
            foreach (var id in Nasłonecznienie)
            {
                if (id.Id_naslo == ros.Id_naslo)
                {
                    naslo.Add(id);
                }
            }

            return naslo;
        }
        //RODZINA -> tabela z tabeli
        private Rodzina ZnajdzRodzinePoId(sbyte id)
        {
            foreach (var r in Rodzina)
            {
                if (r.Id_rodziny == id)
                    return r;

            }
            return null;
        }

        public ObservableCollection<Rodzina> PobierzRodzineRosliny(RoślinyDomowe ros)
        {
            var rodzina = new ObservableCollection<Rodzina>();
            foreach (var id in Rodzina)
            {
                Rzad id_pomocnicze = ZnajdzRzadPoId(ros.Id_rzedu);
                if (id_pomocnicze.Id_rodziny == id.Id_rodziny)
                {
                    rodzina.Add(ZnajdzRodzinePoId(id.Id_rodziny));
                }
            }

            return rodzina;
        }

        public ObservableCollection<MojeRośliny> PobierzRoslinyPoID(sbyte? IdOsoby)
        {
            var puste = RepozytoriumMoichRoślin.PobierzMojeRoslinyPoID(IdOsoby);
            foreach (var m in puste)
                PusteMojeRosliny.Add(m);

            return PusteMojeRosliny;
        }
        public ObservableCollection<MojeRośliny> ZnajdzIDRoslinyPoIdOsoby(sbyte? id)
        {

            foreach (var m in MojeRosliny)
            {
                if (m.Id_osoby == id)
                {
                    PomocniczeMojeRosliny.Add(m);
                }
            }
            return PomocniczeMojeRosliny;
        }


        public ObservableCollection<RoślinyDomowe> PobierzNazwepoID(sbyte? IdOsoby)
        {
            var rosliny = ZnajdzIDRoslinyPoIdOsoby(IdOsoby);
            foreach (var r in rosliny)
            {
                var nazwa = RepozytoriumRoślinDomowych.PobierzRoslinyPoID(r.Id_rosliny);
                foreach (var n in nazwa)
                {
                    RoślinyID.Add(n);
                }

            }

            return RoślinyID;
        }
        //dodanie nowej rosliny do moich roslin po dodaniu jej do bazy
        public RoślinyDomowe DodanieNowejMojejRosliny(sbyte? IdRosliny)
        {
            //var rosliny = ZnajdzIDRoslinyPoIdOsoby(IdRosliny);
            foreach (var r in Rośliny)
            {
                if (r.Id_rosliny == IdRosliny)
                {
                    return r;
                }
            }

            return null;
        }


        public ObservableCollection<Podlewanie> PobierzPodlewaniepoID(RoślinyDomowe ros)
        {
            var pod = new ObservableCollection<Podlewanie>();
            foreach (var id in Podlewanie)
            {
                if (id.Id_rosliny == ros.Id_rosliny)
                {
                    pod.Add(id);
                }
            }

            return pod;
        }

        private Podłoże ZnajdzPodlozedPoId(sbyte id)
        {
            foreach (var r in Podłoże)
            {
                if (r.Id_podloza == id)
                    return r;
            }
            return null;
        }
        public ObservableCollection<Podłoże> PobierzPodlozepoID(RoślinyDomowe ros)
        {
            var wymaganepod = new ObservableCollection<WymaganePodłoże>();
            var pod = new ObservableCollection<Podłoże>();
            foreach (var id in WymaganePodłoże)
            {
                if (id.Id_rosliny == ros.Id_rosliny)
                {
                    pod.Add(ZnajdzPodlozedPoId(id.Id_podloza));
                }
            }

            return pod;
        }

        public ObservableCollection<MiejsceWystepowania> PobierzMiejsceWystepowania(RoślinyDomowe ros)
        {
            var miej = new ObservableCollection<MiejsceWystepowania>();
            foreach (var id in MiejsceWystepowania)
            {
                if (id.Id_rosliny == ros.Id_rosliny)
                {
                    miej.Add(id);
                }
            }

            return miej;
        }
        #endregion

        //dodawanie rosliny do moich roslin

        public bool CzyRoslinaJestJuzWMoichRoślinach(MojeRośliny roslina) => MojeRosliny.Contains(roslina);
        
        public MojeRośliny ZnajdzIloscPoID(sbyte? os, sbyte? ros)
        {
            foreach (var r in MojeRosliny)
            {
                if (r.Id_osoby == os && r.Id_rosliny==ros) 
                    return r;
            }
            return null;
        }

        public bool EdytujMojaRoslineWBazie(MojeRośliny roślina, int ilosc)
        {
            if (RepozytoriumMoichRoślin.EdytujMojaRoslineWBazie(roślina, ilosc))
            {
                /*
                for (int i = 0; i < MojeRosliny.Count; i++)
                {
                    if (MojeRosliny[i].Id_osoby == roślina.Id_osoby && MojeRosliny[i].Id_rosliny==roślina.Id_rosliny)
                    {
                        roślina.Ilosc = ilosc;
                        MojeRosliny[i] = new MojeRośliny(roślina);
                        Console.WriteLine(MojeRosliny[i]);
                    }
                }
                */
                
                if (PusteMojeRosliny != null)
                {
                    for (int i=0; i < PusteMojeRosliny.Count; i++)
                    {
                        if (PusteMojeRosliny[i].Id_osoby == roślina.Id_osoby && PusteMojeRosliny[i].Id_rosliny == roślina.Id_rosliny)
                        {
                            roślina.Ilosc = ilosc;
                            PusteMojeRosliny.RemoveAt(i);
                            PusteMojeRosliny.Insert(i, roślina);
                        }
                    }
                }
                
                return true;
            }
            return false;
        }


        public bool DodajRoslineDoMoichRoslin(MojeRośliny ros, RoślinyDomowe roslina)
        {
            if (RepozytoriumMoichRoślin.DodajRosline(ros))
                {
                    MojeRosliny.Add(ros);
                if (PusteMojeRosliny != null)
                {
                    PusteMojeRosliny.Add(ros);
                }
                if (RoślinyID != null)
                {
                    RoślinyID.Add(roslina);
                }
                    
                    return true;
                }
            
            return false;
        }

    }
}

