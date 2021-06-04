using System;
using System.Collections.Generic;
using System.IO;

namespace Problem11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[20, 20];
            int max = int.MinValue;
            string line = null;
            using (StreamReader reader = new StreamReader("Numbers.txt"))
            {
                int i = 0;
                while ((line = reader.ReadLine()) != null) {
                    string[] strNums = line.Split(" ");
                    for(int j = 0; j < strNums.Length; j++)
                    {
                        arr[i,j] = int.Parse(strNums[j]);
                    }
                    i++;
                }
            }

            for(int i = 0; i < 17; i++)
            {
                int a, b, c, d;
                for(int j = 0; j < 17; j++)
                {
                    a = arr[i, j];
                    b = arr[i, j + 1];
                    c = arr[i, j + 2];
                    d = arr[i, j + 3];

                    int hProd = a * b * c * d;

                    b = arr[i + 1, j];
                    c = arr[i + 2, j];
                    d = arr[i + 3, j];

                    int vProd = a * b * c * d;

                    int lDiag = int.MinValue;

                    if(j >= 3)
                    {
                        b = arr[i + 1, j - 1];
                        c = arr[i + 2, j - 2];
                        d = arr[i + 3, j - 3];
                        lDiag = a * b * c * d;
                    }

                    b = arr[i + 1, j + 1];
                    c = arr[i + 2, j + 2];
                    d = arr[i + 3, j + 3];

                    int rDiag = a * b * c * d;

                    max = Math.Max(max, Math.Max(Math.Max(rDiag, lDiag), Math.Max(hProd, vProd)));
                }
            }
            Console.WriteLine(max);
        }
    }
}
