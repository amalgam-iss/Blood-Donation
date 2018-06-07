using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonor.Models;

namespace BloodDonor.Controllers
{
    class HistoryController
    {
        UserModel usermodel = new UserModel();

        public int getDonorId(string username)
        {
            int donorId = -1;
            int user_id = usermodel.getUserId(username);
            if (user_id != -1)
            {
                donorId = usermodel.getDonorId(user_id);
            }
            return donorId;
        }

        public List<String> getHistory(int donorId)
        {
            List<String> history = new List<String>();
            history = usermodel.getHistory(donorId);
            return history;
        }
    }
}
