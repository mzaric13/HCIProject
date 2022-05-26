using Project.Modals;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ManagerBoardingCards.xaml
    /// </summary>
    public partial class ManagerBoardingCards : UserControl
    {
        private ObservableCollection<BoardingCard> boardingCards = new ObservableCollection<BoardingCard>();
        public ObservableCollection<BoardingCard> BoardingCards
        {
            get { return boardingCards; }
            set { boardingCards = value; }
        }
        public ObservableCollection<Timetable> Timetables = new ObservableCollection<Timetable>();

        public ManagerBoardingCards()
        {
            InitializeComponent();
        }

        public void fillBoardingCardsTable()
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            List<BoardingCard> boughtBoardingCards = new List<BoardingCard>();
            foreach (BoardingCard boardingCard in window.systemEntities.systemBoardingCards)
            {
                if (boardingCard.State == BoardingCardState.BOUGHT)
                {
                    boughtBoardingCards.Add(boardingCard);
                }
            }
            BoardingCards = new ObservableCollection<BoardingCard>(boughtBoardingCards);
            tableBoardingCards.ItemsSource = BoardingCards;
            months.ItemsSource = new ObservableCollection<string>(window.systemEntities.months);
            Timetables = new ObservableCollection<Timetable>(window.systemEntities.systemTimetables);
            timetables.ItemsSource = Timetables;
        }

        public void BoardingCardsLoaded(object sender, RoutedEventArgs e)
        {
            fillBoardingCardsTable();
        }

        public void SearchByMonth(object sender, RoutedEventArgs e)
        {
            if (months.SelectedItem != null)
            {
                List<BoardingCard> boardingCardsInSelectedMonth = new List<BoardingCard>();
                MainWindow window = (MainWindow)Window.GetWindow(this);
                string monthNumber = window.systemEntities.monthNumbers[months.SelectedItem.ToString()];
                foreach (BoardingCard boardingCard in window.systemEntities.systemBoardingCards)
                {
                    if (boardingCard.DateOfPurchase.Substring(3, 2) == monthNumber && boardingCard.State == BoardingCardState.BOUGHT)
                    {
                        boardingCardsInSelectedMonth.Add(boardingCard);
                    }
                }
                BoardingCards = new ObservableCollection<BoardingCard>(boardingCardsInSelectedMonth);
                tableBoardingCards.ItemsSource = BoardingCards;
            }
            else
            {
                Error error = new Error("Nije odabran nijedan mesec kao kriterijum pretraživanja.");
                error.ShowDialog();
            }
        }

        public void SearchByRoute(object sender, RoutedEventArgs e)
        {
            if (timetables.SelectedItem != null)
            {
                List<BoardingCard> boardingCardsForSelectedTimetable = new List<BoardingCard>();
                MainWindow window = (MainWindow)Window.GetWindow(this);
                Timetable selectedTimetable = timetables.SelectedItem as Timetable;
                foreach (BoardingCard boardingCard in window.systemEntities.systemBoardingCards)
                {
                    if (boardingCard.Timetable == selectedTimetable)
                    {
                        boardingCardsForSelectedTimetable.Add(boardingCard);
                    }
                }
                BoardingCards = new ObservableCollection<BoardingCard>(boardingCardsForSelectedTimetable);
                tableBoardingCards.ItemsSource = BoardingCards;
            }
            else
            {
                Error error = new Error("Nije odabrana nijedna vožnja kao kriterijum pretraživanja.");
                error.ShowDialog();
            }
        }

        public void ShowBoardingCards(object sender, RoutedEventArgs e)
        {
            fillBoardingCardsTable();
        }

        private void tableBoardingCards_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "User")
            {
                e.Column.Header = "Putnik";
            }
            if (e.Column.Header.ToString() == "Timetable")
            {
                e.Column.Header = "Vožnja";
            }
            if (e.Column.Header.ToString() == "DateOfPurchase")
            {
                e.Column.Header = "Datum kupovine";
            }
            if (e.Column.Header.ToString() == "State")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
    }
}
