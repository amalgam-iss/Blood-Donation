namespace BloodDonor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BloodPack
    {
        public long Id { get; set; }

        [StringLength(255)]
        public string Group { get; set; }

        [StringLength(255)]
        public string Rh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Creation_date { get; set; }

        [StringLength(255)]
        public string Status { get; set; }
    }
}
