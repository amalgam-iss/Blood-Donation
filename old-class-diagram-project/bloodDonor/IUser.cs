using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bloodDonor
{
    public interface IUser
    {
        void ILogin();
        void ILogout();
        void IChangePassword();
    }
}