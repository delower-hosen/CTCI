using System;
using System.Collections.Generic;
using System.Linq;

namespace Q2._Check_Permutation
{
    class Program
    {
        // Solution-1: Compare the two strings after sorting them
        private static bool IsPermutation1(string FirstString, string SecondString)
        {
            if (FirstString.Length != SecondString.Length) return false;

            string SortedFirstString = string.Concat(FirstString.OrderBy(ch => ch));
            string SortedSecondString = string.Concat(SecondString.OrderBy(ch => ch));

            return SortedFirstString.Equals(SortedSecondString);
        }

        // Solution-2: Checking if two strings have identical character counts

        private static bool IsPermutation2(string FirstString, string SecondString)
        {
            if (FirstString.Length != SecondString.Length) return false;
            Dictionary<char, int> LetterCount = new Dictionary<char, int>();
             
            foreach (char character in FirstString)
            {
                if (LetterCount.ContainsKey(character))
                {
                    LetterCount[character]++;
                }
                else
                {
                    LetterCount[character] = 1;
                }
            }

            foreach (char character in SecondString)
            {
                if (LetterCount.ContainsKey(character))
                {
                    LetterCount[character]--;
                    if (LetterCount[character] < 0) return false;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            string[][] pairs =
{
                new string[]{"apple", "papel"},
                new string[]{"carrot", "tarroc"},
                new string[]{"hello", "llloh"}
            };

            foreach (var pair in pairs)
            {
                var word1 = pair[0];
                var word2 = pair[1];
                var result1 = IsPermutation1(word1, word2);
                var result2 = IsPermutation2(word1, word2);
                Console.WriteLine("{0}, {1}: {2}/{3}", word1, word2, result1, result2);
            }
        }
    }
}
