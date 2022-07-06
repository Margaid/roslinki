using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using roslinkiXD.DAL;

namespace roslinkiXD.ViewModel
{
    using Model;
    using DAL.Encje;
    using BaseClass;
    using System.Windows.Input;
    using System.Collections.ObjectModel;
    using System.Windows;

    class TabListaViewModel : ViewModelBase
    {
        private Model model = null;
        
        private ObservableCollection<Osoba> osoby = null;

        private ObservableCollection<RoślinyDomowe> rośliny = null;
        private ObservableCollection<Rzad> rzedy = null;
        private ObservableCollection<Rzad> rzedy2 = null;

        private ObservableCollection<Rodzina> rodzina = null;
        private ObservableCollection<Rodzina2> rodzinaZRzedu = null;
        private ObservableCollection<Rodzina> pustarodzina = null;

        private ObservableCollection<Nasłonecznienie> nasłonecznienie = null;
        private ObservableCollection<Nasłonecznienie> pustenasłonecznienie = null;

        private ObservableCollection<Podlewanie> podlewanie = null;
        private ObservableCollection<Podlewanie> pustepodlewanie = null;

        private ObservableCollection<Podłoże> podłoże = null;
        private ObservableCollection<Podłoże> pustepodłoże = null;

        private ObservableCollection<MiejsceWystepowania> miejscewystepowania = null;
        private ObservableCollection<MiejsceWystepowania> pustemiejscewystepowania = null;


        private int indeksZaznaczonejRośliny = -1;

        public TabListaViewModel(Model model)
        {
            this.model = model;

            

            osoby = model.Osoby;

            rośliny = model.Rośliny;

            rodzinaZRzedu = model.RodzinaZRzedu;
            rzedy = model.Rzedy;
            rzedy2 = model.Rzedy2;

            rodzina = model.Rodzina;
            pustarodzina = model.PustaRodzina;

            nasłonecznienie = model.Nasłonecznienie;
            pustenasłonecznienie = model.PusteNasłonecznienie;

            podlewanie = model.Podlewanie;
            pustepodlewanie = model.PustePodlewanie;

            podłoże = model.Podłoże;
            pustepodłoże = model.PustePodłoże;

            miejscewystepowania = model.MiejsceWystepowania;
            pustemiejscewystepowania = model.PusteMiejsceWystepowania;


        }
        //ROŚLINY
        public ObservableCollection<RoślinyDomowe> Rośliny
        {
            get { return rośliny; }
            set
            {
                rośliny = value;
                onPropertyChanged(nameof(Rośliny));
            }
        }

        public int IndeksZaznaczonejRośliny
        {
            get => indeksZaznaczonejRośliny;
            set
            {
                indeksZaznaczonejRośliny = value;
                onPropertyChanged(nameof(IndeksZaznaczonejRośliny));
            }
        }

        public RoślinyDomowe BiezacaRoslina { get; set; }

        private ICommand zaladujWyszystkieRosliny = null;
        public ICommand ZaladujWszystkieRosliny
        {
            get
            {
                if (zaladujWyszystkieRosliny == null)
                    zaladujWyszystkieRosliny = new RelayCommand(
                        arg =>
                        {
                            Rośliny = model.Rośliny;
                            IndeksZaznaczonejRośliny = -1;
                        },
                        arg => true
                        );

                return zaladujWyszystkieRosliny;
            }
        }

        //RZĘDY
        public ObservableCollection<Rzad> Rzedy
        {
            get
            {
                return rzedy;
            }
            set
            {
                rzedy = value;
                onPropertyChanged(nameof(Rzedy));
            }
        }
        public ObservableCollection<Rzad> PusteRzedy
        {
            get { return rzedy2; }
            set
            {
                rzedy2 = value;

                onPropertyChanged(nameof(PusteRzedy));
            }
        }


        private ICommand zaladujRzedy = null;
        public ICommand ZaladujRzedy
        {
            get
            {
                if (zaladujRzedy == null)
                    zaladujRzedy = new RelayCommand(
                        arg => {
                            if (BiezacaRoslina != null)
                            {
                                PusteRzedy = model.PobierzRzadRosliny(BiezacaRoslina);
                            }
                        },
                        arg => true
                        );

                return zaladujRzedy;
            }
        }


        //RODZINA

        public ObservableCollection<Rodzina> Rodzina
        {
            get
            {
                return rodzina;
            }
            set
            {
                rodzina = value;
                onPropertyChanged(nameof(Rodzina));
            }
        }
        public ObservableCollection<Rodzina2> RodzinaZRzedu
        {
            get
            {
                return rodzinaZRzedu;
            }
            set
            {
                rodzinaZRzedu = value;
                onPropertyChanged(nameof(RodzinaZRzedu));
            }
        }
        public ObservableCollection<Rodzina> PustaRodzina
        {
            get { return pustarodzina; }
            set
            {
                pustarodzina = value;

                onPropertyChanged(nameof(PustaRodzina));
            }
        }

        private ICommand zaladujRodzine = null;
        public ICommand ZaladujRodzine
        {
            get
            {
                if (zaladujRodzine == null)
                    zaladujRodzine = new RelayCommand(
                        arg => {
                            if (BiezacaRoslina != null)
                            {
                                PustaRodzina = model.PobierzRodzineRosliny(BiezacaRoslina);
                            }
                        },
                        arg => true
                        );

                return zaladujRodzine;
            }
        }


