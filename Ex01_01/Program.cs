using System;

namespace Ex01_01
{
    public  class Program
    {
        public enum eInputType
        {
            Binary,
            Numbers,
            Letters,
            LettersAndNumbers,
        }
        public static void Main()
        {// to mach in main 
            // input and authentication:
            const int k_requiredLength = 7;
            string message = "three 7-digits binary numbers.";
            eInputType type = eInputType.Binary;
            string firstNumber = UserInput(type, k_requiredLength, message);
            string secondNumber = UserInput(type, k_requiredLength, message);
            string thirdNumber = UserInput(type, k_requiredLength, message);
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
        public static string UserInput(eInputType eInputType, int i_requiredLength, string i_Message)
        {
            string userInputString;
            bool v_isValid;

            do
            {
                Console.WriteLine("Please enter {0}", i_Message);
                userInputString = Console.ReadLine();
                v_isValid = AuthenticateString(eInputType, i_requiredLength, userInputString);
                if (!v_isValid)
                {
                    Console.WriteLine("Invalid Input! Please try again.");
                }
            }
            while (!v_isValid);
            return userInputString;
        }

        // check if the string is correct length and in correct format.
        public static bool AuthenticateString(eInputType type, int i_requiredLength, string userInputString)
        {
            bool v_isCorrectLengh = userInputString.Length == i_requiredLength;
            bool v_isValid = true;

            switch (type)
            {
                // ex_01:
                case eInputType.Binary:
                    for (int i = 0; i < userInputString.Length; i++)
                    {
                        if (userInputString[i] != '1' && userInputString[i] != '0')
                        {
                            v_isValid = false;
                            break;
                        }
                    }
                    break;
                // ex_04:
                case eInputType.Letters:

                    break;

                // ex_05:
                case eInputType.Numbers:

                    break;

                case eInputType.LettersAndNumbers:
                    break;
            }

            return v_isValid && v_isCorrectLengh;
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

        private static int countPalindromes(int i_FirstNumberDecimal, int i_SecondNumberDecimal, int i_ThirdNumberDecimal)
        {
            int numOfPalindromes = 0;
            string strForChakPol = i_FirstNumberDecimal.ToString();

            if (isPalindrome(strForChakPol))
            {
                numOfPalindromes++;
            }
            strForChakPol= i_SecondNumberDecimal.ToString();
            if (isPalindrome(strForChakPol))
            {
                numOfPalindromes++;
            }
            strForChakPol = i_ThirdNumberDecimal.ToString();
            if (isPalindrome(strForChakPol))
            {
                numOfPalindromes++;
            }

            return numOfPalindromes;
        }

        // return true if the number is a palindrome
        public static bool isPalindrome(string i_InputString)
        {
            int len = i_InputString.Length;
            bool v_isPalindrome = len > 1;

            if (v_isPalindrome)
            {
                bool v_isEdgesEquals = i_InputString[0].Equals(i_InputString[len - 1]);
                if (v_isEdgesEquals)
                {
                    string subInputStr = i_InputString.Substring(1, len - 1 );
                    v_isPalindrome = isPalindrome(subInputStr);
                }
            }

            return v_isPalindrome;
        }

        // convert binary to decimal.
        private static int convertToDecimal(int i_BinaryNum)
        {       // can do it betr mast have a fonc not a goo name  BinaryToDecimal 
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
        private static float getAvgAppearancesOfDigit(string i_FirstNumber, string i_SecondNumber, string i_ThirdNumber, char i_Digit)
        {// to mach in one line neet to do the the func whit ref 
            int totalZeros = countDigits(i_FirstNumber, i_Digit) + countDigits(i_SecondNumber, i_Digit) + countDigits(i_ThirdNumber, i_Digit);
            
            return totalZeros / 3f;
        }

        // count instances of a digit in a number. no a good name 
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
            // need to do it in bool ver 
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
