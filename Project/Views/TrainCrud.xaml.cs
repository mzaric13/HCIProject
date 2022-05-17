using Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for TrainCrud.xaml
    /// </summary>
    public partial class TrainCrud : UserControl
    {   
        ObservableCollection<Train> trains = new ObservableCollection<Train>();
        public TrainCrud()
        {
            InitializeComponent();
        }
        public void fillTrainTable()
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            trains = new ObservableCollection<Train>(window.systemEntities.systemTrains);
            tableTrains.ItemsSource = trains;
        }

        private void TrainCrudLoaded(object sender, RoutedEventArgs e)
        {
            fillTrainTable();
        }

        public void AddTrain(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            int maxIndex = window.systemEntities.systemTrains.Max(t => t.Number);
            trains.Add(new Train(maxIndex + 1, "BrzaPtica"));
            window.systemEntities.systemTrains.Add(new Train(maxIndex + 1, "BrzaPtica"));
        }

        private void tableTrains_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Operator")
            {
                e.Column.Header = "Prevoznik";
            }
            if (e.Column.Header.ToString() == "Number")
            {
                e.Column.Header = "Broj voza";
            }
        }

        public void DeleteTrain(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            Train train = ((FrameworkElement)sender).DataContext as Train;
            foreach (Train t in window.systemEntities.systemTrains)
            {
                if (t.Number == train.Number && t.Operator == train.Operator)
                {
                    trains.Remove(train);
                    window.systemEntities.systemTrains.Remove(t); 
                    break;
                }
            }
        }
    }
}
