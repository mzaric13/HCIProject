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
    /// Interaction logic for NavbarClient.xaml
    /// </summary>
    public partial class NavbarClient : UserControl
    {
        public NavbarClient()
        {
            InitializeComponent();
        }

        public void ClickWebRoutesView(object sender, RoutedEventArgs e)
        {

        }

        public void ClickRoutesView(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.routesReviewPage.Visibility = Visibility.Visible;
        }

        public void BuyTicketClick(object sender, RoutedEventArgs e)
        {

        }

        public void MyTicketsClick(object sender, RoutedEventArgs e)
        {

        }

        public void TimetableClick(object sender, RoutedEventArgs e)
        {

        }

        public void LogoutClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.systemEntities.loggedUser = null;
            window.notLoggedIn.Visibility = Visibility.Visible;
            window.client.Visibility = Visibility.Hidden;
            window.routesReviewPage.Visibility = Visibility.Hidden;
            //sve ostale prozore u clientu staviti na hidden
            window.homePage.Visibility = Visibility.Visible;
        }
    }
}
