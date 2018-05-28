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

        public int CanConnect(string user, string password)
        {
            int userType;
            SqlCommand command = new SqlCommand("SELECT Type FROM Users WHERE username = @username AND password = @password", conn);
            command.Parameters.Add(new SqlParameter("username", user));
            command.Parameters.Add(new SqlParameter("password", password));

            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                string type = reader["Type"].ToString();
                userType = Convert.ToInt32(type);
            }
            else
            {
                userType = -1;
            }

            conn.Close();
            return userType;
        }
    }
}
