using System;

namespace Q3._URLify
{
    class Program
    {
        private static int Count_the_number_of_spaces(string input)
        {
            var spaceCount = 0;
            foreach (char character in input)
            {
                if (character == ' ')
                    spaceCount++;
            }
            return spaceCount;
        }

        private static void ReplaceSpaces(char[] input, int length, int countedSpaces)
        {
            var space = new[] { '0', '2', '%' };
            var spaceCount = countedSpaces;
            var index = length + spaceCount * 2;   // calculate new string size 

            // set "02%" to the string
            void SetCharsAndMoveIndex(params char[] chars)  // params to take list of characters :P
            {
                foreach (var c in chars)
                    input[index--] = c;
            }

            // copying the characters backwards and inserting %20
            for (var indexSource = length - 1; indexSource >= 0; indexSource--)
                if (input[indexSource] == ' ')
                    SetCharsAndMoveIndex(space);
                else SetCharsAndMoveIndex(input[indexSource]);
        }
        static void Main(string[] args)
        {
            string str = "Mr John Smith    ";
            string input = str.TrimEnd();  // spaces removed from end
            var spaceCount = Count_the_number_of_spaces(input);
            var characterArray = new char[input.Length + spaceCount * 2 + 1];

            for (var i = 0; i < input.Length; i++)
            {
                characterArray[i] = input[i];
            }

            ReplaceSpaces(characterArray, input.Length, spaceCount);
            Console.WriteLine("{0} -> {1}", str, new string(characterArray));
        }
    }
}
