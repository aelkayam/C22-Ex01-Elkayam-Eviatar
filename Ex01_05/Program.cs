using System;

namespace Ex01_05
{
    internal class Program
    {
        public static void Main()
        {
            //Receiving input from the user:
            const int k_requiredLength = 9;
            string msg = " Please enter an integer between 9 digits";
            string input = Ex01_01.Program.UserInput(Ex01_01.Program.eInputType.LettersAndNumbers, k_requiredLength, msg);
            //Performing and printing functions:
            Console.WriteLine(ConfigDigitsSmallerSmaller(input));
            Console.WriteLine(FindMaxDigit(input));
            Console.WriteLine(ConfigHowManDivByThree(input));
            //finish: 
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
        public static string ConfigHowManDivByThree(string i_inputStr)
        {
            int counterDivisibleByThree = 0;
            for (int i = 0; i < i_inputStr.Length; i++)
            {
                int numInIndex = stringToInt(i_inputStr, i);
                bool v_isDiviByThree = Ex01_01.Program.DivisibleByThree(numInIndex);
                if (v_isDiviByThree)
                {
                    counterDivisibleByThree++;
                }
            }
            string strResultReturn;
            if (counterDivisibleByThree == 0)
            {// The construction of the sring needs to be changed part b .2 
                strResultReturn = "In the number, there is no digit divided by 3";
            }
            else
            {
                strResultReturn = string.Format("In the number, there is {0} digit divided by 3", counterDivisibleByThree);
            }

            return strResultReturn;
        }

        public static string FindMaxDigit(string i_inputStr)
        {
            int MaxDigit=findMaxDigit(i_inputStr, 0);
            string strResultReturn = string.Format(" the max digit is {0}", MaxDigit);
            return strResultReturn;

        }
        private static int findMaxDigit(string i_strToFindmac, int MaxDigit)
        {
            MaxDigit = 0;
            for (int i = 0; i < i_strToFindmac.Length; i++)
            {
                int digitInIndex = stringToInt(i_strToFindmac, i);
                bool v_isMaxSmaller = MaxDigit < digitInIndex;
                if (v_isMaxSmaller)
                {
                    MaxDigit=digitInIndex;
                }
            }

            return MaxDigit;
        }


        public static string ConfigDigitsSmallerSmaller(string i_InputNum)
        {
            int len = i_InputNum.Length;
            int unitNum = stringToInt(i_InputNum, len - 1);
            string subStringToChak = i_InputNum.Substring(0, len-1);
            int numOfSmallerSmaller =configDigitsSmallerThanUnity(subStringToChak, unitNum);
            string strResultReturn;
            bool v_isAnySmallerSmaller = numOfSmallerSmaller == 0;
            if (v_isAnySmallerSmaller)
            {// The construction of the sring needs to be changed part b .2 
                strResultReturn = "There are no numbers that are smaller than the unity digit";
            }
            else
            {
                strResultReturn = string.Format("There are {0} numbers that are smaller than the unity digit", numOfSmallerSmaller);
            }

            return strResultReturn;
        }
        private static int stringToInt(string i_inputNum, int i_index )
        {
            int result ;
            char lestDigit = i_inputNum[i_index];
            Int32.TryParse(lestDigit.ToString(), out result);

            return result;
        }

        private static int configDigitsSmallerThanUnity(string i_InputNum, int i_unitNum)
        {
            int counterSmallerThanUnity = 0;
            for(int i= 0; i< i_InputNum.Length;i++)
            {
                int numInIndex = stringToInt(i_InputNum, i);
                bool v_isUnitNumBigger = i_unitNum > numInIndex;
                if (v_isUnitNumBigger)
                {
                    counterSmallerThanUnity++;
                }
            }

            return counterSmallerThanUnity; 
        }
    }
}