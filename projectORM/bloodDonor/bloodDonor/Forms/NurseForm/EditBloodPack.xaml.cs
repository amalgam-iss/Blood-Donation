using BloodDonor.Forms.ErrorForm;
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

namespace BloodDonor
{
    /// <summary>
    /// Interaction logic for EditBloodPack.xaml
    /// </summary>
    ///         
 

    public partial class EditBloodPack : Window
    {

        // The parameters for a blood pack.
        public String statusTxt;

        public EditBloodPack()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            ErrorWindow errorWindow = new ErrorWindow();

            if (cboxStatus.Text == "null")
            {
                errorWindow.SetContent("You have to select a staus!");
                errorWindow.ShowDialog();
                return;
            }

            statusTxt = cboxStatus.Text;
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
