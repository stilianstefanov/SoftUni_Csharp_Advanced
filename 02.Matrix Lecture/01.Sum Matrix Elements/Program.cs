using System;
using System.Linq;

namespace _01.Sum_Matrix_Elements
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
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
