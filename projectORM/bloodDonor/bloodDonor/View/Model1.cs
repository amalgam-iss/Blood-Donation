namespace bloodDonor
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

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<BloodRequest> BloodRequests { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<DoctorPacient> DoctorPacients { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<DonorDisease> DonorDiseases { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<Pacient> Pacients { get; set; }
        public virtual DbSet<ProcessingDonation> ProcessingDonations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<BloodRequest>()
                .Property(e => e.BloodType)
                .IsUnicode(false);

            modelBuilder.Entity<BloodRequest>()
                .Property(e => e.Rh)
                .IsUnicode(false);

            modelBuilder.Entity<BloodRequest>()
                .HasMany(e => e.ProcessingDonations)
                .WithOptional(e => e.BloodRequest)
                .HasForeignKey(e => e.RequestId);

            modelBuilder.Entity<Disease>()
                .Property(e => e.Name)
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

            modelBuilder.Entity<User>()
                .HasMany(e => e.ProcessingDonations)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.PersonelId);
        }
    }
}
