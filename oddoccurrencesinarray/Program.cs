using System;

namespace oddoccurrencesinarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] { 1, 3, 1, 3, 12, 5, 1, 1, 5 };

            int? unpairedItem = MatchItemsInArrayNotEffficent(array);
            Console.WriteLine(unpairedItem);

            Console.ReadLine();
        }

        /// <summary>
        /// O(N^2) solution
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int? MatchItemsInArrayNotEffficent(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n; i++)
            {
                bool matched = false;

                for (int j = 0; j < n; j++)
                {
                    if (array[i] == array[j] && i != j)
                    {
                        matched = true;
                        break;
                    }
                }

                if (!matched)
                {
                    return array[i];
                }
            }

            return null;
        }

        /// <summary>
        /// O(N) solution
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int? MatchItemsInArrayEffficent(int[] array)
        {
            Array.Sort(array);

            int n = array.Length;

            for (int i = 0; i < n;)
            {
                int current = i;
                int right = current + 1;

                if (right < n && array[current] == array[right])
                {
                    i += 2;
                }
                else
                {
                    return array[current];
                }
            }

            return null;
        }
    }

}
