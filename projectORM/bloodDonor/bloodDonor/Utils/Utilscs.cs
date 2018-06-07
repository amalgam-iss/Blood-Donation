using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonor.Utils
{
    public static class Utilscs
    {
        public static Dictionary<int, string> userMainPages = new Dictionary<int, string>()
        {
            {1, "doctor"},
            {2, "donor"},
            {3, "nurse"}
        };
    }
}
