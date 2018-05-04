namespace BloodDonor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonorDisease")]
    public partial class DonorDisease
    {
        public long Id { get; set; }

        public long? DonorId { get; set; }

        public long? DiseaseId { get; set; }

        public virtual Disease Disease { get; set; }

        public virtual Donor Donor { get; set; }
    }
}
