using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace roslinkiXD.ViewModel
{
    using BaseClass;
    using roslinkiXD.Model;
    using roslinkiXD.DAL.Encje;
    using System.Collections.ObjectModel;
    using roslinkiXD.DAL;

    class TabDodajRoslinyViewModel:ViewModelBase
    {
        #region Składowe prywatne
        //referencja do instancji modelu
        private Model model = null;

        private string nazwa, trudnosc_uprawy, kwasowosc ;
        private int id_rzedu, id_naslo, maksymalna_wysokosc = 20, idZaznaczenia = -1;
        private bool dodawanieDostepne = true;
        private bool edycjaDostepna = false;
        private bool usuniecieDostepne = false;

        private ObservableCollection<Osoba> osoby = null;
        #endregion

        #region Konstruktory
        public TabDodajRoslinyViewModel(Model model)
        {
            this.model = model;
            RoślinyDomowe = model.Rośliny;
            osoby = model.Osoby;
        }
        #endregion

        #region Właściwości

        public RoślinyDomowe BiezacaRoslina { get; set; }

        public int Id_rzedu
        {
            get { return id_rzedu; }
            set
            {
                id_rzedu = value;
                onPropertyChanged(nameof(Id_rzedu));
            }
        }
        
        public string Nazwa
        {
            get { return nazwa; }
            set
            {
                nazwa = value;
                onPropertyChanged(nameof(Nazwa));
            }
        }
        public int Maksymalna_wysokosc
        {
            get { return maksymalna_wysokosc; }
            set
            {
                maksymalna_wysokosc = value;
                onPropertyChanged(nameof(Maksymalna_wysokosc));
            }
        }
        public string Trudnosc_uprawy
        {
            get { return trudnosc_uprawy; }
            set
            {
                trudnosc_uprawy = value;
                onPropertyChanged(nameof(Trudnosc_uprawy));
            }
        }
        public string Kwasowosc
        {
            get { return kwasowosc; }
            set
            {
                kwasowosc = value;
                onPropertyChanged(nameof(Kwasowosc));
            }
        }
        public int Id_naslo
        {
            get { return id_naslo; }
            set
            {
                id_naslo = value;
                onPropertyChanged(nameof(Id_naslo));
            }
        }

        

        public int IdZaznaczenia
        {
            get { return idZaznaczenia; }
            set
            {
                idZaznaczenia = value;
                onPropertyChanged(nameof(IdZaznaczenia));
            }
        }
        public ObservableCollection<RoślinyDomowe> RoślinyDomowe { get; set; }

        public bool DodawanieDostepne
        {
            get { return dodawanieDostepne; }
            set
            {
                dodawanieDostepne = value;
                onPropertyChanged(nameof(DodawanieDostepne));
            }
        }


        public bool EdycjaDostepna
        {
            get { return edycjaDostepna; }
            set
            {
                edycjaDostepna = value;
                onPropertyChanged(nameof(EdycjaDostepna));
            }
        }
        public bool UsuniecieDostepne
        {
            get { return usuniecieDostepne; }
            set
            {
                usuniecieDostepne = value;
                onPropertyChanged(nameof(UsuniecieDostepne));
            }
        }
        #endregion


        private void CzyscFormularz()
        {
            Id_rzedu = 0;
            Nazwa = "";
            Maksymalna_wysokosc = 20;
            Trudnosc_uprawy = "";
            Kwasowosc = "";
            Id_naslo = 0;
            DodawanieDostepne = true;
            EdycjaDostepna = false;
            UsuniecieDostepne = false;
        }

        #region Polecenia
        // Polecenie Dodaj odpowiedzialne za dodane nowych roślin do bazy danych
        private ICommand dodaj = null;

        public ICommand Dodaj
        {

            get
            {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            var roslina = new RoślinyDomowe((sbyte)Id_rzedu, Nazwa, (sbyte)Maksymalna_wysokosc, Trudnosc_uprawy, Kwasowosc, (sbyte)Id_naslo);
                            if (model.DodajRoslineDoBazy(roslina))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Roślina została dodana do bazy!");
                            }
                        }
                        ,
                        arg =>
                        {
                            foreach (var username in osoby)
                            {
                                if (username.Imie == DBConnection.Username)
                                {
                                    if (username.Status == "specjalista")
                                    {
                                        if ((Nazwa != "") && (Id_rzedu != 0) && (Id_naslo != 0))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }

                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }

                            }
                            return false;


                        }
                           
                        );


                return dodaj;
            }

        }
        private ICommand ladujFormularz = null;
        public ICommand LadujFormularz
        {

            get
            {
                if (ladujFormularz == null)
                    ladujFormularz = new RelayCommand(
                        arg =>
                        {
                            if (IdZaznaczenia > -1)
                            {
                                Nazwa = BiezacaRoslina.Nazwa;
                                Kwasowosc = BiezacaRoslina.Kwasowosc;
                                Trudnosc_uprawy = BiezacaRoslina.Trudnosc_uprawy;
                                Id_naslo = BiezacaRoslina.Id_naslo;
                                Id_rzedu = BiezacaRoslina.Id_rzedu;
                                Maksymalna_wysokosc = BiezacaRoslina.Maksymalna_wysokosc;
                                DodawanieDostepne = false;
                                EdycjaDostepna = true;
                                UsuniecieDostepne = true;
                            }
                            else
                            {
                                Nazwa = "";
                                Kwasowosc = "";
                                Id_rzedu = 0;
                                Maksymalna_wysokosc = 0;
                                Id_naslo = 0;
                                Trudnosc_uprawy = "";
                                DodawanieDostepne = true;
                                EdycjaDostepna = false;
                                UsuniecieDostepne = false;
                            }
                        }
                        ,
                        arg => true
                        );


                return ladujFormularz;
            }

        }
        private ICommand edytuj = null;

        public ICommand Edytuj
        {
            get
            {
                if (edytuj == null)
                    edytuj = new RelayCommand(
                    arg =>
                    {
                        string us = DBConnection.Username;
                        Console.WriteLine(us);
                        model.EdytujRoslineWBazie(new RoślinyDomowe((sbyte)Id_rzedu, Nazwa, (sbyte)Maksymalna_wysokosc, Trudnosc_uprawy, Kwasowosc, (sbyte)Id_naslo), (sbyte)BiezacaRoslina.Id_rosliny);
                        IdZaznaczenia = -1;
                        DodawanieDostepne = true;
                        UsuniecieDostepne = false;
                    }
                         ,
                    arg =>
                    {
                        foreach (var username in osoby)
                        {
                            if (username.Imie == DBConnection.Username)
                            {
                                if (username.Status == "specjalista")
                                {
                                    if ((BiezacaRoslina?.Nazwa != Nazwa) || (BiezacaRoslina?.Maksymalna_wysokosc != Maksymalna_wysokosc) || (BiezacaRoslina?.Trudnosc_uprawy != Trudnosc_uprawy) || (BiezacaRoslina?.Kwasowosc != Kwasowosc) || (BiezacaRoslina?.Id_naslo != Id_naslo) || (BiezacaRoslina?.Id_rzedu != Id_rzedu))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }

                                }
                                else
                                {
                                    return false;
                                }
                            }

                        }
                        return false;
                    }
                        );


                return edytuj;
            }
        }

        private ICommand usun = null;

        public ICommand Usun
        {
            get
            {
                if (usun == null)
                    usun = new RelayCommand(
                    arg =>
                    {
                        model.UsunRoslineWBazie(new RoślinyDomowe((sbyte)Id_rzedu, Nazwa, (sbyte)Maksymalna_wysokosc, Trudnosc_uprawy, Kwasowosc, (sbyte)Id_naslo), (sbyte)BiezacaRoslina.Id_rosliny);
                        IdZaznaczenia = -1;
                        DodawanieDostepne = true;
                        EdycjaDostepna = false;
                    }
                         ,
                    arg => {

                        foreach (var username in osoby)
                        {
                            if (username.Imie == DBConnection.Username)
                            {
                                if (username.Status == "specjalista")
                                {
                                    if ((BiezacaRoslina?.Nazwa == Nazwa) && (BiezacaRoslina?.Maksymalna_wysokosc == Maksymalna_wysokosc) && (BiezacaRoslina?.Trudnosc_uprawy == Trudnosc_uprawy) && (BiezacaRoslina?.Kwasowosc == Kwasowosc) && (BiezacaRoslina?.Id_naslo == Id_naslo) && (BiezacaRoslina?.Id_rzedu == Id_rzedu))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }

                                }
                                else
                                {
                                    return false;
                                }
                            }

                        }
                        return false;


                    }
                        );


                return usun;
            }
        }
        #endregion

    }
}
