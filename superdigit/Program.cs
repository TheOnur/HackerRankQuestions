using System;
using System.Text;

namespace superdigit
{
    class Program
    {
        static void Main(string[] args)
        {
            string N = "1476578";
            int R = 34654;

            string repeated = Repeated(N, R);
            int s = SuperDigit(repeated);
            Console.WriteLine(s);
            

            Console.ReadLine();
        }

        static string super_digit(string ns)
        {
            if (ns.Length == 1)
                return ns;
            return super_digit(digit_sum(ns).ToString());
        }

        static long digit_sum(string ns)
        {
            long sum = 0;
            for (int i = 0; i < ns.Length; i++)
            {
                sum += ns[i] - '0';
            }
            return sum;
        }

        private static string Repeated(string N, int R)
        {
            StringBuilder sbRepeated = new StringBuilder();

            for (int i = 0; i < R; i++)
            {
                sbRepeated.AppendFormat("{0}", N);
            }

            return sbRepeated.ToString();
        }
        private static int Length(string number)
        {
            return number.Length;
        }
        private static int SuperDigit(string repeatedNumber)
        {
            if (Length(repeatedNumber) != 1)
            {
                StringBuilder sbNew = new StringBuilder();

                int total = 0;

                for (int i = 0; i < Length(repeatedNumber); i++)
                {
                    total += repeatedNumber[i] - '0';
                }

                sbNew.AppendFormat("{0}", total);

                return SuperDigit(sbNew.ToString());
            }

            return int.Parse(repeatedNumber);
        }
    }
}