        //NASŁONECZNIENIE
        public ObservableCollection<Nasłonecznienie> Nasłonecznienie
        {
            get
            {
                return nasłonecznienie;
            }
            set
            {
                nasłonecznienie = value;
                onPropertyChanged(nameof(Nasłonecznienie));
            }
        }
        public ObservableCollection<Nasłonecznienie> PusteNasłonecznienie
        {
            get { return pustenasłonecznienie; }
            set
            {
                pustenasłonecznienie = value;

                onPropertyChanged(nameof(PusteNasłonecznienie));
            }
        }

        private ICommand zaladujNaslonecznienie = null;
        public ICommand ZaladujNaslonecznienie
        {
            get
            {
                if (zaladujNaslonecznienie == null)
                    zaladujNaslonecznienie = new RelayCommand(
                        arg => {
                            if (BiezacaRoslina != null)
                            {
                                PusteNasłonecznienie = model.PobierzNasłonecznienieRosliny(BiezacaRoslina);
                            }
                        },
                        arg => true
                        );

                return zaladujNaslonecznienie;
            }
        }

        //PODLEWANIE

        public ObservableCollection<Podlewanie> Podlewanie
        {
            get
            {
                return podlewanie;
            }
            set
            {
                podlewanie = value;
                onPropertyChanged(nameof(Podlewanie));
            }
        }
        public ObservableCollection<Podlewanie> PustePodlewanie
        {
            get { return pustepodlewanie; }
            set
            {
                pustepodlewanie = value;

                onPropertyChanged(nameof(PustePodlewanie));
            }
        }
        private ICommand zaladujPodlewanie = null;
        public ICommand ZaladujPodlewanie
        {
            get
            {
                if (zaladujPodlewanie == null)
                    zaladujPodlewanie = new RelayCommand(
                        arg => {
                            if (BiezacaRoslina != null)
                            {
                                PustePodlewanie = model.PobierzPodlewaniepoID(BiezacaRoslina);
                            }
                        },
                        arg => true
                        );

                return zaladujPodlewanie;
            }
        }

        //PODLOZA
        public ObservableCollection<Podłoże> Podłoże
        {
            get
            {
                return podłoże;
            }
            set
            {
                podłoże = value;
                onPropertyChanged(nameof(Podłoże));
            }
        }
        public ObservableCollection<Podłoże> PustePodłoże
        {
            get { return pustepodłoże; }
            set
            {
                pustepodłoże = value;

                onPropertyChanged(nameof(PustePodłoże));
            }
        }
        private ICommand zaladujPodłoże = null;
        public ICommand ZaladujPodłoże
        {
            get
            {
                if (zaladujPodłoże == null)
                    zaladujPodłoże = new RelayCommand(
                        arg => {
                            if (BiezacaRoslina != null)
                            {
                                PustePodłoże = model.PobierzPodlozepoID(BiezacaRoslina);
                            }
                        },
                        arg => true
                        );

                return zaladujPodłoże;
            }
        }

        //MIEJSCE WYSTEPOWANIE
        public ObservableCollection<MiejsceWystepowania> MiejsceWystepowania
        {
            get
            {
                return miejscewystepowania;
            }
            set
            {
                miejscewystepowania = value;
                onPropertyChanged(nameof(MiejsceWystepowania));
            }
        }
        public ObservableCollection<MiejsceWystepowania> PusteMiejsceWystepowania
        {
            get { return pustemiejscewystepowania; }
            set
            {
                pustemiejscewystepowania = value;

                onPropertyChanged(nameof(PusteMiejsceWystepowania));
            }
        }
        private ICommand zaladujMiejsceWystepowania = null;
        public ICommand ZaladujMiejsceWystepowania
        {
            get
            {
                if (zaladujMiejsceWystepowania == null)
                    zaladujMiejsceWystepowania = new RelayCommand(
                        arg => {
                            if (BiezacaRoslina != null)
                            {
                                PusteMiejsceWystepowania = model.PobierzMiejsceWystepowania(BiezacaRoslina);
                            }
                        },
                        arg => true
                        );

                return zaladujMiejsceWystepowania;
            }
        }


        //dodanie rośliny do moich roslin
        private ICommand dodaj = null;

        public ICommand Dodaj => dodaj ?? (dodaj = new RelayCommand(
            arg =>
            {
                
                sbyte? id_osoby;
                sbyte? id_rosliny;
                int ilosc;
                
                //var osoba=null;

                foreach (var username in osoby)
                {
                    if (username.Imie == DBConnection.Username)
                    {

                        id_osoby = username.Id_osoby;
                        id_rosliny = BiezacaRoslina.Id_rosliny;
                        
                        var roslinka = new MojeRośliny(id_osoby, id_rosliny);

                        if (model.CzyRoslinaJestJuzWMoichRoślinach(roslinka))
                        {

                            MessageBox.Show("Zwiększono ilość!");
                            ilosc = model.ZnajdzIloscPoID(id_osoby, id_rosliny).Ilosc;
                            roslinka = new MojeRośliny(id_osoby, id_rosliny,ilosc);
                            ilosc += 1;
                            model.EdytujMojaRoslineWBazie(roslinka, ilosc);
                           
                        }
                        else
                        {
                            MessageBox.Show("Dodano roślinę!");
                            ilosc = 1;
                            roslinka= new MojeRośliny(id_osoby, id_rosliny,ilosc);
                            model.DodajRoslineDoMoichRoslin(roslinka, BiezacaRoslina);
                        }
                        break;
                    }
                }
                
            },

            arg =>
            {
            if (BiezacaRoslina == null)
                {
                    return false;
                }
                else
                {
                    foreach (var username in osoby)
                    {
                        if (username.Imie == DBConnection.Username)
                        {
                            if (username.Status == "uzytkownik" || username.Status == "specjalista")
                                return true;
                            else
                                return false;
                        }

                    }
                    return false;
                }
                
            }


            ));





    }
}
