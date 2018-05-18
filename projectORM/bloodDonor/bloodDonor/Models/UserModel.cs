using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace BloodDonor.Models
{
    public class UserModel
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-OJG59VC; " +
                " Initial Catalog = AmalgamIss; Integrated Security = true;");

        public long Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int? Type { get; set; }

        public bool CanConnect(string user, string password)
        {
            bool userCanConnect = false;
            SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE username = @username AND password = @password", conn);
            command.Parameters.Add(new SqlParameter("username", user));
            command.Parameters.Add(new SqlParameter("password", password));

            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                userCanConnect = true;
            }
            else
            {
                userCanConnect = false;
            }

            conn.Close();
            return userCanConnect;
        }
    }
}
