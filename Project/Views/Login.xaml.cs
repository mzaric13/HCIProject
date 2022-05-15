using Project.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        public void LoginClick(object sender, RoutedEventArgs e)
        {
            if (this.email.Text.Length == 0 || this.password.Password.Length == 0)
            {
                Error error = new Error("Potrebno je popuniti sva polja, kako bi prijava bila uspešna.");
                error.ShowDialog();
            }
            else
            {
                MainWindow window = (MainWindow)Window.GetWindow(this);
                if (!window.users.systemUsers.ContainsKey(this.email.Text))
                {
                    Error error = new Error("Nepostojeća kombinacija kredencijala. Pokušajte ponovo.");
                    error.ShowDialog();
                }
                else
                {
                    if (!window.users.systemUsers[this.email.Text].password.Equals(this.password.Password))
                    {
                        Error error = new Error("Nepostojeća kombinacija kredencijala. Pokušajte ponovo.");
                        error.ShowDialog();
                    }
                    else
                    {
                        Success success = new Success("Uspešna prijava, dobrodošli!");
                        success.ShowDialog();
                        //TODO: u zavisnosti koji je korisnik ulogovan, baciti ga na njegovu stranicu (klijent, menadzer)
                    }
                }
            }
        }
    }
}
