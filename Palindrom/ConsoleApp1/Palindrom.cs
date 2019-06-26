using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class Palindrom
    {
        public static bool IsPalindrom(this object phrase)
        {
            string a = phrase.ToString().ToLower();
            List<char> onlyLetters = new List<char>();

            foreach (var item in a)
            {
                if (item >= 'a' && item <= 'z')
                {
                    onlyLetters.Add(item);
                }
            }

            string str1 = new string(onlyLetters.ToArray());

            string str2 = new string(str1.Reverse().ToArray());

            if (str1 == str2)
            {
                return true;
            }
            return false;
        }
    }
}
