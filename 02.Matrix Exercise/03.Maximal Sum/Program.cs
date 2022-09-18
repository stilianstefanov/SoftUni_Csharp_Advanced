using System;
using System.Linq;

namespace _05.Square_with_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] matrixInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(matrixInfo[0]);
            int cols = int.Parse(matrixInfo[1]);

            int[,] matrix = new int[rows, cols];

            if (rows < 3 || cols < 3)
            {
                Console.WriteLine($"Sum = {0}");
                return;
            }
            for (int row = 0; row < rows; row++)
            {
                int[] firstRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries ).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = firstRow[col];
                }
            }

            int subMatrixRows = 3;
            int subMatrixCols = 3;

            int biggestSum = 0;
            int biggestSquareStartRow = 0;
            int biggestSquareStartCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - subMatrixRows + 1; row++)
            {

                for (int col = 0; col < matrix.GetLength(1) - subMatrixCols + 1; col++)
                {
                    int currSubMatrixSum = 0;

                    for (int subrow = row; subrow < row + subMatrixRows; subrow++)
                    {
                        for (int subcol = col; subcol < col + subMatrixCols; subcol++)
                        {
                            currSubMatrixSum += matrix[subrow, subcol];
                        }
                    }

                    if (currSubMatrixSum > biggestSum)
                    {
                        biggestSum = currSubMatrixSum;
                        biggestSquareStartRow = row;
                        biggestSquareStartCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {biggestSum}");
            for (int row = biggestSquareStartRow; row < biggestSquareStartRow + subMatrixRows; row++)
            {
                for (int col = biggestSquareStartCol; col < biggestSquareStartCol + subMatrixCols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }           
        }
    }
}