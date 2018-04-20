using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bloodDonor
{
    public class Donor : User, IUser
    {
        private string bloodType { get; set; }

        private List<Disease> diseases;
        private string address;
        private int AcceptedByCriteria;

        public Donor(string username, string password) : base(username, password)
        {
            diseases = new List<Disease>();
        }

        public void AddDisease(string disease)
        {

        }

        public Disease GetDisease(int id)
        {
            return diseases.ElementAt(id);
        }

        public void ILogin()
        {
            throw new NotImplementedException();
        }

        public void ILogout()
        {
            throw new NotImplementedException();
        }

        public void IChangePassword()
        {
            throw new NotImplementedException();
        }

        public string GetAddress()
        {
            return address;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }
    }
}