using System;

namespace Ex01_03
{
    internal class Program
    {
        public static void Main()
        {
            int diamondHeight = userInput();
            Ex01_02.Program.PrintBasicStarDiamond(diamondHeight);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        // get valid user input.
        private static int userInput()
        {
            bool v_isValid;
            int userInputInt;

            do
            {
                Console.WriteLine("Please enter the height for the diamond:");
                string userInputString = Console.ReadLine();
                v_isValid = authenticate(userInputString, out userInputInt);
                if (!v_isValid)
                {
                    Console.WriteLine("Invalid input! please try again.");
                }
            }
            while (!v_isValid);

            return userInputInt;
        }

        // validation user input.
        private static bool authenticate(string userInputString, out int userInputInt)
        {
            bool v_isNumber = int.TryParse(userInputString, out userInputInt);
            // case of odd height:
            if (v_isNumber && IsEven(userInputInt))
            {
                Console.WriteLine("Adding height to make it odd");
                userInputInt++;
            }

            return v_isNumber;
        }

        // return true if even
        public static bool IsEven(int num)
        {
            return num % 2 == 0;
        }
    }
}
