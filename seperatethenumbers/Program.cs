using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace seperatethenumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            foreach (string number in new string[] { "9899100" })
            {
                long min = long.MinValue;
                bool result = CanSeparate(number, out min);

                Console.WriteLine(result ? $"YES {min}" : "NO");
            }

            Console.ReadLine();
        }
        private static bool CanSeparate(string number, out long min)
        {
            int n = number.Length;
            min = 0;
            bool canSeparate = false;

            int index = 0;

            while (index < n )
            {
                long start = long.Parse(number.Substring(0, index + 1));

                bool generatedStringValid = GenerateNumber(start, number, n);

                if (generatedStringValid)
                {
                    min = start;
                    return canSeparate = true;
                }
                else
                {
                    index++;
                }
            }


            return canSeparate;
        }
        private static bool GenerateNumber(long start, string number, int times)
        {
            StringBuilder sbNumber = new StringBuilder();

            while (times > 0)
            {
                string append = start.ToString();
                sbNumber.Append(append);
                start += 1;
                times -= append.Length;
            }

            return number == sbNumber.ToString();
        }
    }
}
