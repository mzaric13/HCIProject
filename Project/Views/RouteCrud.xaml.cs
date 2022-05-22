using Project.Modals;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for RouteCrud.xaml
    /// </summary>
    public partial class RouteCrud : UserControl
    {
        private ObservableCollection<Route> routes = new ObservableCollection<Route>();
        public ObservableCollection<Route> Routes
        {
            get { return routes; }
            set { routes = value; }
        }

        private ObservableCollection<TrainStation> currentStations = new ObservableCollection<TrainStation>();
        private Route currentRouteCell;

        public Route CurrentRoute;

        public ObservableCollection<TrainStation> CurrentStations
        {
            get { return currentStations; }
            set { currentStations = value; }
        }

        public RouteCrud()
        {
            InitializeComponent();
        }
        public void fillRouteTable()
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            Routes = new ObservableCollection<Route>(window.systemEntities.systemRoutes);
            tableRoutes.ItemsSource = Routes;
        }

        private void RouteCrudLoaded(object sender, RoutedEventArgs e)
        {
            fillRouteTable();
        }
        public void AddRoute(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            int maxIndex = window.systemEntities.systemRoutes.Max(t => t.Id);
            TrainStation ts1 = new TrainStation(1, "Beograd");
            TrainStation ts8 = new TrainStation(8, "Novi Sad");
            window.systemEntities.systemRoutes.Add(new Route(maxIndex + 1, ts8, ts1, new List<TrainStation> { }));
            fillRouteTable();
            Success success = new Success("Uspešno dodata nova linija Novi Sad - Beograd. Dodajte međustanice i izmenite" +
                "početnu i krajnju stanicu, ako je to potrebno.");
            success.ShowDialog();
        }

        public void ShowStations(object sender, RoutedEventArgs e)
        {
            tableRoutes.Visibility = Visibility.Hidden;
            nameRoute.Visibility = Visibility.Hidden;
            addRoute.Visibility = Visibility.Hidden;
            searchText.Visibility = Visibility.Hidden;
            searchRoutes.Visibility = Visibility.Hidden;
            showAllRoutes.Visibility = Visibility.Hidden;

            Route route = ((FrameworkElement)sender).DataContext as Route;
            CurrentRoute = route;
            currentStations = new ObservableCollection<TrainStation>(route.Stations);
            tableStations.ItemsSource = currentStations;

            tableStations.Visibility = Visibility.Visible;
            nameStation.Visibility = Visibility.Visible;
            addStation.Visibility = Visibility.Visible;
            searchTextStations.Visibility = Visibility.Visible;
            searchStations.Visibility = Visibility.Visible;
            showAllStations.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Visible;
        }

        private void tableRoutes_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "StartingStation")
            {
                e.Column.Header = "Početna stanica";
            }
            if (e.Column.Header.ToString() == "EndingStation")
            {
                e.Column.Header = "Krajnja stanica";
            }
            if (e.Column.Header.ToString() == "Stations")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            if (e.Column.Header.ToString() == "Id")
            {
                e.Column.Header = "Broj linije";
                e.Column.IsReadOnly = true;
            }
            if (e.Column is DataGridTextColumn textColumn)
                textColumn.Binding = new Binding(e.PropertyName) { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };

        }

        public void DeleteRoute(object sender, RoutedEventArgs e)
        {
            YesNoModal yesNoModal = new YesNoModal("Da li ste sigurni da želite da obrišete odabranu liniju?");
            yesNoModal.ShowDialog();
            if (yesNoModal.response)
            {
                MainWindow window = (MainWindow)Window.GetWindow(this);
                Route route = ((FrameworkElement)sender).DataContext as Route;
                foreach (Route r in window.systemEntities.systemRoutes)
                {
                    if (route.Id == r.Id)
                    {
                        window.systemEntities.systemRoutes.Remove(r);
                        fillRouteTable();
                        break;
                    }
                }
            }
        }

        private void tableRoutes_AutoGeneratedColumns(object sender, EventArgs e)
        {
            var grid = (DataGrid)sender;
            foreach (var item in grid.Columns)
            {
                if (item.Header.ToString() == "Obriši")
                {
                    item.DisplayIndex = grid.Columns.Count - 1;
                    break;
                }
            }
            foreach (var item in grid.Columns)
            {
                if (item.Header.ToString() == "Međustanice")
                {
                    item.DisplayIndex = grid.Columns.Count - 2;
                    break;
                }
            }

        }

        public void ShowAllRoutes(object sender, RoutedEventArgs e)
        {
            fillRouteTable();
        }

        public void SearchRoutes(object sender, RoutedEventArgs e)
        {
            if (searchText.Text.Length == 0)
            {
                Error error = new Error("Niste uneli nijedan karakter za pretraživanje!");
                error.ShowDialog();
            }
            else
            {
                MainWindow window = (MainWindow)Window.GetWindow(this);
                List<Route> searchedRoutes = new List<Route>();
                foreach (Route route in window.systemEntities.systemRoutes)
                {
                    if (route.StartingStation.Name.ToLower().Contains(searchText.Text.ToLower()) || route.EndingStation.Name.ToLower().Contains(searchText.Text.ToLower()))
                    {
                        searchedRoutes.Add(route);
                    }
                }
                Routes = new ObservableCollection<Route>(searchedRoutes);
                tableRoutes.ItemsSource = Routes;
            }

        }

        public void DeleteStation(object sender, RoutedEventArgs e)
        {
            YesNoModal yesNoModal = new YesNoModal("Da li ste sigurni da želite da obrišete odabranu stanicu?");
            yesNoModal.ShowDialog();
            if (yesNoModal.response)
            {
                MainWindow window = (MainWindow)Window.GetWindow(this);
                TrainStation trainStation = ((FrameworkElement)sender).DataContext as TrainStation;
                foreach (TrainStation station in currentStations)
                {
                    if (trainStation.Id == station.Id)
                    {
                        currentStations.Remove(station);
                        CurrentRoute.Stations.Remove(station);
                        break;
                    }
                }
            }
        }

        public void AddStation(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            int maxIndex = window.systemEntities.systemStations.Max(t => t.Id);
            currentStations.Add(new TrainStation(maxIndex+1, "Beograd_" + maxIndex.ToString()));
            CurrentRoute.Stations.Add(new TrainStation(maxIndex+1, "Beograd_" + maxIndex.ToString()));
            window.systemEntities.systemStations.Add(new TrainStation(maxIndex+1, "Beograd_"+maxIndex.ToString()));
            Success success = new Success("Uspešno dodata nova stanica Beograd_" + (maxIndex+1).ToString() + ". Izmenite" +
                " naziv stanice ako je to potrebno.");
            success.ShowDialog();
        }

        public void SearchStations(object sender, RoutedEventArgs e)
        {
            if (searchTextStations.Text.Length == 0)
            {
                Error error = new Error("Niste uneli nijedan karakter za pretraživanje!");
                error.ShowDialog();
            }
            else
            {
                MainWindow window = (MainWindow)Window.GetWindow(this);
                List<TrainStation> searchedStations = new List<TrainStation>();
                foreach (TrainStation trainStation in currentStations)
                {
                    if (trainStation.Name.ToLower().Contains(searchTextStations.Text.ToLower()))
                    {
                        searchedStations.Add(trainStation);
                    }
                }
                currentStations = new ObservableCollection<TrainStation>(searchedStations);
                tableStations.ItemsSource = currentStations;
            }
        }

        public void ShowAllStations(object sender, RoutedEventArgs e)
        {
            currentStations = new ObservableCollection<TrainStation>(CurrentRoute.Stations);
            tableStations.ItemsSource = currentStations;
        }

        private void tableStations_AutoGeneratedColumns(object sender, EventArgs e)
        {
            var grid = (DataGrid)sender;
            foreach (var item in grid.Columns)
            {
                if (item.Header.ToString() == "Obriši")
                {
                    item.DisplayIndex = grid.Columns.Count - 1;
                    break;
                }
            }
        }

        private void tableStations_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            if (e.Column.Header.ToString() == "Name")
            {
                e.Column.Header = "Naziv stanice";
            }
        }

        public void Back(object sender, RoutedEventArgs e)
        {
            tableRoutes.Visibility = Visibility.Visible;
            nameRoute.Visibility = Visibility.Visible;
            addRoute.Visibility = Visibility.Visible;
            searchText.Visibility = Visibility.Visible;
            searchRoutes.Visibility = Visibility.Visible;
            showAllRoutes.Visibility = Visibility.Visible;

            tableStations.Visibility = Visibility.Hidden;
            nameStation.Visibility = Visibility.Hidden;
            addStation.Visibility = Visibility.Hidden;
            searchTextStations.Visibility = Visibility.Hidden;
            searchStations.Visibility = Visibility.Hidden;
            showAllStations.Visibility = Visibility.Hidden;
            back.Visibility = Visibility.Hidden;
        }

        private void tableRoutes_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string columnName = e.Column.Header.ToString();
            if (columnName == "Početna stanica" || columnName == "Krajnja stanica")
            {
                int index = e.Row.GetIndex();
                var element = e.EditingElement as TextBox;
                string s = (((TextBox)e.EditingElement).Text);
                MainWindow window = (MainWindow)Window.GetWindow(this);
                bool exists = false;
                foreach (TrainStation trainStation in window.systemEntities.systemStations)
                {
                    if (columnName == "Početna stanica")
                    {
                        if (s == trainStation.Name)
                        {
                            exists = true;
                        }
                    }
                    if (columnName == "Krajnja stanica")
                    {
                        if (s == trainStation.Name)
                        {
                            exists = true;
                        }
                    }
                    if (exists)
                    {
                        break;
                    }
                }
                if (!exists)
                {
                    string stations = "";
                    foreach (TrainStation trainStation in window.systemEntities.systemStations)
                    {
                        stations += trainStation.Name + ", ";
                    }
                    stations = stations.Substring(0, stations.Length - 2);
                    Error error = new Error("Ne postoji stanica sa datim nazivom! Validne stanice: " + stations);
                    error.ShowDialog();
                }
                else
                {
                    TrainStation trainStation = null; 
                    foreach (TrainStation station in window.systemEntities.systemStations)
                    {
                        if (station.Name == s)
                        {
                            trainStation = station;
                        }
                    }
                    if (columnName == "Početna stanica")
                    {
                        window.systemEntities.systemRoutes[index].StartingStation = trainStation;
                        Success success = new Success("Uspešno promenjena početna stanica!");
                        success.ShowDialog();
                    }
                    else if (columnName == "Krajnja stanica")
                    {
                        window.systemEntities.systemRoutes[index].EndingStation = trainStation;
                        Success success = new Success("Uspešno promenjena krajnja stanica!");
                        success.ShowDialog();
                    }
                }
            }
            ButtonAutomationPeer peer = new ButtonAutomationPeer(showAllRoutes);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        private void tableRoutes_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (e.Column.Header.ToString() == "Početna stanica" || e.Column.Header.ToString() == "Krajnja stanica")
            {
                TextBlock tb = (TextBlock)e.Column.GetCellContent(e.Row);
                Route item = (Route)tb.DataContext;
                currentRouteCell = item;
            }
        }
    }
}
