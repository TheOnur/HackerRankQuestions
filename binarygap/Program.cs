using System;
using System.Collections.Generic;
using System.Text;

namespace binarygap
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 15;
            int @base = 2;

            string numberAtBaseEqual = FindNumberAtBaseEqual(number, @base);

            int maxGap = MaxGap(numberAtBaseEqual);

            Console.WriteLine(maxGap);

            Console.ReadLine();
        }
        private static int MaxGap(string numberInBinary)
        {
            int maxDist = int.MinValue;
            int n = numberInBinary.Length;

            for (int i = 0; i < n; i++)
            {
                int j = i;
                int k = i + 1;

                while (k < n)
                {
                    if (numberInBinary[j] == '1' && numberInBinary[k] != '1')
                    {
                        int tmpDist = k - j;

                        if (tmpDist > maxDist)
                        {
                            maxDist = tmpDist;
                        }
                    }
                    else if (numberInBinary[j] == '1' && numberInBinary[k] == '1')
                    {
                        break;
                    }
                    else if (numberInBinary[j] != '1' )
                    {
                        break;
                    }

                    k++;
                }

            }

            return maxDist == int.MinValue ? 0 : maxDist;
        }
        private static string FindNumberAtBaseEqual(int number, int @base)
        {
            Stack<int> remainderStack = new Stack<int>();
            while (number - (number / @base) % @base != 0)
            {
                int remainder = 0;
                int tmp = number;
                number /= @base;

                remainder = tmp - (number * @base);
                remainderStack.Push(remainder);
            }

            StringBuilder numberInBinary = new StringBuilder();

            while (remainderStack.Count > 0)
            {
                numberInBinary.Append(remainderStack.Pop());
            }

            return numberInBinary.ToString();
        }
    }
}
