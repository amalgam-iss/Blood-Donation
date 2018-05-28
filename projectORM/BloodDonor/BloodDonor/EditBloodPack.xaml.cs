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
        public String groupTxt;
        public String rhTxt;
        public String statusTxt;
        public DateTime currentDate;

        public EditBloodPack(Object selectedCellInfo)
        {
            InitializeComponent();
            //TODO change with object characteristisc
            tbxGroup.Text = ""; //selectedCellInfo.SelectedCell[0].Value.ToString(); for example
            tbxStatus.Text = "";
            tbxRh.Text = "";
            dpCreationDate.SelectedDate = new DateTime(2018, 01, 16);
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            //todo Update on the database
            this.Close();

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;

            this.Close();
        }

        private void dpCreationDate_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            dpCreationDate.Text = "";
        }

        private void tbxStatus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbxStatus.Clear();

        }

        private void tbxRh_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbxRh.Clear();

        }

        private void tbxGroup_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbxGroup.Clear();

        }


    }
}
