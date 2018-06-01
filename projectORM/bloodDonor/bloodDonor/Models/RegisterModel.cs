using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BloodDonor.Utils;
using System.Diagnostics;

namespace BloodDonor.Models
{
    class RegisterModel
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-3DU7K2P\SQLEXPRESS; " +
                " Initial Catalog = AmalgamIss; Integrated Security = true;");
        private long Id = 0;

        public void Register(string dob, string country, string city, string address, string blood_type,string username,string weight)
        {
            string adr = country + "|" + city + "|" + address;
            Debug.WriteLine(this.Id);
            if (this.GetDonorData(this.Id) == "")
            {
                // if it's a new user, the program adds him/her regardless of his/her diseases.
                // if the donor has at least one of the spcified diseases, the program will not validate that donation.
                conn.Open();
                Random rnd = new Random();
                int nr = rnd.Next(2);
                SqlCommand cmd = new SqlCommand("insert into Donors(UserId,Name,PhoneNumber,BloodType,Rh,Address,Weight,BirthDate) Values(@Id,@Name,@PhoneNumber,@BloodType,@Rh,@Address,@Weight,@BirthDate)", conn);
                cmd.Parameters.AddWithValue("@Id", this.Id);
                cmd.Parameters.AddWithValue("@Name", username);
                cmd.Parameters.AddWithValue("@PhoneNumber", 0770665443);
                cmd.Parameters.AddWithValue("@BloodType", blood_type);
                cmd.Parameters.AddWithValue("@Rh", nr);
                cmd.Parameters.AddWithValue("@Address", adr);
                cmd.Parameters.AddWithValue("@Weight", weight);
                cmd.Parameters.AddWithValue("@BirthDate", dob);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
                this.UpdateData(dob,adr,weight,blood_type);
        }

        public bool CheckPatient(string patientName)
        {
            //function to check if the patient that a donor is donating 
            //for exists and it's not just an imaginary person
            if (patientName == "")
                return true;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Pacients where Name=@Name",conn);
            cmd.Parameters.AddWithValue("@Name",patientName);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        private void UpdateData(string dob, string adr, string weight, string blood_type)
        {
            //function to update the donor personal informations like Address, Weight, etc... 
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Donors set Address=@Address, Weight=@Weight, BirthDate=@BirthDate where UserId=@UserId", conn);
            //cmd.Parameters.AddWithValue("@BloodType", blood_type);
            cmd.Parameters.AddWithValue("@Address", adr);
            cmd.Parameters.AddWithValue("@Weight",weight);
            cmd.Parameters.AddWithValue("@BirthDate",dob);
            cmd.Parameters.AddWithValue("@UserId",this.Id);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public long GetUserId(string username)
        {
            // function to find the id of the user which helps at accessing the donor information
            // the seach is done by checking the username
            long id;
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT Id FROM Users WHERE Username=@Username", conn);
            command.Parameters.AddWithValue("@Username", username);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                string Id = reader["Id"].ToString();
                id = Convert.ToInt64(Id);
                conn.Close();
                this.Id = id;
                return id;
            }
            conn.Close();
            return 0;
        }

        public string GetDonorData(long id)
        {
            // function that retrieves data about a donor from the DB
            // if the donor does not exist,than is returns an empty string
            // otherwise it returns a string with some personal informations
            string rez = "";
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select BloodType,Address,Weight,BirthDate from Donors where UserId=@UserId", conn);
            cmd.Parameters.AddWithValue("@UserId",id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                rez += reader["BloodType"].ToString() + "<";
                rez += reader["Address"].ToString() + "<";
                rez += reader["Weight"].ToString() + "<";
                rez += reader["BirthDate"].ToString();
                conn.Close();
                return rez;
            }
            conn.Close();
            return "";
        }

        public void Add(string donblood)
        {
            // function that adds a new Donation or BloodPack, depending of the value of the parameter, in the Db
            // checks if the donor exists, if yes than retrieves the necessary data fro donation or BlooPack
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Id,BloodType, Rh from Donors where UserId=@UserId",conn);
            cmd.Parameters.AddWithValue("@UserId", this.Id);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            long donorId = Convert.ToInt64(reader["Id"].ToString());
            string blood_type = reader["BloodType"].ToString();
            string Rh = reader["Rh"].ToString();
            int year = Convert.ToInt32(DateTime.Today.Year.ToString());
            int day = Convert.ToInt32(DateTime.Today.Day.ToString());
            int month = Convert.ToInt32(DateTime.Today.Month.ToString());
            string date = year + "-" + month + "-" + day;

            conn.Close();
            if (donblood.Equals("donation"))
            {
                this.AddDonation(donorId,blood_type,Rh,date);
            } 
            if (donblood.Equals("bloodpack"))
            {
                // adds a much BloodPacks as the Quantity donated by the donor 
                int quantity = 0;
                while (quantity != 2)
                {
                    quantity++;
                    this.AddBoolPack(blood_type, Rh, date);
                }
            }
        }

        private void AddBoolPack(string blood_type, string rh, string date)
        {
            // Adds a new BloodPack in the DB, that will be used by the nurses and later by the doctor
            // A BloodPack contains: the group of the donor, the Rh, The date when the donation was made 
            // and a status: the value is IN_PROCESS
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into BloodPacks([Group],Rh,Creation_date,Status) values(@Blood_type,@Rh,@Date,@Status)",conn);
            cmd.Parameters.AddWithValue("@Blood_type",blood_type);
            cmd.Parameters.AddWithValue("@Rh",rh);
            cmd.Parameters.AddWithValue("@Date",date);
            cmd.Parameters.AddWithValue("Status", "IN_PROCESS");
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void AddDonation(long donorId,string blood_type, string rh, string date)
        {
            // Adds a new Donation in the DB, this one will be visible only for donor to keep
            // track of his/her successful donations
            // contains data like: the BloodType, Rh, the Quantity donated which is 2 BloodPacks,status(Distributed), 
            // and the date of the donation
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Donations(DonorId,BloodType,Rh,Quantity,Status,C_Date) values(@DonorId,@BloodType,@Rh,@Quantity,@Status,@Date)", conn);
            cmd.Parameters.AddWithValue("@DonorId",donorId);
            cmd.Parameters.AddWithValue("@BloodType",blood_type);
            cmd.Parameters.AddWithValue("@Rh",rh);
            cmd.Parameters.AddWithValue("@Quantity",2);
            cmd.Parameters.AddWithValue("Status","Distributed");
            cmd.Parameters.AddWithValue("@Date", date);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public long GetDisease(string disease)
        {
            // function to get the Id of the disease that the user has
            // checks by the disease name
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Id from Diseases where Name=@Name",conn);
            cmd.Parameters.AddWithValue("@Name",disease);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                long Id = Convert.ToInt64(reader["Id"].ToString());
                conn.Close();
                return Id;
            }
            conn.Close();
            return 0;
        }

        public bool CheckDisease(long id)
        {
            // function to check if the donor has some diseases that are stored in the DB 
            // if yes this will be displayed as checked in the corresponding checkbox of the disease
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from DonorDisease where DonorId=@DonorId and DiseaseId=@DiseaseId",conn);
            cmd.Parameters.AddWithValue("@DonorId",this.Id);
            cmd.Parameters.AddWithValue("@DiseaseId",id);
            SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.HasRows)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public void AddDisease(string disease)
        { 
            // function to add a disease that the donor has in the DB
            long Id = GetDisease(disease);

            if (this.CheckDisease(Id))
                return;
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into DonorDisease(DonorId,DiseaseId) values(@DonorId,@DiseaseId)", conn);
                cmd.Parameters.AddWithValue("@DonorId",this.Id);
                cmd.Parameters.AddWithValue("@DiseaseId",Id);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public string GetDate()
        {
            // function to get the date of the last donation made by the donor 
            // to check if he/she can donate again
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select top 1 C_Date from Donations where DonorId=@DonorId order by Id desc",conn);
            cmd.Parameters.AddWithValue("@DonorId",this.Id);
            SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.HasRows)
            {
                reader.Read();
                string date = reader["C_Date"].ToString();
                conn.Close();
                return date;
            }
            conn.Close();
            return "";
        }

    }
}
