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
using System.Windows.Shapes;

namespace Project.Modals
{
    /// <summary>
    /// Interaction logic for Error.xaml
    /// </summary>
    public partial class Error : Window
    {
        private readonly double screenWidth = SystemParameters.PrimaryScreenWidth;
        private readonly double screenHeight = SystemParameters.PrimaryScreenHeight;
        public Error(string message)
        {
            InitializeComponent();
            Left = screenWidth / 2 - Width / 2;
            Top = screenHeight / 2 - Height / 2;

            Message.Text = message;
        }

        private void ErrorClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
