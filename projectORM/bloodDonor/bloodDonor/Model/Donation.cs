namespace BloodDonor.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Donation
    {
        public long Id { get; set; }

        public long? DonorId { get; set; }

        public long? AddressId { get; set; }

        [StringLength(2)]
        public string BloodType { get; set; }

        [StringLength(1)]
        public string Rh { get; set; }

        public int? Quantity { get; set; }

        public int? Flags { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? C_Date { get; set; }

        public virtual Donor Donor { get; set; }
    }
}
