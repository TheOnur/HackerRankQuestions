using System;
using System.Collections.Generic;
using System.Linq;

namespace gridchallenge
{
    class Program
    {
        static bool isInOrder(int n, string[] grid)
        {
            bool allValid = true;
            List<Matrix> matrix = CreateMatrix(n, grid);

            for (int i = 0; i < n; i++)
            {
                List<Matrix> rowValues = matrix.Where(x => x.i == i).ToList();
                List<Matrix> columnValues = matrix.Where(x => x.j == i).ToList();

                allValid &= validate(rowValues) && validate(columnValues);
            }

            return allValid;
        }

        static bool validate(List<Matrix> values)
        {
            bool inOrder = true;

            for (int i = 0; i < values.Count; i++)
            {
                int j = i + 1;

                if (j < values.Count)
                {
                    inOrder &= values[i].char_value <= values[j].char_value;
                }
            }

            return inOrder;
        }

        static List<Matrix> CreateMatrix(int n, string[] grid)
        {
            List<Matrix> matrix = new List<Matrix>();

            int row = 0;
            int totalElement = grid.Length;
            int taken = 0;

            while (totalElement > taken)
            {
                int column = 0;
                List<Matrix> rowList = new List<Matrix>();

                foreach (string s in grid.Skip(row * n).Take(n))
                {
                    rowList.Add(new Matrix()
                    {
                        i = row,
                        j = column++,
                        value = s[0]
                    });
                }

                rowList = ReArrangeIf(rowList);
                matrix.AddRange(rowList);
                taken += n;
                row += 1;
            }

            return matrix;
        }

        private static List<Matrix> ReArrangeIf(List<Matrix> rowList)
        {
            return rowList.OrderBy(x => x.char_value).ToList();
        }

        public class Matrix
        {
            public int i { get; set; }
            public int j { get; set; }
            public char value { get; set; }
            public int char_value => value - '0';
        }

        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                string[] grid = new string[n];

                for (int i = 0; i < n; i++)
                {
                    string gridItem = Console.ReadLine();
                    grid[i] = gridItem;
                }

                string[] newGrid = new string[n * n];

                int index = 0;
                foreach (string s in grid)
                {
                    foreach (char c in s)
                    {
                        newGrid[index++] = c.ToString();

                    }
                }

                bool isInOrderResult = isInOrder(n, newGrid);
                Console.WriteLine(isInOrderResult ? "YES" : "NO");

                Console.ReadLine();
            }
        }
    }
}
