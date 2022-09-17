using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
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
                int[] firstRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = firstRow[col];
                }
            }

            
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
