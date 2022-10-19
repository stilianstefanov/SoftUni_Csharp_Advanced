using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rowCount = dimensions[0];
            int colCount = dimensions[1];
            int[,] matrix = new int[rowCount, colCount];

            List<int[]> commands = new List<int[]>();
            string coordinatesInfo;
            while ((coordinatesInfo = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = coordinatesInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int currentRow = coordinates[0];
                int currentCol = coordinates[1];
                if (!isValid(currentRow, currentCol, matrix))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                commands.Add(new int[] { currentRow, currentCol });
            }

            for (int i = 0; i < commands.Count; i++)
            {
                int currentRow = commands[i][0];
                int currentCol = commands[i][1];

                BloomFlowers(currentRow, currentCol, matrix);
            }
            PrintMatrix(matrix);
        }

        private static void BloomFlowers(int currentRow, int currentCol, int[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[currentRow, col]++;
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row == currentRow)
                {
                    continue;
                }
                matrix[row, currentCol]++;
            }
        }

        private static bool isValid(int currentRow, int currentCol, int[,] matrix)
        {
            return currentRow >= 0 && currentRow < matrix.GetLength(0)
                && currentCol >= 0 && currentCol < matrix.GetLength(1);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
