using BloodDonor.Controllers;
using BloodDonor.Forms.ErrorForm;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DonorWindow : Window
    {
        RegisterController register = new RegisterController();

        public DonorWindow(string username)
        {
            InitializeComponent();
            register.SetUser(username);
            this.Initialize();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSend_Data(object sender, RoutedEventArgs e)
        {
            if (this.CheckTextBoxes() == false)
                return;

            register.Register(dob.Text, country.Text, city.Text, address.Text, blood_type.Text, weight.Text);
            string result = this.Check();

            if (result.Length != 31)
            {
                MessageBox.Show(result);
                return;
            }

            if (this.CheckPeriod() == false)
                return;

            Debug.WriteLine(result.Length);
            if (result.Length == 31)
            {
                // check if the donor wants to donate for a certain patient
                if (Donate.IsChecked == false)
                {
                    this.register.AddDonationBloodPack("donation", "");
                    this.register.AddDonationBloodPack("bloodpack", "");
                    MessageBox.Show("All good");
                    return;
                }
                else
                {
                    bool rez = this.register.AddDonationBloodPack("donation", nameOfThePerson.Text);
                    if (rez)
                    {
                        this.register.AddDonationBloodPack("bloodpack", "");
                        MessageBox.Show("All good");
                        return;
                    }
                    else
                    {
                        ErrorWindow error = new ErrorWindow();
                        error.SetContent("The patient does not exist.");
                        error.Show();
                        //MessageBox.Show("The patient does not exist.");
                        return;
                    }
                }
            }

        }

        private void Initialize()
        {
            // Function to initialize the fields and the checkboxes with the corresponding diseases that the user has

            string rez = register.Init();
            if (rez != "")
            {
                string[] rez1 = rez.Split('<');
                string[] adr = rez1[1].Split('|');
                blood_type.Text = rez1[0];
                weight.Text = rez1[2];
                dob.Text = rez1[3];
                country.Text = adr[0];
                city.Text = adr[1];
                address.Text = adr[2];
            }
            Hepatitis.IsChecked = this.register.CheckDisease("Hepatitis");
            Pox.IsChecked = this.register.CheckDisease("Pox");
            TB.IsChecked = this.register.CheckDisease("TB");
            Malaria.IsChecked = this.register.CheckDisease("Malaria");
            Neurological.IsChecked = this.register.CheckDisease("Neurological");
            Brucellosis.IsChecked = this.register.CheckDisease("Brucellosis");
            Ulcer.IsChecked = this.register.CheckDisease("Ulcer");
            Diabetes.IsChecked = this.register.CheckDisease("Diabetes");
            HeartD.IsChecked = this.register.CheckDisease("Heart");
            SkinD.IsChecked = this.register.CheckDisease("Skin");
            Cancer.IsChecked = this.register.CheckDisease("Cancer");
            Myopia.IsChecked = this.register.CheckDisease("Myopia");
        }

        private string Check()
        {
            // function to check if the donor has some diseases. If yes than it cannot donate
            // all of her/his diseases will be stored in the database, also all the personal info 
            // regarding the donor will be stored in the DB.

            string result = "Cannot donate because of the: \n";
            if (Hepatitis.IsChecked == true)
            {
                this.register.AddDisease("Hepatitis");
                result += "\t - hepatitis. \n";
            }
            else
            {
                Hepatitis.IsChecked = this.register.CheckDisease("Hepatitis");
                if (Hepatitis.IsChecked == true)
                    result += "\t - hepatitis. \n";
            }
            if (Pox.IsChecked == true)
            {
                this.register.AddDisease("Pox");
                result += "\t - pox. \n";
            }
            else
            {
                Pox.IsChecked = this.register.CheckDisease("Pox");
                if (Pox.IsChecked == true)
                    result += "\t - pox. \n";
            }
            if (TB.IsChecked == true)
            {
                this.register.AddDisease("TB");
                result += "\t - TB. \n";
            }
            else
            {
                TB.IsChecked = this.register.CheckDisease("TB");
                if (TB.IsChecked == true)
                    result += "\t - TB. \n";
            }
            if (Malaria.IsChecked == true)
            {
                this.register.AddDisease("Malaria");
                result += "\t - malaria. \n";
            }
            else
            {
                Malaria.IsChecked = this.register.CheckDisease("Malaria");
                if (Malaria.IsChecked == true)
                    result += "\t - malaria. \n";
            }
            if (Neurological.IsChecked == true)
            {
                this.register.AddDisease("Neurological");
                result += "\t - neurological diseases. \n";
            }
            else
            {
                Neurological.IsChecked = this.register.CheckDisease("Neurological");
                if (Neurological.IsChecked == true)
                    result += "\t - neurological diseases. \n";
            }
            if (Brucellosis.IsChecked == true)
            {
                this.register.AddDisease("Brucellosis");
                result += "\t - brucellosis. \n";
            }
            else
            {
                Brucellosis.IsChecked = this.register.CheckDisease("Brucellosis");
                if (Brucellosis.IsChecked == true)
                    result += "\t - brucellosis. \n";
            }
            if (Ulcer.IsChecked == true)
            {
                this.register.AddDisease("Ulcer");
                result += "\t - ulcer. \n";
            }
            else
            {
                Ulcer.IsChecked = this.register.CheckDisease("Ulcer");
                if (Ulcer.IsChecked == true)
                    result += "\t - ulcer. \n";
            }
            if (Diabetes.IsChecked == true)
            { 
                this.register.AddDisease("Diabetes");
                result += "\t - diabetes. \n";
            }
            else
            {
                Diabetes.IsChecked = this.register.CheckDisease("Diabetes");
                if (Diabetes.IsChecked == true)
                    result += "\t - diabetes. \n";
            }
            if (HeartD.IsChecked == true)
            {
                this.register.AddDisease("Heart");
                result += "\t - heard diseases. \n";
            }
            else
            {
                HeartD.IsChecked = this.register.CheckDisease("Heart");
                if (HeartD.IsChecked == true)
                    result += "\t - heard diseases. \n";
            }
            if (SkinD.IsChecked == true)
            {
                this.register.AddDisease("Skin");
                result += "\t - skin diseases. \n";
            }
            else
            {
                SkinD.IsChecked = this.register.CheckDisease("Skin");
                if (SkinD.IsChecked == true)
                    result += "\t - skin diseases. \n";
            }
            if (Cancer.IsChecked == true)
            {
                this.register.AddDisease("Cancer");
                result += "\t - cancer. \n";
            }
            else
            {
                Cancer.IsChecked = this.register.CheckDisease("Cancer");
                if (Cancer.IsChecked == true)
                    result += "\t - cancer. \n";
            }
            if (Myopia.IsChecked == true)
            {
                this.register.AddDisease("Myopia");
                result += "\t - Myopia. \n";
            }
            else
            {
                Myopia.IsChecked = this.register.CheckDisease("Myopia");
                if (Myopia.IsChecked == true)
                    result += "\t - Myopia. \n";
            }

            if (Surgery.IsChecked == true)
                result += "\t - surgery. \n";
            if (Pregnant.IsChecked == true)
                result += "\t - pregnancy. \n";
            if (PostB.IsChecked == true)
                result += "\t - post birth. \n";
            if (Menstruating.IsChecked == true)
                result += "\t - menstruation. \n";
            if (Alcohol.IsChecked == true)
                result += "\t - alcohol consumtion. \n";
            return result;
        }
        
        private bool CheckTextBoxes()
        {
            // function to check if the user entered correct data into the fields.

            int year = Convert.ToInt32(DateTime.Today.Year.ToString());
            if (country.Text == "" || city.Text == "" || 
                address.Text == "" || blood_type.Text == "" || dob.Text == "dd-ll-aaaa" || weight.Text == "")
            {
                ErrorWindow error = new ErrorWindow();
                error.SetContent("All fields are mandatory");
                error.Show();
                //MessageBox.Show("All fields are mandatory");
                return false;
            }
            try
            {
                string[] dateform = dob.Text.Split('-');
                int day = Convert.ToInt32(dateform[0]);
                int month = Convert.ToInt32(dateform[1]);
                int givenyear = Convert.ToInt32(dateform[2]);
                if (year < givenyear || (year - givenyear < 18 || year - givenyear > 66))
                {
                    ErrorWindow error = new ErrorWindow();
                    error.SetContent("Your age is not good for donations.");
                    error.Show();
                    //MessageBox.Show("Your age is not good for donations.");
                    return false;
                }
                if (day > 31 || day < 1)
                {
                    ErrorWindow error = new ErrorWindow();
                    error.SetContent(day + " is not a valid day.");
                    error.Show();
                    //MessageBox.Show(day + " is not a valid day.");
                    return false;
                }
                if (month > 12 || month < 1)
                {
                    ErrorWindow error = new ErrorWindow();
                    error.SetContent(month + " is not a valid month.");
                    error.Show();
                    //MessageBox.Show(month + " is not a valid month.");
                    return false;
                }
            }
            catch(Exception)
            {
                ErrorWindow error = new ErrorWindow();
                error.SetContent("The date of birth must be integer.");
                error.Show();
                //MessageBox.Show("The date of birth must be integer.");
                return false;
            }
            try
            {
                int weig = Convert.ToInt32(weight.Text);
                if (weig < 50)
                {
                    ErrorWindow error = new ErrorWindow();
                    error.SetContent("Your weight is not good for donations.");
                    error.Show();
                    //MessageBox.Show("Your weight is not good for donations.");
                    return false;
                }
            }
            catch(Exception)
            {
                ErrorWindow error = new ErrorWindow();
                error.SetContent("Make sure that the weigth is an integer.");
                error.Show();
                //MessageBox.Show("Make sure that the weigth is an integer.");
                return false;
            }
            if (!this.register.CheckCountry(country.Text.ToString()))
            {
                ErrorWindow error = new ErrorWindow();
                error.SetContent("Your contry is not a member of EU");
                error.Show();
                //MessageBox.Show("Your contry is not a member of EU");
                return false;
            }
            if (blood_type.Text !="A" && blood_type.Text != "B" && blood_type.Text != "AB" && blood_type.Text !="0")
            {
                ErrorWindow error = new ErrorWindow();
                error.SetContent("Invalid blood type.");
                error.Show();
                //MessageBox.Show("Invalid blood type.");
                return false;
            }
            return true;
        }

        private bool CheckPeriod()
        {
            DateTime date = DateTime.Now.AddMonths(-3);
            int months = Convert.ToInt32(date.Month.ToString());
            string dates = this.register.GetDate();
            Debug.WriteLine(dates + "lemne");
            if (dates != "")
            {
                Debug.WriteLine(dates);
                int lastmoth = Convert.ToInt32(dates.Split('/')[1]);

                if (months - lastmoth < 0)
                {
                    ErrorWindow error = new ErrorWindow();
                    error.SetContent("You can donate again after 3 months.");
                    error.Show();
                    //MessageBox.Show("You can donate again after 3 months.");
                    return false;
                }
                else
                    return true;
            }
            return true;
        }
    }
}
