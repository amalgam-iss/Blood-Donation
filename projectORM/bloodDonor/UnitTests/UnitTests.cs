using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BloodDonor.Controllers;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestWeight()
        {
            RegisterController register = new RegisterController();
            register.CheckWeightTest("sdfsdfds");
            register.CheckWeightTest("-98");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAge()
        {
            RegisterController register = new RegisterController();
            register.CheckAgeTest("asdaf");
            register.CheckAgeTest("100");
            register.CheckAgeTest("-100");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBloodType()
        {
            RegisterController register = new RegisterController();
            register.CheckBloodTypeTest("Afsdf");
            register.CheckBloodTypeTest("0sdfsf");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCheckDate()
        {
            RegisterController register = new RegisterController();
            register.CheckDateTest("fdgd/fgd/fdgd");
            register.CheckDateTest("100/09/1900");
            register.CheckDateTest("10/19/1992");
            register.CheckDateTest("10/10/-1234");
        }
    }
}
