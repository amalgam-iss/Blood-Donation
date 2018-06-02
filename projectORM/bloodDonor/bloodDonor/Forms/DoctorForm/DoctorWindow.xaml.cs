using BloodDonor.Forms;
using BloodDonor.Model;
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
        Doctor doctor { get; set; }

        public DoctorWindow(string UserId)
        {
            long userId = Convert.ToInt32(UserId);
            doctor = new Doctor();
            using (var db = new Model1())
            {
                doctor = (Doctor)db.Doctors.SqlQuery("SELECT * FROM Doctors d where d.UserId = " + userId + "").SingleOrDefault();
            }
            InitializeComponent();
            doctorNameLabel.Content = doctor.Name + "!";
            specialityLabelM.Content = doctor.Speciality;
            phoneLabelM.Content = doctor.Phone;
            fillPatientsDataGrid();
            fillBloodRequestsDataGrid();

        }

        private void controlTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (patientTab.IsSelected)
            {
                btnDeleteBloodrequest.Visibility = Visibility.Hidden;
                btnDeletePatient.Visibility = Visibility.Visible;
                btnRequestBlood.Visibility = Visibility.Visible;
                btnAddPatient.Visibility = Visibility.Visible;
            }
            else
            {
                btnDeleteBloodrequest.Visibility = Visibility.Visible;
                btnDeletePatient.Visibility = Visibility.Hidden;
                btnRequestBlood.Visibility = Visibility.Hidden;
                btnAddPatient.Visibility = Visibility.Hidden;
            }
        }

        /**
         * PATIENTS DATAGRID OPERATIONS
         * 
         */
        private void fillPatientsDataGrid()
        {
            Debug.WriteLine("Fill Patients.");
            using (var context = new Model1())
            {
                //var data = (from patient in context.Pacients select patient);
                var data = context.Pacients.SqlQuery("select * from Pacients p where p.Id in (select pac.PacientID from DoctorPacients pac where pac.DoctorId = " + doctor.Id + ")").ToList();
                dgPatients.ItemsSource = data.ToList();
            }
        }


        private void dgPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgPatients.SelectedItem != null)
            {
                btnDeletePatient.IsEnabled = true;
                btnRequestBlood.IsEnabled = true;
                Pacient pacient = (Pacient)dgPatients.SelectedItem;
                Debug.WriteLine("Name =" + pacient.Name);
            }
        }

        private void dgPatients_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "DoctorPacients")  {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        /**
         * PATIENT OPERATIONS
         */
        private void btnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            AddPatient addPatientWindow = new AddPatient();
            bool? result = addPatientWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                string patName = addPatientWindow.PatientName;
                string patRh = addPatientWindow.Rh;
                string bloodType = addPatientWindow.BloodType;

                Debug.WriteLine(patName + " " + patRh + " " + bloodType);

                // Now adding to the database
                Pacient patient = new Pacient
                {
                    Name = patName,
                    Rh = patRh,
                    BloodType = bloodType
                };

                using (var db = new Model1())
                {
                    var pat = db.Pacients.Add(patient);
                    var patDoc = new DoctorPacient
                    {
                        PacientId = pat.Id,
                        DoctorId = doctor.Id
                    };
                    db.DoctorPacients.Add(patDoc);
                    db.SaveChanges();
                }
                fillPatientsDataGrid();
            }
        }

        private void btnDeletePatient_Click(object sender, RoutedEventArgs e)
        {
            Pacient pacient = (Pacient)dgPatients.SelectedItem;
            using (var db = new Model1())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM dbo.DoctorPacients where DoctorID =" + doctor.Id + " and PacientID =" + pacient.Id + "");
                db.Database.ExecuteSqlCommand("DELETE FROM dbo.Pacients where Id =" + pacient.Id + "");
                db.SaveChanges();
            }
            fillPatientsDataGrid();
        }

        /**
         * BLOODPACK REQUESTS
         */
        private void btnRequestBlood_Click(object sender, RoutedEventArgs e)
        {
            Pacient pacient = (Pacient)dgPatients.SelectedItem;
            CreateRequest createRequest = new CreateRequest(pacient);
            bool? result = createRequest.ShowDialog();
            if (result.HasValue && result.Value)
            {
                string bloodType = pacient.BloodType;
                string rh = pacient.Rh;
                int quantity = createRequest.Amount;
                int priority = createRequest.Priority;

                using (var context = new Model1())
                {
                    // Now adding to the database
                    BloodRequest bloodRequest = new BloodRequest
                    {
                        DoctorPacient = context.DoctorPacients.SqlQuery("select * from DoctorPacients where DoctorId = " + doctor.Id + ";").SingleOrDefault(),
                        BloodType = bloodType,
                        Rh = rh,
                        Requested_quantity = quantity,
                        Received_quantity = 0,
                        Urgency = priority
                    };

                    var pat = context.BloodRequests.Add(bloodRequest);
                    context.SaveChanges();
                    
                    fillBloodRequestsDataGrid();
                }
            }
        }

        private void fillBloodRequestsDataGrid()
        {
            Debug.WriteLine("Fill Requests.");
            using (var context = new Model1())
            {
                var data = context.DoctorPacients.SqlQuery("select * from DoctorPacients where DoctorId = " + doctor.Id +";").SingleOrDefault();
                Console.WriteLine(data);
                dgRequests.ItemsSource = data.BloodRequests.ToList();
            }
        }

        private void dgRequests_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "DoctorPacient")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void btnDeleteBloodrequest_Click(object sender, RoutedEventArgs e)
        {
            BloodRequest bloodRequest = (BloodRequest)dgRequests.SelectedItem;
            using (var db = new Model1())
            {;
                db.Database.ExecuteSqlCommand("DELETE FROM dbo.BloodRequests where Id =" + bloodRequest.Id + "");
                db.SaveChanges();
            }
            fillBloodRequestsDataGrid();
        }


        /**
         * NO IDEA WHAT THIS IS FOR
         */
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dgvPatients;
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
