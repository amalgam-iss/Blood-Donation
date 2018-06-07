using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using BloodDonor.Utils;
using System.Configuration;

namespace BloodDonor.Models
{
    public class UserModel
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["dataSource"]);

        public long Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int? Type { get; set; }

        public int CanConnect(string user, string password)
        {
            Hashing hashing = new Hashing(password);

            int userType;
            SqlCommand command = new SqlCommand("SELECT Type FROM Users WHERE username = @username AND password = @password", conn);
            command.Parameters.Add(new SqlParameter("username", user));
            command.Parameters.Add(new SqlParameter("password", hashing.getMd5Hash()));

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

        public int can_sign_up(string username, string password, string email)
        {
            Hashing hashing = new Hashing(password);

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
                insert_command.Parameters.Add(new SqlParameter("password", hashing.getMd5Hash()));
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

        public int getUserId(string username)
        {
            int userId = -1;
            SqlCommand command = new SqlCommand("SELECT Id FROM Users WHERE username = @username", conn);
            command.Parameters.Add(new SqlParameter("username", username));

            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                userId = Convert.ToInt32(reader["Id"]);
            }
            conn.Close();
            return userId;
        }

        public int getDonorId(int userId)
        {
            int donorId = -1;
            SqlCommand command = new SqlCommand("SELECT Id FROM Donors WHERE UserId = @userId", conn);
            command.Parameters.Add(new SqlParameter("userId", userId));

            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                donorId = Convert.ToInt32(reader["Id"]);
            }
            conn.Close();
            return donorId;
        }


        public List<string> getHistory(int donorId)
        {
            List<String> history = new List<String>();


            SqlCommand command = new SqlCommand("SELECT Flags, Status, C_Date FROM Donations WHERE DonorId = @donorId", conn);
            command.Parameters.Add(new SqlParameter("donorId", donorId));

            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int flag = reader.GetInt32(0);
                    string status = reader.GetString(1);
                    string date = reader.GetDateTime(2).ToString("dd/MM/yyyy");
                    string entry = "" + flag.ToString() + "|" + status + "|" + date;
                    history.Add(entry);
                }
            }
            conn.Close();
            return history;

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
