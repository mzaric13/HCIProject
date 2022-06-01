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
using System.Windows.Forms;

namespace Project
{
    /// <summary>
    /// Interaction logic for HomeHelp.xaml
    /// </summary>
    public partial class HomeHelp : Window
    {
        private string helpName;
        public HomeHelp(string helpName)
        {
            this.helpName = helpName;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Help", helpName);
            browser.Navigate(path);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            if (browser.CanGoBack)
            {
                browser.GoBack();
            }
        }

        private void Forward(object sender, RoutedEventArgs e)
        {
            if (browser.CanGoForward)
            {
                browser.GoForward();
            }
        }
    }
}
