using System;
using System.Collections.Generic;
using System.Text;

namespace reducedstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string textToShortened = "aassa";

            string shortened = Shortened(textToShortened);

            Console.WriteLine(shortened);

            Console.ReadLine();

        }
        private static string Shortened(string textToShortened)
        {
            int i = 0;
            int j = 0;
            int n = textToShortened.Length;

            for (int k = 0; k < n; k++)
            {
                i = k;
                j = i + 1;

                if (j < n)
                {
                    if (textToShortened[i] == textToShortened[j])
                    {
                        textToShortened = ReshapeText(textToShortened, i, j);
                        break;
                    }
                }
            }

            if (ContinueToShorten(textToShortened))
            {
                return Shortened(textToShortened);
            }

            return string.IsNullOrEmpty(textToShortened) ? "Empty String" : textToShortened;
        }
        private static string ReshapeText(string textToShortened, int startIndex, int endIndex)
        {
            int n = textToShortened.Length;
            StringBuilder newText = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                if (i == startIndex)
                {
                    continue;
                }
                else if (i == endIndex)
                {
                    continue;
                }
                else
                {
                    newText.Append(textToShortened[i]);
                }
            }

            return newText.ToString();
        }
        private static bool ContinueToShorten(string textToShortened)
        {
            int i = 0;
            int j = 0;
            int n = textToShortened.Length;

            for (int k = 0; k < n; k++)
            {
                i = k;
                j = i + 1;

                if (j < n)
                {
                    if (textToShortened[i] == textToShortened[j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
