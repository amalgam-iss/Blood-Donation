using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bloodDonor
{
    public abstract class Repository
    {
        public void add(bloodDonor.User user)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Number of deleted entities.
        /// </summary>
        public int remove(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}