﻿using Project.Modals;
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
            Success success = new Success("Uspešno dodat voz broj " + (maxIndex + 1).ToString() + " prevoznika BrzaPtica.");
            success.ShowDialog();
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
            YesNoModal yesNoModal = new YesNoModal("Da li ste sigurni da želite da obrišete odabrani voz?");
            yesNoModal.ShowDialog();
            if(yesNoModal.response)
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

        private void tableTrains_AutoGeneratedColumns(object sender, EventArgs e)
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

        public void ShowAllTrains(object sender, RoutedEventArgs e)
        {
            fillTrainTable();
        }

        public void SearchTrains(object sender, RoutedEventArgs e)
        {
            if (searchText.Text.Length == 0)
            {
                Error error = new Error("Niste uneli nijedan karakter za pretraživanje!");
                error.ShowDialog();
            }
            else
            {
                MainWindow window = (MainWindow)Window.GetWindow(this);
                List<Train> searchedTrains = new List<Train>();
                foreach (Train train in window.systemEntities.systemTrains)
                {
                    if (train.Number.ToString().Contains(searchText.Text) || train.Operator.ToLower().Contains(searchText.Text.ToLower())){
                        searchedTrains.Add(train);
                    }
                }
                trains = new ObservableCollection<Train>(searchedTrains);
                tableTrains.ItemsSource = trains;
            }
            
        }

    }
}