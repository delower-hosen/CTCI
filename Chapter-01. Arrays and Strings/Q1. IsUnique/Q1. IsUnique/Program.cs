using System;
using System.Collections.Generic;

namespace Q1._IsUnique
{
    class Program
    {
        // Solution-1: Implementation using ascii value
        private static bool  IsUnique(string str)
        {
            bool[] CharSet = new bool[256];  // initially all indexes are set to false

            if (str.Length > 256) return false;

            for (int i = 0; i < str.Length; i++)
            {
                int AsciiValue = str[i] - '0';
                if (CharSet[AsciiValue]) return false;  // Already exists

                CharSet[AsciiValue] = true;
            }
            return true;
        }

        // Solution-2: Using C# HashSet
        private static bool IsUnique_UsingHashSet(string str)
        {
            var hashset = new HashSet<char>();
            foreach (var c in str)
            {
                if (hashset.Contains(c)) return false;
                hashset.Add(c);
            }

            return true;
        }
        static void Main(string[] args)
        {
            string[] words = { "abcde", "hello", "apple", "kite", "padle" };

            foreach (var word in words)
            {
                Console.WriteLine(word + ": " + IsUnique(word) + " " + IsUnique_UsingHashSet(word));
            }
        }
    }
}
