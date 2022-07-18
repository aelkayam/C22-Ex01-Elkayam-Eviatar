using System;
using Ex01_01;

namespace Ex01_04
{
    internal class Program
    {

        public static void Main()
        {
            // user input:
            string message = "a 9-characters string of either English letters, or digits only";
            string userInput = Ex01_01.Program.UserInput(eInputType.LettersOrNumbersExclusively, 9, message);

            // check if palindrome:
            bool isPalindrome = Program.isPalindrome(userInput);

            // check divisibility by 3 or how many lowercase letters:
            bool isDividibleByThree = false ;
            int countLowercase = 0;

            if(int.TryParse(userInput, out int userInputNum))
            {
                isDividibleByThree = Ex01_01.Program.DivisibleByThree(userInputNum); 
            }
            else
            {
                countLowercase = getNumOfLowercase(userInput);
            }

            // output:
            Console.WriteLine(@"Is it a palindrome: {0}", isPalindrome);
            if (isDividibleByThree)
            {
                Console.WriteLine("Divisible by 3");
            }
            else
            {
                Console.WriteLine(@"Number of lowercase letters: {0}", countLowercase);
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        // returns true if the string is a palindrome.
        private static bool isPalindrome(string i_String)
        {
            if(i_String.Length < 2)
            {
                return true;
            }
            else
            {
                bool bothEndsEqual = i_String[0] == i_String[i_String.Length - 1];
                string innerString = i_String.Substring(1, i_String.Length - 2);
                return bothEndsEqual && isPalindrome(innerString);
            }
        }

        // count the number of lowercase letters
        private static int getNumOfLowercase(string i_StringOfLetters)
        {
            int numOfLowercase = 0;
            for(int j = 0; j < i_StringOfLetters.Length; j++)
            {
                if (char.IsLower(i_StringOfLetters[j]))
                {
                    numOfLowercase++;
                }
            }

            return numOfLowercase;
        }
    }
}