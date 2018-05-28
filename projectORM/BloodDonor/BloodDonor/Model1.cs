namespace BloodDonor
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BloodPack> BloodPacks { get; set; }
        public virtual DbSet<BloodRequest> BloodRequests { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<DoctorPacient> DoctorPacients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<DonorDisease> DonorDiseases { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<Nurse> Nurses { get; set; }
        public virtual DbSet<Pacient> Pacients { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodPack>()
                .Property(e => e.Group)
                .IsUnicode(false);

            modelBuilder.Entity<BloodPack>()
                .Property(e => e.Rh)
                .IsUnicode(false);

            modelBuilder.Entity<BloodPack>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<BloodRequest>()
                .Property(e => e.BloodType)
                .IsUnicode(false);

            modelBuilder.Entity<BloodRequest>()
                .Property(e => e.Rh)
                .IsUnicode(false);

            modelBuilder.Entity<Disease>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Speciality)
                .IsUnicode(false);

            modelBuilder.Entity<Donation>()
                .Property(e => e.BloodType)
                .IsUnicode(false);

            modelBuilder.Entity<Donation>()
                .Property(e => e.Rh)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.BloodType)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.Rh)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Nurse>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Pacient>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Pacient>()
                .Property(e => e.BloodType)
                .IsUnicode(false);

            modelBuilder.Entity<Pacient>()
                .Property(e => e.Rh)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DoctorPacients)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.DoctorId);
        }
    }
}
