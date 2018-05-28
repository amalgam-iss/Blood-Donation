using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public DoctorWindow()
        {
            InitializeComponent();

            fillPatientsDataGrid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dgvPatients;
        }

        private void controlTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (patientTab.IsSelected)
            {
                btnRequestBloodpack.Visibility = Visibility.Hidden;
                btnDeletePatient.Visibility = Visibility.Visible;
                btnUpdatePatient.Visibility = Visibility.Visible;
            }
            else
            {
                btnRequestBloodpack.Visibility = Visibility.Visible;
                btnDeletePatient.Visibility = Visibility.Hidden;
                btnUpdatePatient.Visibility = Visibility.Hidden;
            }
        }

        /**
         * Fill patients grid
         * 
         * */
        private void fillPatientsDataGrid()
        {
            Debug.WriteLine("Fill Patients.");
            using (var context = new Model1())
            {
                var data = (from d in context.Pacients select d);
                //{
                //    Name = d.Name,
                //    BloodType = d.BloodType,
                //    Rh = d.Rh
                //});
                dgPatients.ItemsSource = data.ToList();
            }

            
        }

        private void btnRequestBloodpack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeletePatient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdatePatient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgPatients.SelectedItem != null)
            {
                btnDeletePatient.IsEnabled = true;
                btnUpdatePatient.IsEnabled = true;
                Pacient pacient = (Pacient)dgPatients.SelectedItem;  
            }
        }
    }
}
