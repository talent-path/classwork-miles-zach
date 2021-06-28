using System;

namespace Problem28
{
    class Program
    {
        static void Main(string[] args)
        {

            //int dim = 1001;

            //int n = (dim - 1) / 2;

            //long diagSum = (3 + 2 * n * (8 * n * n + 15 * n + 13)) / 3;

            long sum = 1;

            for(int i = 3; i <= 1001; i+=2)
            {
                int topRightCorner = i * i;
                int topLeftCorner = topRightCorner - (i - 1);
                int bottomLeftCorner = topLeftCorner - (i - 1);
                int bottomRightCorner = bottomLeftCorner - (i - 1);
                sum += topRightCorner + topLeftCorner + bottomLeftCorner + bottomRightCorner;
            }

            Console.WriteLine(sum);
        }
    }
}
