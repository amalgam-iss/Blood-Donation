using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bloodDonor
{
    public class Doctor : User, IUser
    {
        public Doctor(string username, string password) : base(username, password)
        {
            
        }

        public Doctor(long id, string username, string password, string phoneNumber, string email, int age) : base(id, username, password, phoneNumber, email, age)
        {
        }

        public void IChangePassword()
        {
            
            throw new NotImplementedException();
        }

        public void ILogin()
        {
            throw new NotImplementedException();
        }

        public void ILogout()
        {
            throw new NotImplementedException();
        }

        public bool CheckDisease(Donor donor)
        {
            throw new NotImplementedException();
        }

        public bloodDonor.BloodComponent RequestBlood()
        {
            throw new System.NotImplementedException();
        }

        public void AddDonor(bloodDonor.Donor donor)
        {
            throw new System.NotImplementedException();
        }

        System.Windows.Documents.List ListDonors()
        {
            throw new System.NotImplementedException();
        }
    }
}