using Project.Modals;
using Project.Model;
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
    /// Interaction logic for StationsPosition.xaml
    /// </summary>
    public partial class StationsPosition : UserControl
    {
        public StationsPosition()
        {
            InitializeComponent();
        }

        public void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Border border = sender as Border;
                Label label = (Label)border.Child;
                DataObject dragData = new DataObject("borderMove", border);
                DragDrop.DoDragDrop(border, dragData, DragDropEffects.Move);
            }
        }

        private void Border_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("borderMove"))
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Border_Drop(object sender, DragEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            if (e.Data.GetDataPresent("borderMove"))
            {
                Border border = e.Data.GetData("borderMove") as Border;
                Point endSpot = e.GetPosition(border);
                Label label = (Label)border.Child;

                string stationName = label.Content.ToString().Split('.')[1];
                double newY = Canvas.GetTop(border) + endSpot.Y;
                double newX = Canvas.GetLeft(border) + endSpot.X;

                foreach (TrainStation trainStation in window.systemEntities.systemTrainStations)
                {
                    if (trainStation.Name.Trim() == stationName.Trim())
                    {
                        trainStation.X = newX;
                        trainStation.Y = newY;
                    }
                }

                Canvas.SetTop(border, Canvas.GetTop(border) + endSpot.Y);
                Canvas.SetLeft(border, Canvas.GetLeft(border) + endSpot.X);
                Success success = new Success("Uspešno izmenjena pozicija stanice" + stationName + ".");
                success.ShowDialog();
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            if (drawSurface.Visibility == Visibility.Visible)
            {
                foreach (var children in drawSurface.Children)
                {
                    Border border = (Border)children;
                    border.Height = drawSurface.ActualHeight / 10;
                    border.Width = stationsGrid.ActualWidth / 7;
                    Label label = border.Child as Label;
                    label.FontSize = drawSurface.ActualHeight / 40;

                    Canvas.SetTop(border, (stationsGrid.ActualHeight * Canvas.GetTop(border)) / e.PreviousSize.Height);
                    Canvas.SetLeft(border, (stationsGrid.ActualWidth * Canvas.GetLeft(border)) / e.PreviousSize.Width);
                }
            }
        }
    }
}
