using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minimumabsolutedifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int[] arr = Array.ConvertAll("-59 -36 -13 1 -53 -92 -2 -96 -54 75".Split(' '),
                arrTemp => Convert.ToInt32(arrTemp));

            int minDiff = findMinDiff(n, arr);

            int findMinDiff(int length, int[] array)
            {

                int min = int.MaxValue;

                Array.Sort(array);

                for (int i = 0; i < length; i++)
                {
                    int j = i + 1;

                    if (j < length)
                    {
                        int diff = Math.Abs(array[j] - array[i]);

                        if (min > diff)
                        {
                            min = diff;
                        }
                    }
                }

                return min;
            }

            Console.WriteLine(minDiff);

            Console.ReadLine();
        }


    }
}
