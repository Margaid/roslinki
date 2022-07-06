using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace roslinkiXD.DAL
{
    using View;
    class DBConnection
    {
        private MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();

        public MySqlConnection conn;

        private static string username2, password2;

        public static string Username
        {
            get => username2;
        }
        public static string Password
        {
            get => password2;
        }

        public DBConnection(string username = "user", string password = "user", int login = 0)
        {
            //stworzenie connection stringa na podstawie danych zapisanych w Sttings do których mamy dostęp spoza aplikacji 
            username2 = username;
            password2 = password;
            stringBuilder.ConnectionString = null;
            stringBuilder.UserID = Username;
            stringBuilder.Server = "localhost";
            stringBuilder.Database = "rosliny_domowe";
            stringBuilder.Port = 3306;
            stringBuilder.Password = Password;
            string ss = stringBuilder.ConnectionString;
            Console.WriteLine(ss);
            if (login == 1)
            {
                try
                {
                    conn = new MySqlConnection(stringBuilder.ToString());
                    conn.Open();
                    MessageBox.Show("Połączono z bazką");
                    SecondWindow sec = new SecondWindow();
                    Application.Current.MainWindow.Close();
                    sec.Show();

                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Podano nieprawidłowy login lub hasło!");
                }
            }
        }
        private static DBConnection instance = null;
        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBConnection(Username, Password);
                // Console.WriteLine(instance);
                return instance;
            }
        }

        public MySqlConnection Connection => new MySqlConnection(stringBuilder.ToString());
    }
}
