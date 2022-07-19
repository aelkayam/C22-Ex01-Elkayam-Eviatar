using System;
using System.Text;

namespace Ex01_05
{
    internal class Program
    {
        public static void Main()
        {
            // Receiving input from the user:
            const int k_RequiredLength = 9;
            string message = "an integer with 9 digits";
            string input = Ex01_01.Program.UserInput(Ex01_01.eInputType.integer, k_RequiredLength, message);

            // Performing and printing functions:
            Console.WriteLine(ConfigDigitsSmallerSmaller(input));
            Console.WriteLine(findMaxDigit(input));
            Console.WriteLine(ConfigHowManDivByThree(input));
            Console.WriteLine(ConfigAvgDigits(input));

            // exit:
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        // return average of digits (string).
        public static string ConfigAvgDigits(string i_NumStrToFingAvg)
        {
                int len = i_NumStrToFingAvg.Length;
                int sumOfDigit = 0;

                for (int i = 0; i < len; i++)
                {
                    sumOfDigit += stringToDigit(i_NumStrToFingAvg, i);
                }

                double avgDigit = sumOfDigit / (double)len;
                return string.Format("The average of digits is {0}", avgDigit);
        }

        // get how many digits are divisible by 3 (string).
        public static string ConfigHowManDivByThree(string i_inputStr)
        {
            int counterDivisibleByThree = 0;
            for (int i = 0; i < i_inputStr.Length; i++)
            {
                int numInIndex = stringToDigit(i_inputStr, i);
                bool v_isDiviByThree = Ex01_01.Program.DivisibleByThree(numInIndex);
                if (v_isDiviByThree)
                {
                    counterDivisibleByThree++;
                }
            }

            StringBuilder strResultReturn = new StringBuilder("In the number there are no digit divisible by 3");

            if (0 != counterDivisibleByThree)
            {
                strResultReturn.Replace("no", counterDivisibleByThree.ToString());
            }

            return strResultReturn.ToString();
        }

        // return max digit (string)
        private static string findMaxDigit(string i_StringToFindMax)
        {
            int maxDigit = 0;
            for (int i = 0; i < i_StringToFindMax.Length; i++)
            {
                int digitInIndex = stringToDigit(i_StringToFindMax, i);
                bool v_isMaxSmaller = maxDigit < digitInIndex;
                if (v_isMaxSmaller)
                {
                    maxDigit = digitInIndex;
                }
            }

            string strResultReturn = string.Format("The max digit is {0}", maxDigit);

            return strResultReturn;
        }

        // returns how many digits smaller than the ones digit (string).
        public static string ConfigDigitsSmallerSmaller(string i_InputNum)
        {
            // get the last digit
            int len = i_InputNum.Length;
            int unitNum = stringToDigit(i_InputNum, len - 1);

            string subStringToCheck = i_InputNum.Substring(0, len - 1);
            int numOfSmallerThanUnity = configDigitsSmallerThanUnity(subStringToCheck, unitNum);

            StringBuilder strResultReturn = new StringBuilder("There are no digits that are smaller than the unity digit");
            if (0 != numOfSmallerThanUnity)
            {
                strResultReturn.Replace("no", numOfSmallerThanUnity.ToString());
            }

            return strResultReturn.ToString();
        }

        // convert string at index to digit.
        // throws index-out-of-bounds exception
        private static int stringToDigit(string i_inputNum, int i_index)
        {
            char lastDigit = i_inputNum[i_index];
            int.TryParse(lastDigit.ToString(), out int result);

            return result;
        }

        // returns number of digits smaller than unitNum.
        private static int configDigitsSmallerThanUnity(string i_InputNum, int i_unitNum)
        {
            int counterSmallerThanUnity = 0;

            for (int i = 0; i < i_InputNum.Length; i++)
            {
                int numInIndex = stringToDigit(i_InputNum, i);
                bool isUnitNumBigger = i_unitNum > numInIndex;
                if (isUnitNumBigger)
                {
                    counterSmallerThanUnity++;
                }
            }

            return counterSmallerThanUnity;
        }
    }
}