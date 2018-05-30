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
using System.Diagnostics;
using BloodDonor.Utils;

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
            Debug.WriteLine(tbxUsername.Text);
            if (tbxUsername.Text.Equals("doctor"))
            {
                Window2 window2 = new Window2();
                window2.Show();
                this.Close();

            }
            else if (tbxUsername.Text.Equals("nurse"))
            {
                NurseWindow nurseWindow = new NurseWindow();
                nurseWindow.Show();
                this.Close();

            }
            else if(tbxUsername.Text.Equals("donor"))
            {
                DonorWindow donorWindow = new DonorWindow();
                donorWindow.Show();
                this.Close();

            }
        }

        private void tbxUsername_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tbxUsername.Text = "";
        }

        private void lblNewUser_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SignUp window = new SignUp();
            window.Show();
        }
    }
    
}
