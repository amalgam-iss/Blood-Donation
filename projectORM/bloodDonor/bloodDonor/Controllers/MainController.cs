using BloodDonor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BloodDonor.Controllers
{
    class MainController
    {
        UserModel userModel = new UserModel();

        public int login(string user, string password)
        {
            return userModel.CanConnect(user, password);
        }

        public int sign_up(string username, string password, string confirmed_password, string email)
        {
            if (password != confirmed_password)
            {
                return -2;
            }

            if (email.IndexOf("@") == -1 || email.IndexOf(".") == -1 || email.Length < 7)
            {
                return -3;
            }
            return userModel.can_sign_up(username, password, email);
        }
    }
}
