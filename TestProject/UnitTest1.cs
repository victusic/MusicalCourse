using com.sun.tools.doclint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLibrary;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Check_8Char()
        {       
           string password = "12345678";
            bool expected = false;

            bool actual = Checker.CheckPassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_4Char()
        {
          
            string password = "1234";
            
            bool actual = PasswordChecker.CheckPassword(password);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Check_30Char()
        {

            string password = "12345678333333333333333333333333333333333333333333";
            bool expected = false;

            bool actual = PasswordChecker.CheckPassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_PasswordWithDigits_true()
        {

            string password = "ASDqwe1$";
            bool expected = true;

            bool actual = PasswordChecker.CheckPassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_PasswordWithoutDigits_false()
        {

            string password = "ASDqwASD$";
            bool expected = false;

            bool actual = PasswordChecker.CheckPassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_PasswordWithSpecSimvols_true()
        {

            string password = "Aqwe123$";
            bool expected = true;

            bool actual = PasswordChecker.CheckPassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_PasswordWithSpecSimvols_false()
        {

            string password = "ASDqwe123";
            bool expected = false;

            bool actual = PasswordChecker.CheckPassword(password);
            Assert.AreEqual(expected, actual);
        }
    }
}
