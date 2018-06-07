using BloodDonor.Forms.ErrorForm;
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

namespace BloodDonor.Forms
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        public string PatientName { get; set; }
        public string Rh { get; set; }
        public string BloodType { get; set; }
        private ErrorWindow errorWindow;

        public AddPatient()
        {
            InitializeComponent();
            errorWindow = new ErrorWindow();
            tboxName.Text = "";
        }

        private void cboxRh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine(cboxRh.Text);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            errorWindow = new ErrorWindow();

            if (tboxName.Text == "")
            {
                errorWindow.SetContent("Name must not be empty!");
                errorWindow.ShowDialog();
                return;
            }

            if (cboxRh.Text == "null")
            {
                errorWindow.SetContent("You have to select Rh!");
                errorWindow.ShowDialog();
                return;
            }

            if (cboxBloodtype.Text == "null")
            {
                errorWindow.SetContent("You have to select a bloodtype!");
                errorWindow.ShowDialog();
                return;
            }

            using (var db = new Model1())
            {
                var patient = db.Pacients.Where(pat => pat.Name == tboxName.Text).FirstOrDefault();
                if (patient != null)
                {
                    errorWindow.SetContent("Patient name already in database!");
                    errorWindow.ShowDialog();
                    return;
                }
            }

            PatientName = tboxName.Text;
            Rh = cboxRh.Text;
            BloodType = cboxBloodtype.Text;
            Debug.WriteLine(PatientName + " " + Rh + " " + BloodType);
            this.DialogResult = true;
            this.Close();
        }
    }
}
