using BloodDonor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonor.Controllers
{
    public class RegisterController
    {
        private string username;
        RegisterModel register = new RegisterModel();

        public void Register(string dob, string country, string city, string address, string blood_type,string weight)
        {
            // function to permit the user to register with some personal info or update those informations.
            register.Register(dob, country, city, address, blood_type, username, weight);
        }

        public string Init()
        {
            // function to initialize the fields with the user personal information.
            // returns a string that contains his/her BirthDate,Weight and Address(Country City StreetAddress) 
            return register.GetDonorData(register.GetUserId(username));
        }

        public bool AddDonationBloodPack(string donblood, string patientName)
        {
            // function to add in the DB the last donation performed by/bloodpack obtain from the user 
            // if the donor wants to donate for a certain person, it must be a valid patient otherwise
            // his/her donation will not be valid 
            bool rez = this.register.CheckPatient(patientName);
            if (rez)
            {
                this.register.Add(donblood);
                return true;
            }
            return false;
        }

        public bool CheckDisease(string disease)
        {
            // function to check if the user has a certain disease stored in the DB
            // the program shows all the diseases that a donor has, just as a remainder
            return this.register.CheckDisease(this.register.GetDisease(disease));
        }

        public void AddDisease(string disease)
        {
            // function to add a new disease, that the user is suffering from, in the DB 
            this.register.AddDisease(disease);
        }

        public string GetDate()
        {
            // function to return the date of the last donation
            // and check if it passes 3 months
            return this.register.GetDate();
        }

        public string GetUser(){ return this.username; }
        public void SetUser(string user) { this.username = user; }

        public void CheckWeightTest(string weight)
        {
            int w;
            try
            {
                w = int.Parse(weight);
            }
            catch(Exception)
            {
                throw new ArgumentOutOfRangeException("Weight must be integer.");
            }

            if (w < 0)
                throw new ArgumentOutOfRangeException("Weight not a positive number.");
        }

        public void CheckAgeTest(string age)
        {
            int ag;
            try
            {
                ag = int.Parse(age);
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Age must be integer.");
            }
            if (ag < 18 && ag >65)
                throw new ArgumentOutOfRangeException("Your age is not good.");
        }

        public void CheckBloodTypeTest(string type)
        {
            if (type != "A" || type != "B" || type != "AB" || type != "0")
                throw new ArgumentOutOfRangeException("Invalid blood type.");
        }
        public void CheckDateTest(string date)
        {
            string[] dateformat = date.Split('/');
            int Day, Month, Year;
            try
            {
                Day = int.Parse(dateformat[0]);
                Month = int.Parse(dateformat[1]);
                Year = int.Parse(dateformat[2]);
            }
            catch(Exception)
            {
                throw new ArgumentOutOfRangeException("Invalid date.");
            }
            if (Day < 0 && Day > 31)
                throw new ArgumentOutOfRangeException("Invalid day.");
            if (Month < 0 && Month > 12)
                throw new ArgumentOutOfRangeException("Invalid month.");
            if (Year < 0)
                throw new ArgumentOutOfRangeException("Invalid Year");

        }
    }
}
