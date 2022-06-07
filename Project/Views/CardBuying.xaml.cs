using Project.Modals;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// Interaction logic for CardBuying.xaml
    /// </summary>
    public partial class CardBuying : UserControl
    {

        ObservableCollection<TrainStation> Stations = new ObservableCollection<TrainStation>();

        List<Timetable> Timetables = new List<Timetable>();

        public CardBuying()
        {
            InitializeComponent();
        }

        public void LoadStations(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            Stations = new ObservableCollection<TrainStation>(window.systemEntities.systemTrainStations);
            startingStation.ItemsSource = Stations;
            lastStation.ItemsSource = Stations;
            Timetables = window.systemEntities.systemTimetables;
        }

        public void SearchTimetables(object sender, RoutedEventArgs e)
        {
            if (startingStation.SelectedItem != null && lastStation.SelectedItem != null && datePick.SelectedDate != null)
            {
                if (startingStation.SelectedItem == lastStation.SelectedItem) {
                    showMessagesNoRoute();
                    return;
                }
                List<DataForCard> direct = directRoutes((TrainStation)startingStation.SelectedItem, (TrainStation)lastStation.SelectedItem, (DateTime)datePick.SelectedDate);
                if (direct.Count == 0)
                {
                    List<DataForCard> transfers = withTransfer((TrainStation)startingStation.SelectedItem, (TrainStation)lastStation.SelectedItem, (DateTime)datePick.SelectedDate);
                    if (transfers.Count == 0) showMessagesNoRoute();
                    else timetablesTable.ItemsSource = transfers;
                }else
                {
                    timetablesTable.ItemsSource = direct;
                }
                timetablesTable.Visibility = Visibility.Visible;
            }
            else
            {
                Error error = new Error("Niste uneli kriterijume pretraživanja! Morate uneti sve kriterijume.");
                error.ShowDialog();
            }
        }

        private List<DataForCard> directRoutes(TrainStation startingStation, TrainStation endingStation, DateTime date)
        {
            List<DataForCard> directRoutes = new List<DataForCard>();
            foreach (Timetable timetable in Timetables)
            {
                if (DateTime.ParseExact(timetable.startDate, "dd.MM.yyyy.", CultureInfo.CurrentCulture) == date)
                {
                    if (timetable.Route.StartingStation == startingStation && timetable.Route.EndingStation == endingStation) directRoutes.Add(new DataForCard(timetable, startingStation.Name, endingStation.Name, timetable.startTime, timetable.endTime, timetable.train.Operator, timetable.Route.Prices.Last()));
                    if (timetable.Route.Stations.Contains(startingStation) && timetable.Route.EndingStation == endingStation) directRoutes.Add(new DataForCard(timetable, startingStation.Name, endingStation.Name, timetable.startTime, timetable.endTime, timetable.train.Operator, timetable.Route.Prices.Last() - timetable.Route.Prices.ElementAt(timetable.Route.Stations.IndexOf(startingStation))));
                    if (timetable.Route.StartingStation == startingStation && timetable.Route.Stations.Contains(endingStation)) directRoutes.Add(new DataForCard(timetable, startingStation.Name, endingStation.Name, timetable.startTime, timetable.endTime, timetable.train.Operator, timetable.Route.Prices.ElementAt(timetable.Route.Stations.IndexOf(endingStation))));
                }
            }
            return directRoutes;
        }

        private List<DataForCard> withTransfer(TrainStation startingStation, TrainStation endingStation, DateTime date)
        {
            List<DataForCard> transferRoutes = new List<DataForCard>();
            foreach (Timetable timetable in Timetables)
            {
                if (DateTime.ParseExact(timetable.startDate, "dd.MM.yyyy.", CultureInfo.CurrentCulture) == date)
                {
                    if (timetable.Route.StartingStation == startingStation || timetable.Route.Stations.Contains(startingStation))
                    {
                        foreach (Timetable timetable1 in Timetables)
                        {
                            if (DateTime.ParseExact(timetable1.startDate, "dd.MM.yyyy.", CultureInfo.CurrentCulture) == date)
                            {
                                if (timetable1.Route.StartingStation == timetable.Route.EndingStation && compareTimes(timetable.endTime, timetable1.startTime))
                                {
                                    if (timetable1.Route.Stations.Contains(endingStation) || timetable1.Route.EndingStation == endingStation)
                                    {
                                        transferRoutes.Add(createDataForCard(timetable, timetable1, startingStation, endingStation));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return transferRoutes;
        }

        private bool compareTimes(string endTimeFirst, string startTimeSecond)
        {
            if (Int32.Parse(endTimeFirst.Split(':')[0]) < Int32.Parse(startTimeSecond.Split(':')[0])) return true;
            else if (Int32.Parse(endTimeFirst.Split(':')[0]) == Int32.Parse(startTimeSecond.Split(':')[0]))
            {
                if (Int32.Parse(endTimeFirst.Split(':')[1]) < Int32.Parse(startTimeSecond.Split(':')[1])) return true;
                else return false;
            }else return false;
        }

        private DataForCard createDataForCard(Timetable timetable, Timetable timetable1, TrainStation startingStation, TrainStation endingStation)
        {
            int idx = timetable.Route.Stations.IndexOf(startingStation);
            int price = 0;
            if (idx == -1) price += timetable.Route.Prices.Last();
            else price += timetable.Route.Prices.Last() - timetable.Route.Prices.ElementAt(idx);
            idx = timetable1.Route.Stations.IndexOf(endingStation);
            if (idx == -1) price += timetable1.Route.Prices.Last();
            else price += timetable1.Route.Prices.ElementAt(idx);
            return new DataForCard(new List<Timetable> { timetable, timetable1 }, startingStation.Name, endingStation.Name, timetable.startTime, timetable1.endTime, timetable.train.Operator + " -> " + timetable1.train.Operator, price);
        }

        private void showMessagesNoRoute()
        {
            Error error = new Error("Ne postoji linija za zadate kriterijume!");
            error.ShowDialog();
        }

        public void tableTimetable_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "StartingTime")
            {
                e.Column.Header = "Polazak ";
            }
            if (e.Column.Header.ToString() == "EndingTime")
            {
                e.Column.Header = "Dolazak ";
            }
            if (e.Column.Header.ToString() == "StartingStation")
            {
                e.Column.Header = "Početna stanica";
            }
            if (e.Column.Header.ToString() == "EndingStation")
            {
                e.Column.Header = "Krajnja stanica";
            }
            if (e.Column.Header.ToString() == "TrainName")
            {
                e.Column.Header = "Voz";
            }
            if (e.Column.Header.ToString() == "Price")
            {
                e.Column.Header = "Cena(RSD)";
            }
            if (e.Column.Header.ToString() == "Timetables")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void tableTimetable_AutoGeneratedColumns(object sender, EventArgs e)
        {
            var grid = (DataGrid)sender;
            foreach (var item in grid.Columns)
            {
                if (item.Header.ToString() == "Količina")
                {
                    item.DisplayIndex = grid.Columns.Count - 1;
                }
                if (item.Header.ToString() == "Rezerviši")
                {
                    item.DisplayIndex = grid.Columns.Count - 1;
                }
                if (item.Header.ToString() == "Kupi kartu")
                {
                    item.DisplayIndex = grid.Columns.Count - 1;
                }
            }
        }

        public void BuyCard(object sender, RoutedEventArgs e)
        {
            DataForCard dataForCard = ((FrameworkElement)sender).DataContext as DataForCard;
            MainWindow window = (MainWindow)Window.GetWindow(this);
            BoardingCard boardingCard = new BoardingCard(window.systemEntities.loggedUser, dataForCard.Timetables, DateTime.Now.Date.ToString(), BoardingCardState.BOUGHT);
            window.systemEntities.systemBoardingCards.Add(boardingCard);
            Success success = new Success("Uspešno ste kupili kartu, možete je pregledati među vašim kartama!");
            success.Show();
            backToNormal();
        }

        public void Reserve(object sender, RoutedEventArgs e)
        {
            DataForCard dataForCard = ((FrameworkElement)sender).DataContext as DataForCard;
            MainWindow window = (MainWindow)Window.GetWindow(this);
           
            BoardingCard boardingCard = new BoardingCard(window.systemEntities.loggedUser, dataForCard.Timetables, DateTime.Now.Date.ToString(), BoardingCardState.RESERVED);
            window.systemEntities.systemBoardingCards.Add(boardingCard);
            Success success = new Success("Uspešno ste rezervisali kartu, možete je kupiti ili otkazati!");
            success.Show();
            backToNormal();
        }

        private void backToNormal()
        {
            timetablesTable.Visibility = Visibility.Hidden;
            datePick.SelectedDate = null;
            startingStation.SelectedItem = null;
            lastStation.SelectedItem = null;
        }
    }
}
