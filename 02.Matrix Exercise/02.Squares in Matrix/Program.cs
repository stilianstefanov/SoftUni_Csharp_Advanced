using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = matrixInfo[0];
            int colsCount = matrixInfo[1];

            char[,] matrix = new char[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                char[] curRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = curRow[col];
                }
            }

            int squaresCount = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    Stack<char> currSquare = new Stack<char>();
                    for (int subMatrixRow = row; subMatrixRow < row + 2; subMatrixRow++)
                    {
                        for (int subMatrixCol = col; subMatrixCol < col + 2; subMatrixCol++)
                        {
                            currSquare.Push(matrix[subMatrixRow, subMatrixCol]);
                        }
                    }
                    if (isEqualSquare(currSquare))
                    {
                        squaresCount++;
                    }
                }
            }
            Console.WriteLine(squaresCount);
        }

        private static bool isEqualSquare(Stack<char> currSquare)
        {
            if (currSquare.Count > 0)
            {
                bool isValid = true;
                char lastChar = currSquare.Pop();

                while (currSquare.Count > 0)
                {
                    if (currSquare.Peek() != lastChar)
                    {
                        isValid = false;
                        break;
                    }
                    else
                    {
                        currSquare.Pop();
                    }
                }
                return isValid;
            }
            else
            {
                return false;
            }
        }
    }
}
