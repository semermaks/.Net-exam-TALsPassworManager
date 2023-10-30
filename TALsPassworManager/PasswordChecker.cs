using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TALsPassworManager
{
    public enum PasswordScore
    {
        Blank = 0,
        VeryWeak = 1,
        Weak = 2,
        Medium = 3,
        Strong = 4,
        VeryStrong = 5
    }
    public static class PasswordChecker
    {
        private static int CountOFWords = 0;
        public static bool ChechPass(string password)
        {
            bool result = false;
            string checker = "1234567890";
            string checker2 = "qwertasdfg";
            CheckString(password, User.Name);
            CheckString(password, User.Surname);
            CheckString(password, User.FatherName);
            CheckString(password, User.DateOFBirthday.ToShortDateString());
            CheckString(password, (DateTime.Now.Year - User.DateOFBirthday.Year).ToString());
            CheckString(password, User.Login);
            while(checker.Length != 1 && checker2.Length != 1)
            {
                CheckString(password, checker);
                CheckString(password, checker2);
                checker = checker.Substring(0, checker.Length - 1);
                checker2 = checker.Substring(0, checker2.Length - 1);
            }
            foreach (var pass in User.Passwords)
            {
                CheckString(password, pass.Value);
            }
            PasswordScore ps = CheckStrength(password);

            if(ps == PasswordScore.VeryStrong || ps == PasswordScore.Strong)
            {
                if (CountOFWords < (password.Length - (password.Length * 0.3))) result = true;
            }
            return result;
        }
        private static bool CheckString(string password, string str)
        {
            if (password.Contains(str))
            {
                CountOFWords += str.Length;
                return false;
            }
            return true;
        }


        private static PasswordScore CheckStrength(string password)
        {
            int score = 0;
            if (password.Length < 1)
                return PasswordScore.Blank;
            if (password.Length < 4)
                return PasswordScore.VeryWeak;

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, "[0-9]+").Success)
                score++;
            if (Regex.Match(password, "[a-z]").Success &&
              Regex.Match(password, "[A-Z]").Success)
                score++;
            if (Regex.Match(password, "[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]").Success)
                score++;

            return (PasswordScore)score;
        }

    }
}
