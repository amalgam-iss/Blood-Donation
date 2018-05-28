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
    /// Interaction logic for AddBloodPack.xaml
    /// </summary>
    public partial class AddBloodPack : Window
    {
        public String groupTxt;
        public String rhTxt;
        public String statusTxt;
        public DateTime currentDate;
        private bool error1 = false;
        private bool error2 = false;
        private bool error3 = false;
        private bool error4 = false;
        public AddBloodPack()
        {
            InitializeComponent();
            error3 = true;

            dpCreationDate.SelectedDate = new DateTime(2018, 01, 16);

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            this.DialogResult = true;
            Debug.WriteLine(dpCreationDate.SelectedDate.Value);
            groupTxt = tbxGroup.Text;
            rhTxt = tbxRh.Text;
            currentDate = dpCreationDate.SelectedDate.Value;
           
            statusTxt = tbxStatus.Text;
            if(!groupTxt.Equals("") && !rhTxt.Equals("") && !statusTxt.Equals("") && !currentDate.Equals(""))
            {
                Debug.WriteLine("sending a bloodpack");
                this.Close();
            }
            }
            catch (Exception ex)
            {
                error1 = true;
                error2 = true;
                error3 = true;
                error4 = true;
                tbxRh.Text = "You must write text in all inputs.";
                tbxGroup.Text = "You must write text in all inputs.";
                dpCreationDate.SelectedDate = new DateTime(2018, 01, 16);
                tbxStatus.Text = "You must write text in all inputs.";
            }
        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;

            this.Close();
        }

        private void tbxGroup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(error1)
                tbxGroup.Clear();
            error1 = false;
        }

        private void tbxRh_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (error2)
                tbxRh.Clear();
            error2 = false;

        }

        private void tbxStatus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (error4)
                tbxStatus.Clear();
            error4 = false;

        }

        private void dpCreationDate_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (error3)
                dpCreationDate.Text = "";
            error3 = false;

        }
    }
}
