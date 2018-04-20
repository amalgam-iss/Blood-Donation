using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bloodDonor
{
    public class Nurse : User, IUser
    {
        public Nurse(string username, string password) : base(username, password)
        {
        }

        public Nurse(long id, string username, string password, string phoneNumber, string email, int age) : base(id, username, password, phoneNumber, email, age)
        {
        }

        public BloodComponent BeingTested
        {
            get => default(BloodComponent);
            set
            {
            }
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

        public override string CheckDisease()
        {
            return base.CheckDisease();
        }

        public void PurchaseBlood()
        {
            throw new System.NotImplementedException();
        }

        public void TestBlood()
        {
            throw new System.NotImplementedException();
        }
    }
}