using Project.Modals;
using Project.Model;
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

            window.routeCrudPage.isMainWindowOpened = true;

            window.trainCrudPage.Visibility = Visibility.Hidden;
            window.timetableCrudPage.Visibility = Visibility.Hidden;
            window.routeCrudPage.Visibility = Visibility.Visible;
            window.boardingCarsViewManager.Visibility = Visibility.Hidden;
            window.stationsPosition.Visibility = Visibility.Hidden;

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
            window.stationsPosition.Visibility = Visibility.Hidden;
        }

        public void TrainsClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.trainCrudPage.Visibility = Visibility.Visible;
            window.timetableCrudPage.Visibility = Visibility.Hidden;
            window.routeCrudPage.Visibility = Visibility.Hidden;
            window.boardingCarsViewManager.Visibility = Visibility.Hidden;
            window.stationsPosition.Visibility = Visibility.Hidden;

            window.trainCrudPage.isMainWindowOpened = true;

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
            window.boardingCarsViewManager.Visibility = Visibility.Hidden;
            window.stationsPosition.Visibility = Visibility.Hidden;

            ButtonAutomationPeer peer = new ButtonAutomationPeer(window.timetableCrudPage.showAllTimetables);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        public void StationsClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);

            window.trainCrudPage.Visibility = Visibility.Hidden;
            window.timetableCrudPage.Visibility = Visibility.Hidden;
            window.routeCrudPage.Visibility = Visibility.Hidden;
            window.boardingCarsViewManager.Visibility = Visibility.Hidden;
            window.stationsPosition.Visibility = Visibility.Visible;

            if (window.systemEntities.systemTrainStations[0].X == -1)
            {
                setStationsCoordinates();
            }
            if (window.stationsPosition.drawSurface.Children.Count == 0)
            {
                drawRectangles();
            }

        }

        private void setStationsCoordinates()
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            double gridHeight = window.stationsPosition.drawSurface.ActualHeight;
            double gridWidth = window.stationsPosition.stationsGrid.ActualWidth;
            double diffHeight = gridHeight / (window.systemEntities.systemTrainStations.Count + 2);
            double diffWidth = gridWidth / (window.systemEntities.systemTrainStations.Count + 2);
            double posX = diffWidth;
            double posY = diffHeight;

            foreach (TrainStation trainstation in window.systemEntities.systemTrainStations)
            {
                trainstation.X = posX;
                trainstation.Y = posY;
                posX += diffWidth;
                posY += diffHeight;
            }
        }

        private void drawRectangles()
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            double gridHeight = window.stationsPosition.drawSurface.ActualHeight;
            double gridWidth = window.stationsPosition.stationsGrid.ActualWidth;
            int number = 1;
            foreach (TrainStation trainStation in window.systemEntities.systemTrainStations)
            {
                CreateRectangle(trainStation, number, gridHeight, gridWidth);
                number++;
            }
        }

        private void CreateRectangle(TrainStation trainStation, int number, double gridHeight, double gridWidth)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            Border border = new Border();
            border.Height = gridHeight / 10;
            border.Width = gridWidth / 7;
            border.BorderBrush = new SolidColorBrush(System.Windows.Media.Colors.Black);
            border.Background = new SolidColorBrush(System.Windows.Media.Colors.LightBlue);
            border.BorderThickness = new Thickness(3, 3, 3, 3);
            border.MouseMove += window.stationsPosition.Border_MouseMove;

            Label label = new Label();
            label.Content = number + ". " + trainStation.Name;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.FontFamily = new FontFamily("Arial black");
            label.FontSize = gridHeight / 40;
            border.Child = label;

            window.stationsPosition.drawSurface.Children.Insert(number - 1, border);
            Canvas.SetTop(border, trainStation.Y);
            Canvas.SetLeft(border, trainStation.X);
        }


        public void LogoutClick(object sender, RoutedEventArgs e)
        {
            Success success = new Success("Uspešno ste se odjavili sa sistema!");
            success.ShowDialog();
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
            window.stationsPosition.Visibility = Visibility.Hidden;
        }

        public void HelpClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            Window homeHelp;
            if (window.boardingCarsViewManager.Visibility == Visibility.Visible)
            {
                homeHelp = new HomeHelp("boardingCardsManager.html");
                homeHelp.Show();
            }
            else if (window.trainCrudPage.Visibility == Visibility.Visible)
            {
                homeHelp = new HomeHelp("trainCrud.html");
                homeHelp.Show();
            }
            else if (window.routeCrudPage.Visibility == Visibility.Visible)
            {
                homeHelp = new HomeHelp("routeCrud.html");
                homeHelp.Show();
            }
            else if (window.timetableCrudPage.Visibility == Visibility.Visible)
            {
                homeHelp = new HomeHelp("timetableCrud.html");
                homeHelp.Show();
            }
            else if (window.stationsPosition.Visibility == Visibility.Visible)
            {
                homeHelp = new HomeHelp("stationsPosition.html");
                homeHelp.Show();
            }
        }
    }
}
