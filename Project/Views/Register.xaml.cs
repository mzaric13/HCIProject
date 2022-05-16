using Project.Modals;
using Project.Model;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        public void RegistrationClick(object sender, RoutedEventArgs e)
        {
            if (this.name.Text.Length == 0 || this.surname.Text.Length == 0 || this.email.Text.Length == 0 ||
                this.password.Password.Length == 0 || this.confirmPassword.Password.Length == 0
                || (this.client.IsChecked == false && this.manager.IsChecked == false))
            {
                Error error = new Error("Potrebno je popuniti sva polja, kako bi registracija bila uspešna.");
                error.ShowDialog();
            }
            else if (!this.password.Password.Equals(this.confirmPassword.Password))
            {
                Error error = new Error("Šifra i potvrda šifre nisu iste.");
                error.ShowDialog();
            }
            else if (!IsValidEmail(this.email.Text))
            {
                Error error = new Error("E-mail adresa nije validnog formata.");
                error.ShowDialog();
            }
            else
            {
                UserType userType = UserType.Client;
                if (this.manager.IsChecked == true)
                {
                    userType = UserType.Manager;
                }
                
                MainWindow window = (MainWindow)Window.GetWindow(this);
                if (window.systemEntities.systemUsers.ContainsKey(this.email.Text))
                {
                    Error error = new Error("Korisnik sa unetom e-mail adresom već postoji u sistemu.");
                    error.ShowDialog();
                }
                else
                {
                    window.systemEntities.systemUsers.Add(this.email.Text,
                    new User(this.name.Text, this.surname.Text, this.email.Text, this.password.Password, userType));

                    Success success = new Success("Uspešno ste kreirali nalog.");
                    success.ShowDialog();


                    window.homePage.Visibility = Visibility.Visible;
                    window.loginPage.Visibility = Visibility.Hidden;
                    window.registrationPage.Visibility = Visibility.Hidden;
                }
                
            }
        }
        //https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
        public bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }

        }
    }
}
