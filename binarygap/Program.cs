using System;
using System.Collections.Generic;
using System.Text;

namespace binarygap
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 19;
            int @base = 2;

            string numberAtBaseEqual = FindNumberAtBaseEqual(number, @base);

            Console.WriteLine($"{number} in binary format is {numberAtBaseEqual}");

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
                int currentIndex = i;
                int rightIndex = currentIndex + 1;

                while (rightIndex < n)
                {
                    if (numberInBinary[currentIndex] == '0')
                    {
                        break;
                    }

                    if (numberInBinary[currentIndex] == '1' && numberInBinary[rightIndex] == '0')
                    {
                        rightIndex++;
                        continue;
                    }
                    
                    if (numberInBinary[currentIndex] == '1' && numberInBinary[rightIndex] == '1' && (rightIndex - currentIndex != 1))
                    {
                        int tmp = rightIndex - currentIndex;

                        if (tmp > maxDist)
                        {
                            maxDist = tmp;
                        }
                    }

                    break;
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
