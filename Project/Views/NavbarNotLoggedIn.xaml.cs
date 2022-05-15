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
        }

        public void RegisterClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.homePage.Visibility = Visibility.Hidden;
            window.loginPage.Visibility = Visibility.Hidden;
            window.registrationPage.Visibility = Visibility.Visible;
        }
    }
}
