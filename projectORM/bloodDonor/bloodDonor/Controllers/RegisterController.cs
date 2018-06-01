using BloodDonor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonor.Controllers
{
    class RegisterController
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

        public void DeleteDisease(string disease)
        {
            // function to delete a disease, that the user no longer has it, from the DB
            this.register.DeleteDisease(disease);
        }

        public string GetDate()
        {
            // function to return the date of the last donation
            // and check if it passes 3 months
            return this.register.GetDate();
        }

        public string GetUser(){ return this.username; }
        public void SetUser(string user) { this.username = user; }
    }
}
