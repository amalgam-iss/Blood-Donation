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
    /// Interaction logic for RemoveBloodPack.xaml
    /// </summary>
    public partial class RemoveBloodPack : Window
    {
        public string bloodPackIdTxt;
        public RemoveBloodPack(Object dataGridCell)
        {
            InitializeComponent();
            bloodPackIdTxt = "";
            if (dataGridCell == null)
            {
                
            }
        }


        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            bloodPackIdTxt = tbxRemoveBloodPack.Text;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void tbxRemoveBloodPack_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbxRemoveBloodPack.Clear();
        }
    }
}
