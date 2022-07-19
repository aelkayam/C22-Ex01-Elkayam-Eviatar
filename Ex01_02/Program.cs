using System;
using System.Text;

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

        // print a diamond using stars with the given height.
        public static void PrintBasicStarDiamond(int i_Height)
        {
            StringBuilder io_UpperPart = new StringBuilder();
            StringBuilder io_LowerPart = new StringBuilder();

            if (i_Height > 0)
            {
                buildUpperPartTriangle(i_Height / 2, i_Height, 0, ref io_UpperPart);
                buildLowerPartTriangle(i_Height - 2, 1, i_Height / 2, ref io_LowerPart);
            }
            else
            {
                Console.WriteLine("height must be above 0");
            }

            Console.Write(io_UpperPart.ToString());
            Console.Write(io_LowerPart.ToString());
        }

        // recursively print the upper triangle.
        private static void buildUpperPartTriangle(int i_Height, int i_Stars, int i_Spaces, ref StringBuilder io_TopTriangle)
        {
            // top of the triangle:
            if(i_Stars == 1)
            {
                io_TopTriangle.Append(' ', i_Height);
                io_TopTriangle.Append('*');
                io_TopTriangle.AppendLine();
            }

            // rest of the triangle:
            else
            {
                buildUpperPartTriangle(i_Height, i_Stars - 2, i_Spaces + 1, ref io_TopTriangle);
                io_TopTriangle.Append(' ', i_Spaces);
                io_TopTriangle.Append('*', i_Stars);
                io_TopTriangle.AppendLine();
            }
        }

        // recursively print the lower triangle.
        private static void buildLowerPartTriangle(int i_Height, int i_Stars, int i_Spaces, ref StringBuilder i_BottomTriangle)
        {
            // in case of a 1 star diamond:
            if (i_Height < 1)
            {
                return;
            }

            // top of the triangle:
            if (i_Stars == i_Height)
            {
                i_BottomTriangle.Append(' ');
                i_BottomTriangle.Append('*', i_Height);
                i_BottomTriangle.AppendLine();
            }
            else
            {
                // rest of the triangle:
                buildLowerPartTriangle(i_Height, i_Stars + 2, i_Spaces - 1, ref i_BottomTriangle);
                i_BottomTriangle.Append(' ', i_Spaces);
                i_BottomTriangle.Append('*', i_Stars);
                i_BottomTriangle.AppendLine();
             }
        }
    }
}
