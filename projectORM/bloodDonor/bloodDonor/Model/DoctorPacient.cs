namespace BloodDonor.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DoctorPacient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoctorPacient()
        {
            BloodRequests = new HashSet<BloodRequest>();
        }

        public long Id { get; set; }

        public long? DoctorId { get; set; }

        public long? PacientId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BloodRequest> BloodRequests { get; set; }

        public virtual User User { get; set; }

        public virtual Pacient Pacient { get; set; }
    }
}
