using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryTest;

namespace ProjectTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Check_8Char()
        {
            string password = "87654321";
            bool expected = false;

            bool actual = PasswordChecker.ValidatePassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_4Char()
        {

            string password = "2314";

            bool actual = PasswordChecker.ValidatePassword(password);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Check_32Char()
        {

            string password = "1234567891011121314151617181920";
            bool expected = false;

            bool actual = PasswordChecker.ValidatePassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_PasswordWithDigits_true()
        {

            string password = "ASDqwe1$";
            bool expected = true;

            bool actual = PasswordChecker.ValidatePassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_PasswordWithoutDigits_false()
        {

            string password = "qwSD$ASDA";
            bool expected = false;

            bool actual = PasswordChecker.ValidatePassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_PasswordWithSpecSimvols_true()
        {

            string password = "Ae12qw$3";
            bool expected = true;

            bool actual = PasswordChecker.ValidatePassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_PasswordWithSpecSimvols_false()
        {

            string password = "Awe123qweq";
            bool expected = false;

            bool actual = PasswordChecker.ValidatePassword(password);
            Assert.AreEqual(expected, actual);
        }
    }
}
