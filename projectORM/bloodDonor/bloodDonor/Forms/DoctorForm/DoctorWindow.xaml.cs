﻿using BloodDonor.Model;
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dgvPatients;
        }

        private void controlTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (patientTab.IsSelected)
            {
                btnDeleteBloodpack.Visibility = Visibility.Hidden;
                btnDeletePatient.Visibility = Visibility.Visible;
                btnUpdatePatient.Visibility = Visibility.Visible;
                btnRequestBlood.Visibility = Visibility.Visible;
                btnAddPatient.Visibility = Visibility.Visible;
            }
            else
            {
                btnDeleteBloodpack.Visibility = Visibility.Visible;
                btnDeletePatient.Visibility = Visibility.Hidden;
                btnUpdatePatient.Visibility = Visibility.Hidden;
                btnRequestBlood.Visibility = Visibility.Hidden;
                btnAddPatient.Visibility = Visibility.Hidden;
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
                //var data = (from patient in context.Pacients select patient);
                var data = context.Pacients.SqlQuery("select * from Pacients p where p.Id in (select pac.PacientID from DoctorPacients pac where pac.DoctorId = " + doctor.Id + ")").ToList();
                dgPatients.ItemsSource = data.ToList();
            }
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

        private void btnRequestBlood_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddPatient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteBloodpack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
