namespace bloodDonor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Donation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donation()
        {
            ProcessingDonations = new HashSet<ProcessingDonation>();
        }

        public long Id { get; set; }

        public long? DonorId { get; set; }

        public long? AddressId { get; set; }

        [StringLength(2)]
        public string BloodType { get; set; }

        [StringLength(1)]
        public string Rh { get; set; }

        public int? Quantity { get; set; }

        public long? Date { get; set; }

        public int? Status { get; set; }

        public int? Flags { get; set; }

        public virtual Address Address { get; set; }

        public virtual Donor Donor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProcessingDonation> ProcessingDonations { get; set; }
    }
}
