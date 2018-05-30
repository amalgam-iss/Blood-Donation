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
using System.Data.Entity;
using System.Diagnostics;
using BloodDonor.Model;

namespace BloodDonor
{
    /// <summary>
    /// Interaction logic for NurseWindow.xaml
    /// </summary>
    public partial class NurseWindow : Window
    {
        public NurseWindow(String nameOfNurse="Nurse")
        {
            InitializeComponent();
            initiateDgvDonors();
            initiateDgvExpiredBloodPack();
            initiateDgvBloodPack();
            initiateDgvBloodRequest();
            lblTitle.Content = "Hello, " + nameOfNurse + "!";

        }

        private void initiateDgvDonors()
        {
            Debug.WriteLine("I tried to initialise the donors\n");
            using (var context = new Model1())
            {
                var data = (from d in context.Donors select d);
                dgvDonor.ItemsSource = data.ToList();
            }

        }
        private void initiateDgvExpiredBloodPack()
        {
            Debug.WriteLine("I tried to initialise the expired bp\n");
            using (var context = new Model1())
            {
                var data = (from d in context.BloodPacks select d);
                data = (from d in data where d.Status.Equals("EXPIRED") select d);
                dgvExpiredBloodPacks.ItemsSource = data.ToList();
            }

        }
        private void initiateDgvBloodPack()
        {
            Debug.WriteLine("I tried to initialise the bp\n");
            using (var context = new Model1())
            {
                var data = (from d in context.BloodPacks select d);
                dgvBloodPack.ItemsSource = data.ToList();
            }
        }
        private void initiateDgvBloodRequest()
        {
            Debug.WriteLine("I tried to initialise the blood request\n");
            using (var context = new Model1())
            {
                var data = (from d in context.BloodRequests select d);
                dgvBloodPack.ItemsSource = data.ToList();
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            AddBloodPack win1 = new AddBloodPack();
            bool? result = win1.ShowDialog();

            if (result.HasValue && result.Value)
            {
                 String groupTxtNurse = win1.groupTxt;
                 String rhTxtNurse = win1.rhTxt;
                 String statusTxtNurse = win1.statusTxt;
                 DateTime currentDateNurse = win1.currentDate;
                //TODO Create the object
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Object myItem = dgvBloodPack.SelectedItem;
            //Object cellId = dgvBloodPack.SelectedCells[0];
            RemoveBloodPack win1 = new RemoveBloodPack(myItem); // or cellId
            bool? result = win1.ShowDialog();

            if (result.HasValue && result.Value)
            {
                String cellRemovedId = win1.bloodPackIdTxt;
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //TODO update dgv

            using (var context = new Model1())
            {
                context.SaveChanges();
            }

        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            Object myItem = dgvBloodPack.SelectedItem;
            // Object cellId = dgvBloodPack.SelectedCells[0];
            EditBloodPack win1 = new EditBloodPack(myItem); // or cellId
            bool? result = win1.ShowDialog();

            if (result.HasValue && result.Value)
            {
                String groupTxtNurse = win1.groupTxt;
                String rhTxtNurse = win1.rhTxt;
                String statusTxtNurse = win1.statusTxt;
                DateTime currentDateNurse = win1.currentDate;
                //TODO Update the object
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource donorViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("donorViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // dgvDonor.ItemsSource = [generic data source]
            System.Windows.Data.CollectionViewSource bloodPackViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bloodPackViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // bloodPackViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource bloodRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bloodRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // bloodRequestViewSource.Source = [generic data source]
        }
    }
}
