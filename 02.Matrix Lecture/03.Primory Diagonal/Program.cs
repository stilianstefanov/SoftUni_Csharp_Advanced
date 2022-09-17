using System;
using System.Linq;

namespace _03.Primory_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] squareMatrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                int[] currRowInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    squareMatrix[row, col] = currRowInfo[col];
                }
            }

            int sum = 0;

            for (int rowCol = 0; rowCol < squareMatrix.GetLength(0); rowCol++)
            {
                sum += squareMatrix[rowCol, rowCol];
            }

            Console.WriteLine(sum);
        }
    }
}
