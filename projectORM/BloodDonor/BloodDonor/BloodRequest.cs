namespace BloodDonor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BloodRequest
    {
        public long Id { get; set; }

        public long? DoctorPacientId { get; set; }

        [StringLength(2)]
        public string BloodType { get; set; }

        [StringLength(1)]
        public string Rh { get; set; }

        public int? Quantity { get; set; }

        public int? Urgency { get; set; }

        public long? AddressId { get; set; }

        public int? Requested_quantity { get; set; }

        public int? Received_quantity { get; set; }

        public virtual DoctorPacient DoctorPacient { get; set; }
    }
}
