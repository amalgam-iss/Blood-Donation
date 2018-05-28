namespace BloodDonor
{
    using BloodDonor;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Diagnostics;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            DoctorPacients = new HashSet<DoctorPacient>();
            Donors = new HashSet<Donor>();
        }
        
        public long Id { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Username { get; set; }

        [StringLength(32)]
        public string Password { get; set; }

        public int? Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorPacient> DoctorPacients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donor> Donors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
   
        public static List<User> getAll()
        {
            List<User> userList = new List<User>();

            using (var db = new Model1())
            {

                // Create and save a new Blog 
                // Display all Blogs from the database 
                Debug.WriteLine("All users in the database:");
                foreach (var item in db.Users)
                {
                    Debug.WriteLine(item.Username);
                    Debug.WriteLine(item.Id);
                    userList.Add(item);
                }

                Debug.WriteLine("Press any key to exit...");
            }

            return userList;
        }

        public static void add(long userID, string email, string userName, string password, int type)
        {
            User user = new User
            {
                Id = userID,
                Email = email,
                Username = userName,
                Password = password,
                Type = type
            };

            using (var db = new Model1())
            {
                db.Users.Add(user);
                db.SaveChanges();
                // should need error checking
            }
        }

        public static void remove(User usr)
        {
            using (var db = new Model1())
            {
                db.Database.ExecuteSqlCommand("DELETE from Users where id = 2");
                db.SaveChanges();
            }
        }
    }
}
