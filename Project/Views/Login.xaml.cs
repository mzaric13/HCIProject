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
                if (!window.systemEntities.systemUsers.ContainsKey(this.email.Text))
                {
                    Error error = new Error("Nepostojeća kombinacija kredencijala. Pokušajte ponovo.");
                    error.ShowDialog();
                }
                else
                {
                    if (!window.systemEntities.systemUsers[this.email.Text].password.Equals(this.password.Password))
                    {
                        Error error = new Error("Nepostojeća kombinacija kredencijala. Pokušajte ponovo.");
                        error.ShowDialog();
                    }
                    else
                    {
                        Success success = new Success("Uspešna prijava, dobrodošli!");
                        success.ShowDialog();
                        window.systemEntities.loggedUser = window.systemEntities.systemUsers[this.email.Text];
                        if (window.systemEntities.systemUsers[this.email.Text].userType == Model.UserType.Client)
                        {
                            window.notLoggedIn.Visibility = Visibility.Hidden;
                            window.client.Visibility = Visibility.Visible;
                            window.loginPage.Visibility = Visibility.Hidden;
                        }
                        else if (window.systemEntities.systemUsers[this.email.Text].userType == Model.UserType.Manager)
                        {
                            window.notLoggedIn.Visibility = Visibility.Hidden;
                            window.manager.Visibility = Visibility.Visible;
                            window.loginPage.Visibility = Visibility.Hidden;
                        }
                    }
                }
            }
        }
    }
}
