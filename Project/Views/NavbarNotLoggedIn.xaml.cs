using Project.VideoView;
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
    /// Interaction logic for NavbarNotLoggedIn.xaml
    /// </summary>
    public partial class NavbarNotLoggedIn : UserControl
    {

        public NavbarNotLoggedIn()
        {
            InitializeComponent();
            Focusable= true;
        }

        public void HomeClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.homePage.Visibility = Visibility.Visible;
            window.loginPage.Visibility = Visibility.Hidden;
            window.registrationPage.Visibility = Visibility.Hidden;
        }

        public void LoginClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.homePage.Visibility = Visibility.Hidden;
            window.loginPage.Visibility = Visibility.Visible;
            window.registrationPage.Visibility= Visibility.Hidden;

            DeleteLoginInfo(window);

        }

        public void RegisterClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);

            window.homePage.Visibility = Visibility.Hidden;
            window.loginPage.Visibility = Visibility.Hidden;
            window.registrationPage.Visibility = Visibility.Visible;

            DeleteRegistrationInfo(window);
        }

        public void DeleteRegistrationInfo(MainWindow window)
        {
            window.registrationPage.name.Text = "";
            window.registrationPage.surname.Text = "";
            window.registrationPage.email.Text = "";
            window.registrationPage.password.Password = "";
            window.registrationPage.confirmPassword.Password = "";
            window.registrationPage.client.IsChecked = false;
            window.registrationPage.manager.IsChecked = false;
        }

        public void DeleteLoginInfo(MainWindow window)
        {
            window.loginPage.email.Text = "";
            window.loginPage.password.Password = "";
        }

        public void HelpClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            Window homeHelp;
            if (window.homePage.Visibility == Visibility.Visible)
            {
                homeHelp = new HomeHelp("home.html");
                homeHelp.Show();
            }
            else if (window.loginPage.Visibility == Visibility.Visible)
            {
                homeHelp = new HomeHelp("login.html");
                homeHelp.Show();
            }
            else if (window.registrationPage.Visibility == Visibility.Visible)
            {
                homeHelp = new HomeHelp("registration.html");
                homeHelp.Show();
            }       
        }

        public void VideoClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            Window videoWindow;
            if (window.homePage.Visibility == Visibility.Visible)
            {
                videoWindow = new Video("../../Videos/homePage.wmv");
                videoWindow.Show();
            }
            else if (window.registrationPage.Visibility == Visibility.Visible)
            {
                videoWindow = new Video("../../Videos/registrationPage.wmv");
                videoWindow.Show();
            }
            else if (window.loginPage.Visibility == Visibility.Visible)
            {
                videoWindow = new Video("../../Videos/login.wmv");
                videoWindow.Show();
            }
        }
    }
}
