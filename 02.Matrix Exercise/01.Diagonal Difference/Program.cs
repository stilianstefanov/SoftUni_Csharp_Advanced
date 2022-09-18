using System;
using System.Linq;

namespace _01.Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowColSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rowColSize, rowColSize];

            for (int curRow = 0; curRow < rowColSize; curRow++)
            {
                int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < rowColSize; col++)
                {
                    matrix[col, curRow] = rowData[col];
                }
            }

            int primoryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int rowCol = 0; rowCol < rowColSize; rowCol++)
            {
                primoryDiagonal += matrix[rowCol, rowCol];
            }

            int row = 0;
            for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            {
                secondaryDiagonal += matrix[col, row];
                row++;
            }

            Console.WriteLine(Math.Abs(primoryDiagonal - secondaryDiagonal));
        }
    }
}
