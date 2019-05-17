using System;
using System.Collections.Generic;

namespace ispalindromestring
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "cdcdcdcdeeeef";

            bool isPalindrome = checkPalindrome(input);

            bool checkPalindrome(string text)
            {
                Dictionary<char, int> map = new Dictionary<char, int>();

                foreach (char c in text)
                {
                    if (map.ContainsKey(c))
                    {
                        map[c] += 1;
                    }
                    else
                    {
                        map.Add(c, 1);
                    }
                }

                int total = 0;

                foreach (KeyValuePair<char, int> pair in map)
                {
                    total += (pair.Value % 2);
                }

                return total <= 1;
            }

            Console.WriteLine(isPalindrome ? "YES" : "NO");

            Console.ReadLine();
        }
    }
}
