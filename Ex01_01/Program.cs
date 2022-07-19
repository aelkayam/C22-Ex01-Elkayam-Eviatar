using System;

namespace Ex01_01
{
    // input types for Ex01_01, Ex01_04, Ex01_05.
    public enum eInputType
    {
        binary,
        LettersOrNumbersExclusively,
        integer,
    }

    public class Program
    {
        public static void Main()
        {
            // input and authentication:
            string message = "three 7-digits binary numbers.";
            string firstNumber = UserInput(eInputType.binary, 7, message);
            string secondNumber = UserInput(eInputType.binary, 7, message);
            string thirdNumber = UserInput(eInputType.binary, 7, message);

            // average zeros/ones:
            float avgZerosInInput = getAvgAppearancesOfDigit(firstNumber, secondNumber, thirdNumber, '0');
            float avgOnesInInput = getAvgAppearancesOfDigit(firstNumber, secondNumber, thirdNumber, '1');

            // conversion:
            int firstNumberDecimal = convertToDecimal(int.Parse(firstNumber));
            int secondNumberDecimal = convertToDecimal(int.Parse(secondNumber));
            int thirdNumberDecimal = convertToDecimal(int.Parse(thirdNumber));

            // check how many are divisible by 3:
            int numOfDivisibleByThree = countNumsDivisibleByThree(firstNumberDecimal, secondNumberDecimal, thirdNumberDecimal);

            // check how many are palindromes:
            int numOfPalindromes = countPalindromes(firstNumber, secondNumber, thirdNumber);

            ascendingSort(firstNumberDecimal, secondNumberDecimal, thirdNumberDecimal, out int biggestNum, out int midNum, out int smallestNum);

            // output:
            Console.WriteLine(@"The numbers in decimal and in order are: {0} {1} {2}", biggestNum, midNum, smallestNum);
            Console.WriteLine(
@"The average of zeros is: {0} and the average of ones: {1}
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
        public static string UserInput(eInputType i_InputType, int i_requiredLength, string i_Message)
        {
            string userInputString;
            bool isValid;
            do
            {
                Console.WriteLine(@"Please enter {0}", i_Message);
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

        private static int countNumsDivisibleByThree(int i_FirstNumberDecimal, int i_SecondNumberDecimal, int i_ThirdNumberDecimal)
        {
            int numOfDivisibleByThree = 0;
            if (DivisibleByThree(i_FirstNumberDecimal))
            {
                numOfDivisibleByThree++;
            }

            if (DivisibleByThree(i_SecondNumberDecimal))
            {
                numOfDivisibleByThree++;
            }

            if (DivisibleByThree(i_ThirdNumberDecimal))
            {
                numOfDivisibleByThree++;
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
        private static int countPalindromes(string i_FirstNumber, string i_SecondNumber, string i_ThirdNumber)
        {
            int numOfPalindromes = 0;
            if (IsPalindrome(i_FirstNumber))
            {
                numOfPalindromes++;
            }

            if (IsPalindrome(i_SecondNumber))
            {
                numOfPalindromes++;
            }

            if (IsPalindrome(i_ThirdNumber))
            {
                numOfPalindromes++;
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
        private static int convertToDecimal(int i_BinaryNum)
        {
            int digit;
            int digitPlacement = 0;
            int decimalResult = 0;
            while(i_BinaryNum > 0)
            {
                digit = i_BinaryNum % 10;
                decimalResult += digit * (int)Math.Pow(2, digitPlacement);
                digitPlacement++;
                i_BinaryNum /= 10;
            }

            return decimalResult;
        }

        // calculate the average appearances of a digit in three numbers.
        private static float getAvgAppearancesOfDigit(string i_FirstNumber, string i_SecondNumber, string i_ThirdNumber, char i_Digit)
        {
            int totalZeros = countDigits(i_FirstNumber, i_Digit) + countDigits(i_SecondNumber, i_Digit) + countDigits(i_ThirdNumber, i_Digit);
            return totalZeros / 3f;
        }

        // count instances of a digit in a number.
        private static int countDigits(string i_Number, char i_Digit)
        {
            int amountOfDigit = 0;
            for(int i = 0; i < i_Number.Length; i++)
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
