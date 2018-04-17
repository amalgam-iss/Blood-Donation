using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bloodDonor
{
    public abstract class User
    {
        protected long id;
        public string username;
        protected string password;
        protected int age;
        protected string phoneNumber;
        protected string email;

        public User(long id, string username, string password, string phoneNumber, string email, int age)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.age = age; 
        }

        public User(string username, string password)
        {
            this.id = -1;
            this.username = username;
            this.password = password;
            this.phoneNumber = "";
            this.email = "";
            this.age = -1;
        }

        public string GetUsername()
        {
            throw new System.NotImplementedException();
        }
        public void SetUsername(string username)
        {
            this.username = username;
        }
        public string GetPassword()
        {
            throw new System.NotImplementedException();
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }

        public int GetAge()
        {
            return age;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        public long GetId()
        {
            return id;
        }

        public void SetId(long id)
        {
            this.id = id;
        }

        public string GetPhoneNumber()
        {
            throw new System.NotImplementedException();
        }

        public void SetPhoneNumber()
        {
            throw new System.NotImplementedException();
        }

        public override string CheckDisease()
        {
            return base.ToString();
        }
    }
}