using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
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
            window.timetableCrudPage.Visibility = Visibility.Hidden;
            window.routeCrudPage.Visibility = Visibility.Visible;
            window.boardingCarsViewManager.Visibility = Visibility.Hidden;

            window.routeCrudPage.tableRoutes.Visibility = Visibility.Visible;
            window.routeCrudPage.nameRoute.Visibility = Visibility.Visible;
            window.routeCrudPage.addRoute.Visibility = Visibility.Visible;
            window.routeCrudPage.searchText.Visibility = Visibility.Visible;
            window.routeCrudPage.searchRoutes.Visibility = Visibility.Visible;
            window.routeCrudPage.showAllRoutes.Visibility = Visibility.Visible;

            window.routeCrudPage.tableStations.Visibility = Visibility.Hidden;
            window.routeCrudPage.nameStation.Visibility = Visibility.Hidden;
            window.routeCrudPage.addStation.Visibility = Visibility.Hidden;
            window.routeCrudPage.searchTextStations.Visibility = Visibility.Hidden;
            window.routeCrudPage.searchStations.Visibility = Visibility.Hidden;
            window.routeCrudPage.showAllStations.Visibility = Visibility.Hidden;
            window.routeCrudPage.back.Visibility = Visibility.Hidden;

            ButtonAutomationPeer peer = new ButtonAutomationPeer(window.routeCrudPage.showAllRoutes);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        public void TicketsClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.trainCrudPage.Visibility = Visibility.Hidden;
            window.timetableCrudPage.Visibility = Visibility.Hidden;
            window.routeCrudPage.Visibility = Visibility.Hidden;
            window.boardingCarsViewManager.Visibility = Visibility.Visible;
        }

        public void TrainsClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.trainCrudPage.Visibility = Visibility.Visible;
            window.timetableCrudPage.Visibility = Visibility.Hidden;
            window.routeCrudPage.Visibility = Visibility.Hidden;
            window.boardingCarsViewManager.Visibility = Visibility.Hidden;

            window.trainCrudPage.tableTrains.Visibility = Visibility.Visible;
            window.trainCrudPage.nameTrain.Visibility = Visibility.Visible;
            window.trainCrudPage.addTrain.Visibility = Visibility.Visible;
            window.trainCrudPage.searchText.Visibility = Visibility.Visible;
            window.trainCrudPage.searchTrains.Visibility = Visibility.Visible;
            window.trainCrudPage.showAllTrains.Visibility = Visibility.Visible;

            window.trainCrudPage.tableTimetables.Visibility = Visibility.Hidden;
            window.trainCrudPage.nameTimetable.Visibility = Visibility.Hidden;
            window.trainCrudPage.addTimetable.Visibility = Visibility.Hidden;
            window.trainCrudPage.searchTextTimetable.Visibility = Visibility.Hidden;
            window.trainCrudPage.searchTimetables.Visibility = Visibility.Hidden;
            window.trainCrudPage.showAllTimetables.Visibility = Visibility.Hidden;
            window.trainCrudPage.back.Visibility = Visibility.Hidden;

            ButtonAutomationPeer peer = new ButtonAutomationPeer(window.trainCrudPage.showAllTrains);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        public void TimetableClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.trainCrudPage.Visibility = Visibility.Hidden;
            window.timetableCrudPage.Visibility = Visibility.Visible;
            window.routeCrudPage.Visibility = Visibility.Hidden;

            ButtonAutomationPeer peer = new ButtonAutomationPeer(window.timetableCrudPage.showAllTimetables);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
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
            window.timetableCrudPage.Visibility = Visibility.Hidden;
            window.routeCrudPage.Visibility = Visibility.Hidden;
            window.boardingCarsViewManager.Visibility = Visibility.Hidden;
        }

        public void HelpClick(object sender, RoutedEventArgs e)
        {
            //MainWindow window = (MainWindow)Window.GetWindow(this);
            //help 

        }
    }
}
