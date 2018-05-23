namespace BloodDonor
{
    using BloodDonor;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            DoctorPacients = new HashSet<DoctorPacient>();
            Donors = new HashSet<Donor>();
            ProcessingDonations = new HashSet<ProcessingDonation>();
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
        public virtual ICollection<ProcessingDonation> ProcessingDonations { get; set; }

        public static ICollection<User> getAll()
        {
            using (var db = new ModelORM())
            {

                // Create and save a new Blog 
                // Display all Blogs from the database 
                Console.WriteLine("All users in the database:");
                foreach (var item in db.Users)
                {
                    Console.WriteLine(item.Username);
                    Console.WriteLine(item.Email);
                }

                Console.WriteLine("Press any key to exit...");

            }
            return null;
            
        }
    }
}
