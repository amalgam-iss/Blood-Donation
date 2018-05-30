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
using System.Diagnostics;

namespace BloodDonor
{
    /// <summary>
    /// Interaction logic for CreateRequest.xaml
    /// </summary>
    public partial class CreateRequest : Window
    {
       public CreateRequest(Pacient pacient)
       {
            InitializeComponent();
            this.tbxBloodType.Text = pacient.BloodType;
            this.tbxName.Text = pacient.Name;
            this.tbxRh.Text = pacient.Rh; 
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int amount = int.Parse(this.tbxAmount.Text);
                Console.WriteLine(amount);
                
                this.Close(); 
            }
            catch(Exception a)
            {
                this.tbxAmount.Clear();
                Console.Write(a.StackTrace);
            }
        }
    }
}
