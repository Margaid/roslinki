using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roslinkiXD.ViewModel
{
    using BaseClass;
    using roslinkiXD.Model;
    using roslinkiXD.DAL.Encje;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using System.Windows;
    using roslinkiXD.DAL;
    using roslinkiXD.DAL.Repozytoria;

    class TabMojeRoslinyViewModel : ViewModelBase
    {
        private Model model = null;
        private int ilosc;
        private ObservableCollection<Osoba> osoby = null;

        private ObservableCollection<MojeRośliny> mojerosliny = null;
        private ObservableCollection<MojeRośliny> pustemojerosliny = null;

        public ObservableCollection<RoślinyDomowe> roślinyID = null;
        public ObservableCollection<RoślinyDomowe> roślinyID2 = null;


        public TabMojeRoslinyViewModel(Model model)
        {
            this.model = model;
            osoby = model.Osoby;

            mojerosliny = model.MojeRosliny;
            PusteMojeRosliny = model.PusteMojeRosliny;

        }

        public int Ilosc
        {
            get { return ilosc; }
            set
            {
                ilosc = value;
                onPropertyChanged(nameof(ilosc));
            }
        }

        public ObservableCollection<MojeRośliny> MojeRosliny
        {
            get
            {
                return mojerosliny;
            }
            set
            {
                mojerosliny = value;
                onPropertyChanged(nameof(MojeRosliny));
            }
        }
        //public ObservableCollection<MojeRośliny> PusteMojeRosliny { get; set; }
        
        public ObservableCollection<MojeRośliny> PusteMojeRosliny
        {
            get { return pustemojerosliny; }
            set
            {
                pustemojerosliny = value;

                onPropertyChanged(nameof(PusteMojeRosliny));
            }
        }
        
        public ObservableCollection<RoślinyDomowe> RoślinyID
        {
            get
            {
                return roślinyID;
            }
            set
            {
                roślinyID = value;
                onPropertyChanged(nameof(RoślinyID));
            }
        }

        private ICommand sprawdzenie_uzytkownika = null;
        public ICommand Sprawdzenie_uzytkownika
        {
            get
            {
                if (sprawdzenie_uzytkownika == null)
                    sprawdzenie_uzytkownika = new RelayCommand(
                        arg =>
                        {
                            //Odpali sie konstruktor czy nie????
                            //osoby = model.Osoby;

                            foreach (var username in osoby)
                            {
                                if (username.Imie == DBConnection.Username)
                                {
                                    switch (username.Status)
                                    {

                                        case "uzytkownik":
                                            MessageBox.Show("Moje roslinki! - użytkownik");
                                            //PusteMojeRosliny = model.PobierzRoslinyPoID(username.Id_osoby);
                                            model.PobierzRoslinyPoID(username.Id_osoby);
                                            RoślinyID = model.PobierzNazwepoID(username.Id_osoby);
                                            break;
                                        case "specjalista":
                                            MessageBox.Show("Moje roslinki! - specjalista");
                                            //PusteMojeRosliny = model.PobierzRoslinyPoID(username.Id_osoby);
                                            model.PobierzRoslinyPoID(username.Id_osoby); 
                                            RoślinyID = model.PobierzNazwepoID(username.Id_osoby);
                                            break;

                                        case "niezalogowany":
                                            MessageBox.Show("Nie jesteś zalogowany!");
                                            break;

                                    }
                                    break;

                                }

                            }

                        },
                        arg => RoślinyID == null

                        );
                
                return sprawdzenie_uzytkownika;
            }
        }





    }
}
