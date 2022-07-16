using System;

namespace Ex01_02
{
    internal class Program
    {
        public static void Main()
        {
            int diamondHeight = 9;
            printBasicStarDiamond(diamondHeight);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        // print a diamond using asterisks with the given height.
        private static void printBasicStarDiamond(int i_Height)
        {
            printBasicStarDiamond(i_Height, i_Height, 0);
        }

        // recursively print a triangle.
        private static void printBasicStarDiamond(int i_Height, int i_Width, int i_Spaces)
        {
            if(i_Width == 1)
            {
                for(int j = 0; j < i_Height / 2; j++)
                {
                    Console.Write(' ');
                }

                Console.WriteLine('*');
            }
            else
            {
                for (int j = 0; j < i_Spaces; j++)
                {
                    Console.Write(' ');
                }

                for (int k = 0; k < i_Width; k++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
                printBasicStarDiamond(i_Height, i_Width - 2, i_Spaces + 1);
                for (int j = 0; j < i_Spaces; j++)
                {
                    Console.Write(' ');
                }

                for (int k = 0; k < i_Width; k++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
            }
        }
    }
}
