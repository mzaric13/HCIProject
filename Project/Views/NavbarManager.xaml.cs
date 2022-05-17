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
    /// Interaction logic for NavbarManager.xaml
    /// </summary>
    public partial class NavbarManager : UserControl
    {
        public NavbarManager()
        {
            InitializeComponent();
        }

        public void TrainLinesClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.trainCrudPage.Visibility = Visibility.Hidden;
        }

        public void TicketsClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.trainCrudPage.Visibility = Visibility.Hidden;
        }

        public void TrainsClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.trainCrudPage.Visibility = Visibility.Visible;
        }

        public void TimetableClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.trainCrudPage.Visibility = Visibility.Hidden;
        }

        public void LogoutClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.systemEntities.loggedUser = null;
            window.notLoggedIn.Visibility = Visibility.Visible;
            window.manager.Visibility = Visibility.Hidden;
            //sve ostale prozore u manageru staviti na hidden
            window.homePage.Visibility = Visibility.Visible;
            window.trainCrudPage.Visibility = Visibility.Hidden;
        }
    }
}
