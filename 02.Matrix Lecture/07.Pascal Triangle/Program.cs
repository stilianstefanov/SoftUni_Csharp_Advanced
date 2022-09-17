using System;

namespace _07.Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pascalRows = int.Parse(Console.ReadLine());

            long[][] pascal = new long[pascalRows][];
            int currCols = 1;

            for (int row = 0; row < pascalRows; row++)
            {
                pascal[row] = new long[currCols];
                long[] currRow = pascal[row];
                pascal[row][0] = 1;
                pascal[row][currRow.Length - 1] = 1;

                currCols++;
            }

            for (int row = 1; row < pascalRows; row++)
            {
                for (int col = 1; col < pascal[row].Length - 1; col++)
                {
                    long currSum = pascal[row - 1][col] + pascal[row - 1][col - 1];
                    pascal[row][col] = currSum;
                }
            }

            foreach (var item in pascal)
            {
                Console.WriteLine(String.Join(" ", item));
            }
        }
    }
}
