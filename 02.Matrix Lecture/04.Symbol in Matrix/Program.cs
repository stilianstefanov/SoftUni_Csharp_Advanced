using System;

namespace _04.Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowColSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rowColSize, rowColSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInfo = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInfo[col];
                }
            }

            char symbolToFind = char.Parse(Console.ReadLine());

            int rowPositon = -1;
            int colPositon = -1;
            bool isFound = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == symbolToFind)
                    {
                        rowPositon = row;
                        colPositon = col;
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }

            if (isFound)
            {
                Console.WriteLine($"({rowPositon}, {colPositon})");
            }
            else
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
        }
    }
}
