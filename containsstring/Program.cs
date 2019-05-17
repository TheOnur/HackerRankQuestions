using System;
using System.Collections.Generic;
using System.Linq;

namespace containsstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "hackerrank";

            foreach (string sample in new List<string> {"rhbaasdndfsdskgbfefdbrsdfhuyatrjtcrtyytktjjt" })
            {
                bool contains = ContainsKey(sample, key);

                Console.WriteLine(contains ? "YES" : "NO");
            }

            Console.ReadLine();
        }

        private static bool ContainsKey(string sample, string key)
        {
            List<KeyInfo> list = key.Select(x => new KeyInfo { chr = x, isVisited = false }).ToList();

            foreach (char c in sample)
            {
                if (list.Any(x => x.chr == c))
                {
                    var keyValue = list.FirstOrDefault(x => x.chr == c && !x.isVisited);
                    if (keyValue != null) keyValue.isVisited = true;
                }
            }

            return list.All(x => x.isVisited);
        }
    }

    public class KeyInfo
    {
        public char chr { get; set; }
        public bool isVisited { get; set; }
    }
}
