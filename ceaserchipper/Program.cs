using System;
using System.Text;

namespace ceaserchipper
{
    class Program
    {
        private static char[] lower;
        private static char[] upper;
        static void Main(string[] args)
        {
            lower = GenerateKey(false);
            upper = GenerateKey(true);

            string originalText = "All men must die";
            int shiftCount = 7;
            string encryptedText = Encrypt(originalText, shiftCount);

            Console.WriteLine(encryptedText);
            Console.ReadLine();
        }
        private static char[] GenerateKey(bool isUpper)
        {
            int index = 0;
            char[] arr = new char[26];

            if (isUpper)
            {
                for (char i = 'A'; i <= 'Z'; i++)
                {
                    arr[index++] = i;
                }
            }
            else
            {
                for (char i = 'a'; i <= 'z'; i++)
                {
                    arr[index++] = i;
                }
            }

            return arr;
        }
        private static string Encrypt(string originalText, int shiftCount)
        {
            StringBuilder encrypted = new StringBuilder();

            foreach (char originalChar in originalText)
            {
                if (!char.IsLetter(originalChar))
                {
                    encrypted.Append(originalChar);
                    continue;
                }

                bool isUpper = char.IsUpper(originalChar);

                int originalIndex = FindIndex(originalChar, isUpper);

                int newIndex = (originalIndex + shiftCount) % 26;

                char newChar = !isUpper ? lower[newIndex] : upper[newIndex];

                encrypted.Append(newChar);
            }

            return encrypted.ToString();
        }
        private static int FindIndex(char originalChar, bool isUpper)
        {
            if (isUpper)
            {
                for (int i = 0; i < upper.Length; i++)
                {
                    if (originalChar == upper[i])
                    {
                        return i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < lower.Length; i++)
                {
                    if (originalChar == lower[i])
                    {
                        return i;
                    }
                }
            }

            return 0;
        }
    }
}
