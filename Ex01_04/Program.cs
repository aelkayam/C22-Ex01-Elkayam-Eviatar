using System;

namespace Ex01_04
{
    internal class Program
    {
        public static void Main()
        {
            // user input:
            const int k_requiredLength = 9;
            string message = "9 characters, either letters only (uppercase or lowercase) or numbers only";
            string input = Ex01_01.Program.UserInput(Ex01_01.eInputType.LettersOrNumbersExclusively, k_requiredLength, message);

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
        private static string isDivisibleByThree(int i_InputNum)
        {
            string stringResult;
            bool isDivisibleByThree = Ex01_01.Program.DivisibleByThree(i_InputNum);
            if (isDivisibleByThree)
            {
                stringResult = "The number does divide by 3";
            }
            else
            {
                stringResult = "The number is not divisible by 3";
            }

            return stringResult;
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
            string strResultReturn;
            if (isPalindrome)
            {
                strResultReturn = "the string is a palindrome ";
            }
            else
            {
                strResultReturn = "the string is not a palindrome ";
            }

            return strResultReturn;
        }
    }
}