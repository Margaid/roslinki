using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace roslinkiXD.ViewModel
{
    using BaseClass;
    using DAL;
    using View;
    class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {

        }



        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                onPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                onPropertyChanged(nameof(Password));
            }
        }



        private ICommand login;

        public ICommand Login => login ?? (login = new RelayCommand(
            arg =>
            {
                DBConnection con = new DBConnection(Username, Password, 1);

            },


            arg => Username != null & Password != null
          //dopisac tu jakoś Username!="" żeby nie było puste pole po wpisaniu


          ));

        private ICommand user;
        public ICommand User => user ?? (user = new RelayCommand(
            arg =>
            {
                DBConnection con = new DBConnection("user", "user", 1);
            },

            arg => true

            ));




    }
}
