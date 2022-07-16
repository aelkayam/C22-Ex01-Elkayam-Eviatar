using System;

namespace Ex01_01
{
    internal class Program
    {
        public static void Main()
        {
            // input and authentication:
            string firstNumber = userInput();
            string secondNumber = userInput();
            string thirdNumber = userInput();

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
            int numOfPalindromes = countPalindromes(firstNumberDecimal, secondNumberDecimal, thirdNumberDecimal);

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
        private static string userInput()
        {
            string userInputString;
            bool isValid;
            do
            {
                Console.WriteLine("Please enter three 7-digits binary numbers.");
                userInputString = Console.ReadLine();
                isValid = authenticateString(userInputString);
                if (!isValid)
                {
                    Console.WriteLine("Invalid Input! Please try again.");
                }
            }
            while (!isValid);
            return userInputString;
        }

        // check if the string is correct length and in binary format.
        private static bool authenticateString(string userInputString)
        {
            bool isCorrectLengh = userInputString.Length == 7;
            bool isBinaryNum = true;
            for (int i = 0; i < userInputString.Length; i++)
            {
                if (userInputString[i] != '1' && userInputString[i] != '0')
                {
                    isBinaryNum = false;
                }
            }

            return isCorrectLengh && isBinaryNum;
        }

        private static int countNumsDivisibleByThree(int i_FirstNumberDecimal, int i_SecondNumberDecimal, int i_ThirdNumberDecimal)
        {
            int numOfDivisibleByThree = 0;
            if (divisibleByThree(i_FirstNumberDecimal))
            {
                numOfDivisibleByThree++;
            }

            if (divisibleByThree(i_SecondNumberDecimal))
            {
                numOfDivisibleByThree++;
            }

            if (divisibleByThree(i_ThirdNumberDecimal))
            {
                numOfDivisibleByThree++;
            }

            return numOfDivisibleByThree;
        }

        // return true if the number is divisible by 3.
        private static bool divisibleByThree(int i_DecimalNum)
        {
            int remainder = i_DecimalNum % 3;
            return remainder == 0;
        }

        private static int countPalindromes(int i_FirstNumberDecimal, int i_SecondNumberDecimal, int i_ThirdNumberDecimal)
        {
            int numOfPalindromes = 0;
            if (isPalindrome(i_FirstNumberDecimal))
            {
                numOfPalindromes++;
            }

            if (isPalindrome(i_SecondNumberDecimal))
            {
                numOfPalindromes++;
            }

            if (isPalindrome(i_ThirdNumberDecimal))
            {
                numOfPalindromes++;
            }

            return numOfPalindromes;
        }

        // return true if the number is a palindrome
        private static bool isPalindrome(int i_Num)
        {
            int reveredNum = 0;
            int originalNum = i_Num;
            while(i_Num > 0)
            {
                reveredNum = (reveredNum * 10) + (i_Num % 10);
                i_Num /= 10;
            }

            return reveredNum == originalNum;
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
        private static void ascendingSort(int num1, int num2, int num3, out int first, out int second, out int third)
        {
            if(num1 > num2)
            {
                if(num1 > num3)
                {
                    first = num1;
                    if(num2 > num3)
                    {
                        second = num2;
                        third = num3;
                    }
                    else
                    {
                        second = num3;
                        third = num2;
                    }
                }
                else
                {
                    first = num3;
                    second = num1;
                    third = num2;
                }
            }
            else
            {
                if (num2 > num3)
                {
                    first = num2;
                    if (num1 > num3)
                    {
                        second = num1;
                        third = num3;
                    }
                    else
                    {
                        second = num3;
                        third = num1;
                    }
                }
                else
                {
                    first = num3;
                    second = num2;
                    third = num1;
                }
            }
        }
    }
}
