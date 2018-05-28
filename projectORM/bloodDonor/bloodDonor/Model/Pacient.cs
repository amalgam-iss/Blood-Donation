namespace BloodDonor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pacient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pacient()
        {

        }

        public long Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(2)]
        public string BloodType { get; set; }

        [StringLength(1)]
        public string Rh { get; set; }
    }
}
