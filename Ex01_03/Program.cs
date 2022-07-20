using System;

namespace Ex01_03
{
    internal class Program
    {
        public static void Main()
        {
            // user input:
            int diamondHeight = getUserInputForDiamondHeight();
            Ex01_02.Program.PrintBasicStarDiamond(diamondHeight);

            // exit:
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        // get valid user input.
        private static int getUserInputForDiamondHeight()
        {
            bool isValid;
            int userInputInt;
            do
            {
                Console.WriteLine("Please enter the height for the diamond:");
                string userInputString = Console.ReadLine();
                isValid = authenticate(userInputString, out userInputInt);
                if (!isValid)
                {
                    Console.WriteLine("Invalid input! please try again.");
                }
            }
            while (!isValid);

            return userInputInt;
        }

        // validate user input.
        private static bool authenticate(string userInputString, out int userInputInt)
        {
            bool isNumber = int.TryParse(userInputString, out userInputInt);

            // case of odd height:
            if (isNumber && isEven(userInputInt))
            {
                    Console.WriteLine("Adding height to make it odd");
                    userInputInt++;
            }

            return isNumber;
        }

        // return true if even.
        private static bool isEven(int num)
        {
            return num % 2 == 0;
        }
    }
}
