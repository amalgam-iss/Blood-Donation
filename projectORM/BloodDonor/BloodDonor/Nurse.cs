namespace BloodDonor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nurse
    {
        public long ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
    }
}
