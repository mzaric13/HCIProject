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
    /// Interaction logic for TimetableReview.xaml
    /// </summary>
    public partial class TimetableReview : UserControl
    {

        ObservableCollection<TrainStation> Stations = new ObservableCollection<TrainStation>();

        ObservableCollection<Timetable> Timetables = new ObservableCollection<Timetable>();

        public TimetableReview()
        {
            InitializeComponent();
        }

        private void fillTimetables()
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            Timetables = new ObservableCollection<Timetable>(window.systemEntities.systemTimetables);
            timetablesTable.ItemsSource = Timetables;
            Stations = new ObservableCollection<TrainStation>(window.systemEntities.systemTrainStations);
            startingStation.ItemsSource = Stations;
            lastStation.ItemsSource = Stations;
        }

        public void TimetableLoaded(object sender, RoutedEventArgs e)
        {
            fillTimetables();
        }

        public void tableTimetable_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "startTime")
            {
                e.Column.Header = "Polazak ";
            }
            if (e.Column.Header.ToString() == "startDate")
            {
                e.Column.Header = "Datum polaska ";
            }
            if (e.Column.Header.ToString() == "endTime")
            {
                e.Column.Header = "Dolazak ";
            }
            if (e.Column.Header.ToString() == "endDate")
            {
                e.Column.Header = "Datum dolaska ";
            }
            if (e.Column.Header.ToString() == "id")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            if (e.Column.Header.ToString() == "Route")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            if (e.Column.Header.ToString() == "train")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        public void SearchTimetables(object sender, RoutedEventArgs e)
        {
            if (startingStation.SelectedItem != null || lastStation.SelectedItem != null || datePick.SelectedDate != null)
            {
                ObservableCollection<Timetable> notMade = new ObservableCollection<Timetable>();
                if (startingStation.SelectedItem != null)
                {
                    foreach (Timetable t in Timetables)
                    {
                        if (!t.Route.StartingStation.Equals(startingStation.SelectedItem) && !notMade.Contains(t)) notMade.Add(t);
                    }
                }
                if (lastStation.SelectedItem != null)
                    foreach (Timetable t in Timetables)
                    {
                        if (!t.Route.EndingStation.Equals(lastStation.SelectedItem) && !t.Route.Stations.Contains(lastStation.SelectedItem) && !notMade.Contains(t)) notMade.Add(t);
                    }
                if (datePick.SelectedDate != null)
                    foreach (Timetable t in Timetables)
                    {
                        DateTime date = DateTime.ParseExact(t.startDate, "dd.MM.yyyy.", CultureInfo.CurrentCulture);
                        if (!date.Equals(datePick.SelectedDate) && !notMade.Contains(t)) notMade.Add(t);
                    }
                foreach (Timetable t in notMade) Timetables.Remove(t);
            }
            else
            {
                Error error = new Error("Niste uneli nijedan kriterijum za pretraživanje!");
                error.ShowDialog();
            }
        }

        public void ResetSearch(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            Timetables = new ObservableCollection<Timetable>(window.systemEntities.systemTimetables);
            timetablesTable.ItemsSource = Timetables;
            datePick.SelectedDate = null;
            startingStation.SelectedItem = null;
            lastStation.SelectedItem = null;
        }

    }
}
