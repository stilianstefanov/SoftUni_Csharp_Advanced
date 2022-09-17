using System;
using System.Linq;

namespace _05.Square_with_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] matrixInfo = Console.ReadLine().Split(", ");
            int rows = int.Parse(matrixInfo[0]);
            int cols = int.Parse(matrixInfo[1]);

            int[,] matrix = new int[rows, cols];


            for (int row = 0; row < rows; row++)
            {
                int[] firstRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = firstRow[col];
                }
            }

            int subMatrixRows = 2;
            int subMatrixCols = 2;

            int biggestSum = 0;
            int biggestSquareStartRow = -1;
            int biggestSquareStartCol = -1;

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

            for (int row = biggestSquareStartRow; row < biggestSquareStartRow + subMatrixRows; row++)
            {
                for (int col = biggestSquareStartCol; col < biggestSquareStartCol + subMatrixCols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(biggestSum);
        }
    }
}
