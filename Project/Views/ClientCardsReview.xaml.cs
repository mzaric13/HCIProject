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
    /// Interaction logic for ClientCardsReview.xaml
    /// </summary>
    public partial class ClientCardsReview : UserControl
    {

        ObservableCollection<BoardingCard> BoughtCards = new ObservableCollection<BoardingCard>();

        ObservableCollection<BoardingCard> ReservedCards = new ObservableCollection<BoardingCard>();

        public ClientCardsReview()
        {
            InitializeComponent();
        }

        private void fillBoughtCards()
        {
            BoughtCards.Clear();
            MainWindow window = (MainWindow)Window.GetWindow(this);
            if (window.systemEntities.systemBoardingCards == null) return;
            foreach (BoardingCard boardingCard in window.systemEntities.systemBoardingCards)
            {
                if (boardingCard.User == window.systemEntities.loggedUser && boardingCard.State == BoardingCardState.BOUGHT)
                {
                    BoughtCards.Add(boardingCard);
                }
            }
            boughtCards.ItemsSource = BoughtCards;
        }

        public void BoughtCardsLoad(object sender, RoutedEventArgs e)
        {
            fillBoughtCards();
        }

        public void boughtCards_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "StartStation")
            {
                e.Column.Header = "Početna stanica";
            }
            if (e.Column.Header.ToString() == "EndStation")
            {
                e.Column.Header = "Krajnja stanica";
            }
            if (e.Column.Header.ToString() == "DateOfPurchase")
            {
                e.Column.Header = "Datum kupovine";
            }
            if (e.Column.Header.ToString() == "Price")
            {
                e.Column.Header = "Cena";
            }
            if (e.Column.Header.ToString() == "State")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            if (e.Column.Header.ToString() == "Timetable")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            if (e.Column.Header.ToString() == "User")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void fillReservedCards()
        {
            ReservedCards.Clear();
            MainWindow window = (MainWindow)Window.GetWindow(this);
            List<BoardingCard> cardsForDelete = new List<BoardingCard>();
            if (window.systemEntities.systemBoardingCards == null) return;
            foreach (BoardingCard boardingCard in window.systemEntities.systemBoardingCards)
            {
                if (boardingCard.User == window.systemEntities.loggedUser && boardingCard.State == BoardingCardState.RESERVED)
                {
                    Timetable timetable = boardingCard.Timetable.First();
                    DateTime startTime = DateTime.ParseExact(timetable.startDate, "dd.MM.yyyy.", CultureInfo.CurrentCulture);
                    double days = (startTime - DateTime.Now).TotalDays;
                    if (days < 1)
                    {
                        cardsForDelete.Add(boardingCard);
                    }else ReservedCards.Add(boardingCard);
                }
            }
            deleteCards(cardsForDelete);
            reservedCards.ItemsSource = ReservedCards;
        }

        private void deleteCards(List<BoardingCard> cardsForDelete)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            foreach (BoardingCard card in cardsForDelete)
            {
                window.systemEntities.systemBoardingCards.Remove(card);
            }
        }

        public void ReservedCardsLoad(object sender, RoutedEventArgs e)
        {
            fillReservedCards();
        }

        public void reservedCards_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "StartStation")
            {
                e.Column.Header = "Početna stanica";
            }
            if (e.Column.Header.ToString() == "EndStation")
            {
                e.Column.Header = "Krajnja stanica";
            }
            if (e.Column.Header.ToString() == "DateOfPurchase")
            {
                e.Column.Header = "Datum rezervacije";
            }
            if (e.Column.Header.ToString() == "Price")
            {
                e.Column.Header = "Cena";
            }
            if (e.Column.Header.ToString() == "State")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            if (e.Column.Header.ToString() == "Timetable")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            if (e.Column.Header.ToString() == "User")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        public void reservedCards_AutoGeneratedColumns(object sender, EventArgs e)
        {
            var grid = (DataGrid)sender;
            foreach (var item in grid.Columns)
            {
                if (item.Header.ToString() == "Otkaži kartu")
                {
                    item.DisplayIndex = grid.Columns.Count - 1;
                }
                if (item.Header.ToString() == "Kupi kartu")
                {
                    item.DisplayIndex = grid.Columns.Count - 1;
                }
            }
        }

        public void CancelCard(object sender, RoutedEventArgs e)
        {
            BoardingCard boardingCard = ((FrameworkElement)sender).DataContext as BoardingCard;
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.systemEntities.systemBoardingCards.Remove(boardingCard);
            fillReservedCards();
            Success success = new Success("Uspešno ste otkazali rezervaciju!");
            success.ShowDialog();
        }

        public void BuyCard(object sender, RoutedEventArgs e)
        {
            BoardingCard boardingCard = ((FrameworkElement)sender).DataContext as BoardingCard;
            boardingCard.State = BoardingCardState.BOUGHT;
            fillBoughtCards();
            fillReservedCards();
            Success success = new Success("Uspešno ste kupili rezervisanu kartu!");
            success.ShowDialog();
        }

        public void ShowCards(object sender, RoutedEventArgs e)
        {
            if (cardType.SelectedItem != null)
            {
                if (((ComboBoxItem)cardType.SelectedItem).Content.ToString() == "Kupljene")
                {
                    fillBoughtCards();
                    reservedCards.Visibility = Visibility.Hidden;
                    boughtCards.Visibility = Visibility.Visible;
                }
                else
                {
                    fillReservedCards();
                    boughtCards.Visibility = Visibility.Hidden;
                    reservedCards.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Error error = new Error("Niste odabrali tip karte.");
                error.ShowDialog();
            }
        }
    }
}
