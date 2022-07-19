using System;
using Ex01_01;

namespace Ex01_04
{
    internal class Program
    {
        public static void Main()
        {
            const int k_requiredLength = 9;
            string mag = " 9 char  /n Either they are all letters (uppercase or lowercase) /n or they are all numbers";
            string input = Ex01_01.Program.UserInput(Ex01_01.Program.eInputType.LettersAndNumbers, k_requiredLength, mag);
            int inputNum;
            bool v_isDigit = Int32.TryParse(input, out inputNum);
            if (v_isDigit)
            {
                Console.WriteLine(isDivisibleByThree(inputNum));
            }
            else 
            {
                Console.WriteLine(CalculateHowManyLowercase(input));
            }
            Console.WriteLine(IsPlinthrumStrToPtint(input));
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        private static string isDivisibleByThree(int i_inputNum)
        {
            string strResultReturn; 
            bool v_isDivisibleByThree = Ex01_01.Program.DivisibleByThree(i_inputNum);
            if (v_isDivisibleByThree)
            {
                strResultReturn = "The number does divide by 3";
            }
            else
            {
                strResultReturn = "The number number is not divisible by 3";
            }

            return strResultReturn;
        }
        public static string CalculateHowManyLowercase(string i_strOfUpperAndLowercase)
        {
            int counterLowercase=0;
            counterLowercase=calculateHowManyLowercase(i_strOfUpperAndLowercase, counterLowercase);
            string numOfCounterLowercaseOrNot; 
            if (counterLowercase==0)
            {
                numOfCounterLowercaseOrNot = "not"; 
            }
            else
            {
                numOfCounterLowercaseOrNot = counterLowercase.ToString();
            }
            string strResultReturn = string.Format("in the string {0} There are {1} lowercase letters", i_strOfUpperAndLowercase, numOfCounterLowercaseOrNot);

            return strResultReturn;
        }

        private static int calculateHowManyLowercase(string i_strOfUpperAndLowercase, int i_counterLowercase) 
        {
            i_counterLowercase = 0;
            for(int i = 0; i < i_strOfUpperAndLowercase.Length; i++)
            {
                bool v_isLowercase =Char.IsLower(i_strOfUpperAndLowercase,i);
                if (v_isLowercase)
                {
                    i_counterLowercase++;
                }
            }

            return i_counterLowercase;
        }
        public static string IsPlinthrumStrToPtint(string i_inputStr)
        {
            bool v_isPlinthrum = Ex01_01.Program.isPalindrome(i_inputStr);
            string strResultReturn; 
            if (v_isPlinthrum)
            {// The construction of the sring needs to be changed part b .2 
                strResultReturn = "the sting is Plinthrum ";
            }
            else
            {
                strResultReturn = "the sting is not Plinthrum ";
            }

            return strResultReturn;
        }
    }
}