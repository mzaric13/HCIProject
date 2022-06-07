using Project.Modals;
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
    /// Interaction logic for NavbarClient.xaml
    /// </summary>
    public partial class NavbarClient : UserControl
    {
        public NavbarClient()
        {
            InitializeComponent();
        }

        public void ClickRoutesView(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.routesReviewPage.Visibility = Visibility.Visible;
            window.routesReviewPage.routesGrid.Background.Opacity = 0;
            window.routesReviewPage.drawSurface.Visibility = Visibility.Hidden;
            window.routesReviewPage.labelTitle.Visibility = Visibility.Visible;
            window.routesReviewPage.labelFrom.Visibility = Visibility.Visible;
            window.routesReviewPage.startingStation.Visibility = Visibility.Visible;
            window.routesReviewPage.labelTo.Visibility = Visibility.Visible;
            window.routesReviewPage.endingStation.Visibility = Visibility.Visible;
            window.routesReviewPage.search.Visibility = Visibility.Visible;
            window.routesReviewPage.reset.Visibility = Visibility.Visible;
            window.routesReviewPage.tableRoutes.Visibility = Visibility.Visible;
            window.routesReviewPage.back.Visibility = Visibility.Hidden;
            window.routesReviewPage.drawSurface.Children.Clear();
            window.timetableReviewPage.Visibility = Visibility.Hidden;
        }

        public void BuyTicketClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.cardBuyingPage.Visibility = Visibility.Visible;
            window.timetableReviewPage.Visibility = Visibility.Hidden;
            window.routesReviewPage.Visibility= Visibility.Hidden;
        }

        public void MyTicketsClick(object sender, RoutedEventArgs e)
        {

        }

        public void TimetableClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.timetableReviewPage.Visibility = Visibility.Visible;
            mainWindow.routesReviewPage.Visibility = Visibility.Hidden;
            mainWindow.cardBuyingPage.Visibility = Visibility.Hidden;
        }

        public void LogoutClick(object sender, RoutedEventArgs e)
        {
            Success success = new Success("Uspešno ste se odjavili sa sistema!");
            success.ShowDialog();
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.systemEntities.loggedUser = null;
            window.notLoggedIn.Visibility = Visibility.Visible;
            window.client.Visibility = Visibility.Hidden;
            window.routesReviewPage.Visibility = Visibility.Hidden;
            window.timetableReviewPage.Visibility = Visibility.Hidden;
            window.cardBuyingPage.Visibility = Visibility.Hidden;
            //sve ostale prozore u clientu staviti na hidden
            window.homePage.Visibility = Visibility.Visible;
        }

        public void HelpClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            Window homeHelp;
            if (window.timetableReviewPage.Visibility == Visibility.Visible)
            {
                homeHelp = new HomeHelp("timetableReview.html");
                homeHelp.Show();
            }
            else if (window.routesReviewPage.Visibility == Visibility.Visible)
            {
                homeHelp = new HomeHelp("routesReview.html");
                homeHelp.Show();
            }
            //else if...
        }

        public void VideoClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            Window videoWindow;
            if (window.timetableReviewPage.Visibility == Visibility.Visible)
            {
                videoWindow = new Video("../../Videos/timetableReview.wmv");
                videoWindow.Show();
            }
            else if (window.routesReviewPage.Visibility == Visibility.Visible)
            {
                videoWindow = new Video("../../Videos/routesReview.wmv");
                videoWindow.Show();
            }
            //else if...
        }
    }
}
