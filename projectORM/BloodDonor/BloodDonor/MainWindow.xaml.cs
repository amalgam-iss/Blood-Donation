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

using BloodDonor.Controllers;

namespace BloodDonor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainController ctrl;
        public MainWindow()
        {
            InitializeComponent();
            ctrl = new MainController();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (ctrl.login(tbxUsername.Text, tbxPassword.Password.ToString()))
            {
                Console.WriteLine("yas");
            }
            else
            {
                Console.WriteLine("nahah");
            }
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
