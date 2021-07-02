using System;
using System.Collections.Generic;
using System.IO;

namespace Problem18
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../Problem18.txt"))
            {
                List<List<int>> list = new List<List<int>>();
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    List<int> row = new List<int>();
                    string[] arr = line.Split(' ');
                    foreach(string num in arr)
                    {
                        row.Add(int.Parse(num));
                    }
                    list.Add(row);
                }

                for(int i = 1; i < list.Count; i++)
                {
                    for(int j = 0; j < list[i].Count; j++)
                    {
                        int max;
                        if(j == 0)
                        {
                            max = list[i][j] + list[i - 1][j];
                        }
                        else if(j == list[i].Count - 1)
                        {
                            max = list[i][j] + list[i - 1][j - 1];
                        }
                        else
                        {
                            max = list[i][j] + Math.Max(list[i - 1][j], list[i - 1][j - 1]);
                        }
                        list[i][j] = max;
                    }
                }
            }
        }
    }
}
