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

using BloodDonor.Controllers;
namespace BloodDonor
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        MainController ctrl;
        public SignUp()
        {
            InitializeComponent();
            ctrl = new MainController();
        }
        
        private void sign_up(object sender, RoutedEventArgs e)
        {
            int try_sign_up = ctrl.sing_up(tbxUsername.Text, tbxPassword.Password, tbxConfirmPassword.Password, tbxEmail.Text);
            switch (try_sign_up)
            {
                case -3:
                    MessageBox.Show("Passwords did not matched! ");
                    break;
                case -2:
                    MessageBox.Show("Invalid email! ");
                    break;
                case -1:
                    MessageBox.Show("Upsie. We are stupid! ");
                    break;
                case 0:
                    MessageBox.Show("This username already exists! ");
                    break;
                case 1:
                    MessageBox.Show("Huraay!!! ");
                    this.Close();
                    break;
                default:
                    MessageBox.Show("Dunno man.... We fucked up");
                    break;
            }
        }
    }
}
