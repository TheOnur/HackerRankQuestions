using System;

namespace markscakewalk
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int[] cakes = new[] { 1, 3, 2 };

            long minKm = findMinKm(n, cakes);

            Console.WriteLine(minKm);

            long findMinKm(int count, int[] arr)
            {
                long total = 0;

                Array.Sort(arr);
                Array.Reverse(arr);

                for (int i = 0; i < n; i++)
                {
                    total += ((long)Math.Pow(2, i) * arr[i]);
                }

                return total;
            }

            Console.ReadLine();
        }
    }
}
