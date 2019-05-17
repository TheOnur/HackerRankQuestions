using System;
using System.Linq;

namespace marsexplonation
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = "SOSSPSSQSSOR";
            int diff = FindDifference(msg);
            Console.WriteLine(diff);

            Console.ReadLine();
        }
        private static int FindDifference(string msg)
        {
            int diff = 0;
            int take = 3;
            int skip = 0;

            while (take * skip != msg.Length)
            {
                string subMsg = msg.Substring(skip * take, take);

                for (int i = 0; i < 3; i++)
                {
                    if (i % 2 == 1)
                    {
                        bool notS = subMsg[i] != 'O';

                        if (notS)
                        {
                            diff += 1;
                        }
                    }
                    else
                    {
                        bool notO = subMsg[i] != 'S';

                        if (notO)
                        {
                            diff += 1;
                        }
                    }
                }

                skip++;
            }

            return diff;
        }
    }
}
