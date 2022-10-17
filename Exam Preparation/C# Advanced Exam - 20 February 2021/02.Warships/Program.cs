using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] coordinatesToAtack = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[size, size];
            int firstPlayerShipsCount = 0;
            int secondPlayerShipsCount = 0;

            for (int row = 0; row < size; row++)
            {
                char[] curRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    if (curRow[col] == '<')
                    {
                        firstPlayerShipsCount++;
                    }
                    if (curRow[col] == '>')
                    {
                        secondPlayerShipsCount++;
                    }
                    matrix[row, col] = curRow[col];
                }
            }
            
            for (int i = 0; i < coordinatesToAtack.Length; i++)
            {
                int[] curCoordinates = coordinatesToAtack[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int curRow = curCoordinates[0];
                int curCol = curCoordinates[1];

                if (!isValid(curRow, curCol, matrix))
                {
                    continue;
                }

                char curSymbol = matrix[curRow, curCol];
                switch (curSymbol)
                {
                    case '>':
                        secondPlayerShipsCount--;
                        matrix[curRow, curCol] = 'X';
                        break;
                    case '<':
                        firstPlayerShipsCount--;
                        matrix[curRow, curCol] = 'X';
                        break;
                    case '#':
                        for (int row = curRow - 1; row <= curRow + 1; row++)
                        {
                            for (int col = curCol - 1; col <= curCol + 1; col++)
                            {
                                if (!isValid(row, col, matrix))
                                {
                                    continue;
                                }
                                if (matrix[row, col] == '>')
                                {
                                    secondPlayerShipsCount--;
                                    matrix[row, col] = 'X';
                                }
                                else if (matrix[row, col] == '<')
                                {
                                    firstPlayerShipsCount--;
                                    matrix[row, col] = 'X';
                                }
                            }
                        }
                        break;
                }


                if (firstPlayerShipsCount <= 0)
                {
                    int totalShipsDestroyed = GetDestroyedShips(matrix);
                    Console.WriteLine($"Player Two has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
                    return;
                }
                else if (secondPlayerShipsCount <= 0)
                {
                    int totalShipsDestroyed = GetDestroyedShips(matrix);
                    Console.WriteLine($"Player One has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
                    return;
                }
            }
            Console.WriteLine($"It's a draw! Player One has {firstPlayerShipsCount} ships left. Player Two has {secondPlayerShipsCount} ships left.");
        }

        private static int GetDestroyedShips(char[,] matrix)
        {
            int count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'X')
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static bool isValid(int curRow, int curCol, char[,] matrix)
        {
            if (curRow >= 0 && curRow < matrix.GetLength(0)
                && curCol >= 0 && curCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

     
    }
}
