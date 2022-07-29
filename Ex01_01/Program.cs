using System;
using System.Text;

namespace Ex01_01
{
    public class Program
    {
        // input types for Ex01_01, Ex01_04, Ex01_05.
        public enum eInputType
        {
            binary,
            LettersOrNumbersExclusively,
            integer,
        }

        public static void Main()
        {
            // input and authentication:
            const int k_RequiredLength = 7;
            StringBuilder message = new StringBuilder("the 1st 7-digits binary number");

            Console.WriteLine(string.Format("Please enter three {0}-digits binary numbers.", k_RequiredLength));
            string firstNumber = GetUserInput(eInputType.binary, k_RequiredLength, message.ToString());
            message.Replace("1st", "2nd");
            string secondNumber = GetUserInput(eInputType.binary, k_RequiredLength, message.ToString());
            message.Replace("2nd", "3rd");
            string thirdNumber = GetUserInput(eInputType.binary, k_RequiredLength, message.ToString());

            // average zeros/ones:
            float avgZerosInInput = getAvgAppearancesOfDigit('0', firstNumber, secondNumber, thirdNumber);
            float avgOnesInInput = getAvgAppearancesOfDigit('1', firstNumber, secondNumber, thirdNumber);

            // conversion:
            int firstNumberDecimal = convertBinaryToDecimal(int.Parse(firstNumber));
            int secondNumberDecimal = convertBinaryToDecimal(int.Parse(secondNumber));
            int thirdNumberDecimal = convertBinaryToDecimal(int.Parse(thirdNumber));

            // check how many are divisible by 3:
            int numOfDivisibleByThree = countNumsDivisibleByThree(firstNumberDecimal, secondNumberDecimal, thirdNumberDecimal);

            // check how many are palindromes:
            int numOfPalindromes = countPalindromes(firstNumberDecimal, secondNumberDecimal, thirdNumberDecimal);

            ascendingSort(firstNumberDecimal, secondNumberDecimal, thirdNumberDecimal, out int biggestNum, out int midNum, out int smallestNum);

            // output:
            Console.WriteLine(@"The numbers in decimal and in order are: {0} {1} {2}", biggestNum, midNum, smallestNum);
            Console.WriteLine(
@"The average of zeros is: {0:0.##} and the average of ones: {1:0.##}
There are {2} numbers that are divisible by 3.
There are {3} palindromes.",
avgZerosInInput,
avgOnesInInput,
numOfDivisibleByThree,
numOfPalindromes);
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        // get user input, after authentication.
        public static string GetUserInput(eInputType i_InputType, int i_requiredLength, string i_Message)
        {
            string userInputString;
            bool isValid;

            do
            {
                Console.WriteLine(@"Please enter {0} and then Enter", i_Message);
                userInputString = Console.ReadLine();
                isValid = AuthenticateString(i_InputType, i_requiredLength, userInputString);
                if (!isValid)
                {
                    Console.WriteLine("Invalid Input! Please try again.");
                }
            }
            while (!isValid);

            return userInputString;
        }

        // check if the string is correct length and in correct format.
        public static bool AuthenticateString(eInputType i_InputType, int i_requiredLength, string i_UserInputString)
        {
            bool isCorrectLengh = i_UserInputString.Length == i_requiredLength;
            bool isValid = true;

            switch (i_InputType)
            {
                // ex_01:
                case eInputType.binary:
                    isValid = checkIfBinary(i_UserInputString);
                    break;

                // ex_04:
                case eInputType.LettersOrNumbersExclusively:
                    isValid = checkIfLettersOrDigitsExclusively(i_UserInputString);
                    break;

                // ex_05:
                case eInputType.integer:
                    isValid = checkOnlyDigits(i_UserInputString);
                    break;
            }

            return isValid && isCorrectLengh;
        }

        // return true if string consists of only number OR only letters.
        private static bool checkIfLettersOrDigitsExclusively(string i_UserInputString)
        {
            return checkOnlyLetters(i_UserInputString) || checkOnlyDigits(i_UserInputString);
        }

        // return true if the string consists only of numbers.
        private static bool checkOnlyDigits(string i_UserInputString)
        {
            int countValidCharacters = 0;

            for (int i = 0; i < i_UserInputString.Length; i++)
            {
                if (char.IsDigit(i_UserInputString[i]))
                {
                    countValidCharacters++;
                }
            }

            return countValidCharacters == i_UserInputString.Length;
        }

        // return true if the string consists only of letters.
        private static bool checkOnlyLetters(string i_UserInputString)
        {
            int countValidCharacters = 0;

            for (int i = 0; i < i_UserInputString.Length; i++)
            {
                if (char.IsLetter(i_UserInputString[i]))
                {
                    countValidCharacters++;
                }
            }

            return countValidCharacters == i_UserInputString.Length;
        }

        // return true if the string represents a binary number.
        private static bool checkIfBinary(string i_UserInputString)
        {
            bool isValid = true;

            for (int i = 0; i < i_UserInputString.Length; i++)
            {
                if (i_UserInputString[i] != '1' && i_UserInputString[i] != '0')
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        // return how many of the parameters are divisible by 3.
        private static int countNumsDivisibleByThree(params int[] i_ArrOfNumToComfigIsDivedBy3)
        {
            int numOfDivisibleByThree = 0;

            for (int i = 0; i < i_ArrOfNumToComfigIsDivedBy3.Length; i++)
            {
                if (DivisibleByThree(i_ArrOfNumToComfigIsDivedBy3[i]))
                {
                    numOfDivisibleByThree++;
                }
            }

            return numOfDivisibleByThree;
        }

        // return true if the number is divisible by 3.
        public static bool DivisibleByThree(int i_DecimalNum)
        {
            int remainder = i_DecimalNum % 3;

            return remainder == 0;
        }

        // return how many are palindromes
        private static int countPalindromes(params int[] i_ArgOfStrTocheck)
        {
            int numOfPalindromes = 0;

            for (int i = 0; i < i_ArgOfStrTocheck.Length; i++)
            {
                bool numIsPalindrome = IsPalindrome(i_ArgOfStrTocheck[i].ToString());
                if (numIsPalindrome)
                {
                    numOfPalindromes++;
                }
            }

            return numOfPalindromes;
        }

        // return true if the string is a palindrome.
        public static bool IsPalindrome(string i_String)
        {
            if (i_String.Length < 2)
            {
                return true;
            }
            else
            {
                bool bothEndsEqual = i_String[0].Equals(i_String[i_String.Length - 1]);
                string innerString = i_String.Substring(1, i_String.Length - 2);
                return bothEndsEqual && IsPalindrome(innerString);
            }
        }

        // convert binary to decimal.
        private static int convertBinaryToDecimal(int i_BinaryNum)
        {
            int digit;
            int digitPlacement = 0;
            int decimalResult = 0;

            while (i_BinaryNum > 0)
            {
                digit = i_BinaryNum % 10;
                decimalResult += digit * (int)Math.Pow(2, digitPlacement);
                digitPlacement++;
                i_BinaryNum /= 10;
            }

            return decimalResult;
        }

        // calculate the average appearances of a digit in three numbers.
        private static float getAvgAppearancesOfDigit(char i_Digit, params string[] i_ArgOfStrTocheck)
        {
            int totalAppearancesOfDigit = 0;
            int len = i_ArgOfStrTocheck.Length;

            if (len != 0)
            {
                for (int i = 0; i < len; i++)
                {
                    totalAppearancesOfDigit += countDigits(i_ArgOfStrTocheck[i], i_Digit);
                }
            }

            return totalAppearancesOfDigit / (float)len;
        }

        // count instances of a digit in a number.
        private static int countDigits(string i_Number, char i_Digit)
        {
            int amountOfDigit = 0;

            for (int i = 0; i < i_Number.Length; i++)
            {
                if (i_Number[i] == i_Digit)
                {
                    amountOfDigit++;
                }
            }

            return amountOfDigit;
        }

        // sort three numbers in ascending order
        private static void ascendingSort(int i_Num1, int i_Num2, int i_Num3, out int o_BiggestNumber, out int o_MiddleNumber, out int o_SmallestNumer)
        {
            int maxNum1Num2 = Math.Max(i_Num1, i_Num2);
            int maxNum2Num3 = Math.Max(i_Num2, i_Num3);
            o_BiggestNumber = Math.Max(maxNum1Num2, maxNum2Num3);

            // find middle number:
            if (o_BiggestNumber == i_Num2)
            {
                o_MiddleNumber = Math.Max(i_Num1, i_Num3);
            }
            else
            {
                o_MiddleNumber = Math.Min(maxNum2Num3, maxNum1Num2);
            }

            o_SmallestNumer = Math.Min(Math.Min(i_Num1, i_Num2), i_Num3);
        }
    }
}
