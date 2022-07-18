using System;
using Ex01_01;
namespace Ex01_05
{
    internal class Program
    {
        public static void Main()
        {
            // user input:
            string message = "a 9-digits Integer";
            string userInput = Ex01_01.Program.UserInput(eInputType.integer, 9, message);
            int userInputInt = int.Parse(userInput);

            // count how many digits smaller than the ones digit:
            int controlDigit = userInputInt % 10;
            int numOfLesserThanControlDigit = getNumOfLesserDigits(userInputInt, controlDigit);

            // check which is the biggest digit:
            int greatestDigit = getGreatestDigitInNum(userInputInt);

            // how many digits are divisible by 3:
            int numOfDigitsDivByThree = getNumOfDigitsDivByThree(userInputInt);

            // calculate average of digits:
            float avgDigit = getAvgDigit(userInputInt);

            // output:
        }

        private static float getAvgDigit(int userInputInt)
        {
            throw new NotImplementedException();
        }

        private static int getNumOfDigitsDivByThree(int userInputInt)
        {
            throw new NotImplementedException();
        }

        private static int getGreatestDigitInNum(int userInputInt)
        {
            throw new NotImplementedException();
        }

        private static int getNumOfLesserDigits(int userInputInt, int controlDigit)
        {
            throw new NotImplementedException();
        }
    }
}
