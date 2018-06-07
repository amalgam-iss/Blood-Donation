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
using System.Configuration;
using System.Diagnostics;
using BloodDonor.Model;
using BloodDonor.Forms.ErrorForm;

namespace BloodDonor
{
    //
    // Interaction logic for NurseWindow.xaml
    //
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

        //
        // DATA GRID VIEWS  
        //
        private void initiateDgvDonors()
        {
            Debug.WriteLine("I tried to initialise the donors\n");
            using (var context = new Model1())
            {
                var data = (from d in context.Donors select d);
                dgvDonor.ItemsSource = data.ToList();
            }

        }

        // Populates the dgv of Expired Bloodpacks
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

        // Populates the dgv of Blood Pack
        private void initiateDgvBloodPack()
        {
            Debug.WriteLine("I tried to initialise the bp\n");
            using (var context = new Model1())
            {
                var data = (from d in context.BloodPacks select d);
                data = (from d in data where d.Status != "TESTED_NOT_OKAY" select d);
                dgvBloodPack.ItemsSource = data.ToList();
            }
        }

        // Populates the dgv Blood Request
        private void initiateDgvBloodRequest()
        {
            Debug.WriteLine("I tried to initialise the blood request\n");
            using (var context = new Model1())
            {
                var data = (from d in context.BloodRequests select d);
                dgvPendingRequest.ItemsSource = data.ToList();
            }
        }
        private void dgvPendingRequest_OnGenerating(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "AddressId")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            if (e.Column.Header.ToString() == "DoctorPacient")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            if (e.Column.Header.ToString() == "Quantity")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        //
        // BUTTONS
        //

        // Increase the quantity of the requested blood for a request
        private void btnUseBloodpack_Click(object sender, RoutedEventArgs e)
        {
            ErrorWindow errorWindow = new ErrorWindow();
            BloodPack bloodPack = (BloodPack)dgvBloodPack.SelectedItem;
            BloodRequest bloodRequest = (BloodRequest)dgvPendingRequest.SelectedItem;

            if (bloodPack == null)
            {
                errorWindow.SetContent("Bloodpack not selected!");
                errorWindow.Show();
                return;
            }
            if (bloodRequest == null)
            {
                errorWindow.SetContent("Blood request not selected!");
                errorWindow.Show();
                return;
            }

            if (bloodPack.Status == "DISTRIBUTED")
            {
                errorWindow.SetContent("Bloodpack already DISTRIBUTED!");
                errorWindow.Show();
                return;
            }

            using (var context = new Model1())
            {
                bloodRequest.Received_quantity += 1;
                bloodPack.Status = "DISTRIBUTED";
                context.Entry(bloodPack).State = EntityState.Modified;
                context.Entry(bloodRequest).State = EntityState.Modified;
                context.SaveChanges();
            }

            initiateDgvBloodPack();
            initiateDgvBloodRequest();
        }

        // Opens a new window to add a blood pack to the database. If the result is ok then the object is created and added to the database. 
        private void btnAddBloodpack_Click(object sender, RoutedEventArgs e)
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

        // Opens a new window which allows you to remove a blood pack.
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

        // Closes the current window.
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// Updates the database with all the changes form the dgv
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //TODO update dgv

            using (var context = new Model1())
            {
                context.SaveChanges();
            }

        }


        // Opens a new window to edit the bloodpack
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

            
        }
    }
}
