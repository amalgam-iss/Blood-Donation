namespace bloodDonor
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
            DoctorPacients = new HashSet<DoctorPacient>();
        }

        public long Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(2)]
        public string BloodType { get; set; }

        [StringLength(1)]
        public string Rh { get; set; }

        public long? AddressId { get; set; }

        public virtual Address Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorPacient> DoctorPacients { get; set; }
    }
}
