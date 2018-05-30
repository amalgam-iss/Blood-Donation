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

        public int can_sign_up(string username, string password, string confirmed_password, string email)
        {
            int did_sign_up;

            if (this.username_exists(username))
            {
                did_sign_up = 0;
            }
            else
            {
                conn.Open();
                SqlCommand insert_command = new SqlCommand("INSERT INTO Users (username, password, email, type) VALUES (@username, @password, @email, @type)", conn);
                insert_command.Parameters.Add(new SqlParameter("username", username));
                insert_command.Parameters.Add(new SqlParameter("password", password));
                insert_command.Parameters.Add(new SqlParameter("email", email));
                insert_command.Parameters.Add(new SqlParameter("type", 1));

                insert_command.CommandType = CommandType.Text;
                try
                {
                    insert_command.ExecuteNonQuery();
                    did_sign_up = 1;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                    did_sign_up = -1;
                }
                finally
                {
                    conn.Close();
                }

            }
            return did_sign_up;
        }


        private bool username_exists(string username)
        {
            bool user_exists;
            SqlCommand command = new SqlCommand("SELECT Type FROM Users WHERE username = @username", conn);
            command.Parameters.Add(new SqlParameter("username", username));

            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                string type = reader["Type"].ToString();
                user_exists = true;
            }
            else
            {
                user_exists = false;
            }

            conn.Close();
            return user_exists;
        }
    }
}
