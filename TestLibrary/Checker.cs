using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    class Checker
    {
        public static bool CheckPassword(string password)
        {
            if (password.Length < 8 || password.Length > 20)
                return false;
            if (!password.Any(Char.IsDigit))
                return false;
            if (password.Intersect("^&%_#$").Count() == 0)
                return false;

            return true;
        }
    }
}
