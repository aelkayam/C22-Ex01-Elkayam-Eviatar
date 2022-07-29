using System;
using System.Text;
using ref_Ex01_01 = Ex01_01.Program;

namespace Ex01_05
{
        internal class Program
    {
        public static void Main()
        {
            // Receiving input from the user:
            const int k_RequiredLength = 9;
            string message = string.Format("an integer with {0} digits", k_RequiredLength);
            string input = ref_Ex01_01.GetUserInput(ref_Ex01_01.eInputType.integer, k_RequiredLength, message);

            // Performing and printing functions:
            Console.WriteLine(ConfigDigitsSmallerThanLast(input));
            Console.WriteLine(findMaxDigit(input));
            Console.WriteLine(ConfigHowManDivByThree(input));
            Console.WriteLine(ConfigAvgDigits(input));

            // exit:
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        public static string ConfigAvgDigits(string i_NumStrToFingAvg)
        {
            int len = i_NumStrToFingAvg.Length;
            int sumOfDigit = 0;

            for (int i = 0; i < len; i++)
            {
                sumOfDigit += stringToDigit(i_NumStrToFingAvg, i);
            }

            float avgDigit = sumOfDigit / (float)len;

            return string.Format("The average digit is {0:0.##}", avgDigit);
        }

        // get how many digits are divisible by 3.
        public static string ConfigHowManDivByThree(string i_inputStr)
        {
            int counterDivisibleByThree = 0;

            for (int i = 0; i < i_inputStr.Length; i++)
            {
                int numInIndex = stringToDigit(i_inputStr, i);
                bool v_isDiviByThree = ref_Ex01_01.DivisibleByThree(numInIndex);

                if (v_isDiviByThree)
                {
                    counterDivisibleByThree++;
                }
            }

            StringBuilder strResultReturn = new StringBuilder("In the number there are no digit divisible by 3");

            if (counterDivisibleByThree != 0)
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
        public static string ConfigDigitsSmallerThanLast(string i_InputNum)
        {
            // get the last digit
            int len = i_InputNum.Length;
            int onesDigit = stringToDigit(i_InputNum, len - 1);
            string subStringToCheck = i_InputNum.Substring(0, len - 1);
            int numOfSmallerThanOnes = configDigitsSmallerThanOnes(subStringToCheck, onesDigit);
            StringBuilder strResultReturn = new StringBuilder("There are no digits that are smaller than the ones digit");

            if (numOfSmallerThanOnes != 0)
            {
                strResultReturn.Replace("no", numOfSmallerThanOnes.ToString());
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

        // returns number of digits smaller than ones digit.
        private static int configDigitsSmallerThanOnes(string i_InputNum, int i_OnesDigit)
        {
            int counterSmallerThanOnes = 0;

            for (int i = 0; i < i_InputNum.Length; i++)
            {
                int numInIndex = stringToDigit(i_InputNum, i);
                bool isOnesNumBigger = i_OnesDigit > numInIndex;

                if (isOnesNumBigger)
                {
                    counterSmallerThanOnes++;
                }
            }

            return counterSmallerThanOnes;
        }
    }
}