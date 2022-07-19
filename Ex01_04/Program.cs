using System;
using System.Text;

namespace Ex01_04
{
    internal class Program
    {
        public static void Main()
        {
            // user input:
            const int k_RequiredLength = 9;
            string message = "9 characters, either letters only (uppercase or lowercase) or numbers only";
            string input = Ex01_01.Program.UserInput(Ex01_01.eInputType.LettersOrNumbersExclusively, k_RequiredLength, message);

            // check divisibility by 3 or how many lowercase letters:
            bool isNumber = int.TryParse(input, out int inputNum);
            if (isNumber)
            {
                Console.WriteLine(isDivisibleByThree(inputNum));
            }
            else
            {
                Console.WriteLine(numOfLowercaseLetters(input));
            }

            // check if palindrome:
            Console.WriteLine(isPalindromeString(input));

            // exit:
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        // returns answer for divisibility by 3.
        private static string isDivisibleByThree(int i_NumToCheck)
        {
            StringBuilder stringResult = new StringBuilder("The number is divisible by 3");
            bool isDivisibleByThree = Ex01_01.Program.DivisibleByThree(i_NumToCheck);
            if (!isDivisibleByThree)
            {
                stringResult.Replace("is", "is not");
            }

            return stringResult.ToString();
        }

        // returns answer for number of lowercase letters.
        private static string numOfLowercaseLetters(string i_StringOfLetters)
        {
            int counterLowercase = calculateNumOfLowercaseLetters(i_StringOfLetters);
            string numOfCounterLowercaseOrNot;
            if (counterLowercase == 0)
            {
                numOfCounterLowercaseOrNot = "no";
            }
            else
            {
                numOfCounterLowercaseOrNot = counterLowercase.ToString();
            }

            string strResultReturn = string.Format(@"In the string {0} there are {1} lowercase letters", i_StringOfLetters, numOfCounterLowercaseOrNot);

            return strResultReturn;
        }

        // count how many lowercase letters are in a string.
        private static int calculateNumOfLowercaseLetters(string i_StrOfUpperAndLowercase)
        {
            int i_CountLowercase = 0;

            for (int i = 0; i < i_StrOfUpperAndLowercase.Length; i++)
            {
                if (char.IsLower(i_StrOfUpperAndLowercase[i]))
                {
                    i_CountLowercase++;
                }
            }

            return i_CountLowercase;
        }

        // check if the string is a palindrome.
        private static string isPalindromeString(string i_inputStr)
        {
            bool isPalindrome = Ex01_01.Program.IsPalindrome(i_inputStr);
            StringBuilder strResultReturn = new StringBuilder("the string is not a palindrome");
            if (isPalindrome)
            {
                strResultReturn.Replace("is not", "is");
            }

            return strResultReturn.ToString();
        }
    }
}