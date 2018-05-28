namespace BloodDonor
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

        public long? Date { get; set; }

        public int? Status { get; set; }

        public int? Flags { get; set; }

        public virtual Donor Donor { get; set; }
    }
}
