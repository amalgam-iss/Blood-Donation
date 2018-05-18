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
using System.Drawing;

namespace BloodDonor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }

        private void tbxUsername_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tbxUsername.Text = "";
        }

        private void lblNewUser_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
    
}
