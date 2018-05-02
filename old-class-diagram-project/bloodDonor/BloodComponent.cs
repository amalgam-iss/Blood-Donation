using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bloodDonor
{
    public abstract class BloodComponent
    {
        public int Quantity
        {
            get => default(int);
            set
            {
            }
        }

        public string BloodType
        {
            get => default(int);
            set
            {
            }
        }

        public int Price
        {
            get => default(int);
            set
            {
            }
        }

        public string Info
        {
            get => default(int);
            set
            {
            }
        }

        public void Expire()
        {
            throw new System.NotImplementedException();
        }
    }
}