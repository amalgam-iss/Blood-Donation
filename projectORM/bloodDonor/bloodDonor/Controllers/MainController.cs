using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BloodDonor.Models;

namespace BloodDonor.Controllers
{
    class MainController
    {
        UserModel userModel = new UserModel();

        public bool login(string user, string password)
        {
            return userModel.CanConnect(user, password);
        }
    }
}
