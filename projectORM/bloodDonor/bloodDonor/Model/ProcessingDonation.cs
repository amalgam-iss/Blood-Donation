namespace bloodDonor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProcessingDonation
    {
        public long Id { get; set; }

        public long? RequestId { get; set; }

        public long? DonationId { get; set; }

        public long? PersonelId { get; set; }

        public long? Flags { get; set; }

        public virtual BloodRequest BloodRequest { get; set; }

        public virtual Donation Donation { get; set; }

        public virtual User User { get; set; }

        public override string ToString()
        {
            return "Donation processing:\n- Id: " + Id.ToString() +
                    "\n- RequestId: " + RequestId.ToString() +
                    "\n- DonationId: " + DonationId.ToString() +
                    "\n- PersonelId: " + PersonelId.ToString() +
                    "\n- Flags: " + Flags.ToString();
        }
    }
}
