using System;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            int diamondHeight = 9;
            PrintBasicStarDiamond(diamondHeight);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        // print a diamond using asterisks with the given height.
        public static void PrintBasicStarDiamond(int i_Height)
        {
            if (i_Height > 0)
            {
                printUpperTriangle(i_Height / 2, i_Height, 0);
                printLowerTriangle(i_Height - 2, 1, i_Height / 2);
            }
            else
            {
                Console.WriteLine("height must be above 0");
            }
        }

        // recursively print a triangle.
        private static void printUpperTriangle(int i_Height, int i_Stars, int i_Spaces)
        {
            // top of the triangle:
            if(i_Stars == 1)
            {
                for(int j = 0; j < i_Height; j++)
                {
                    Console.Write(' ');
                }

                Console.WriteLine('*');
            }

            // rest of the triangle:
            else
            {
                printUpperTriangle(i_Height, i_Stars - 2, i_Spaces + 1);
                for (int j = 0; j < i_Spaces; j++)
                {
                    Console.Write(' ');
                }

                for (int k = 0; k < i_Stars; k++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
            }
        }

        // recursively print an upside down triangle.
        private static void printLowerTriangle(int i_Height, int i_Stars, int i_Spaces)
        {
            if (i_Height < 1)
            {
                return;
            }

            // top of the triangle:
            if (i_Stars == i_Height)
            {
                Console.Write(' ');
                for (int j = 0; j < i_Height; j++)
                {
                    Console.Write('*');
                }

                Console.WriteLine(' ');
            }
            else
            {
                // rest of the triangle:
                printLowerTriangle(i_Height, i_Stars + 2, i_Spaces - 1);
                for (int j = 0; j < i_Spaces; j++)
                {
                    Console.Write(' ');
                }

                for (int k = 0; k < i_Stars; k++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
            }
        }
    }
}
