using System;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[matrixInfo[0], matrixInfo[1]];
            
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string curRow = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = curRow[col];
                    if (curRow[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string moves = Console.ReadLine();

            foreach (var move in moves)
            {
                bool hasPlayerWon = false;
                bool hasPlayerLost = false;

                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (move)
                {
                    case 'U':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerRow--;
                        MovePlayer(newPlayerRow, playerCol, matrix, ref hasPlayerWon, ref hasPlayerLost);
                        break;
                    case 'D':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerRow++;
                        MovePlayer(newPlayerRow, playerCol, matrix, ref hasPlayerWon, ref hasPlayerLost);                        
                        break;
                    case 'L':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerCol--;
                        MovePlayer(playerRow, newPlayerCol, matrix, ref hasPlayerWon, ref hasPlayerLost);
                        break;
                    case 'R':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerCol++;
                        MovePlayer(playerRow, newPlayerCol, matrix, ref hasPlayerWon, ref hasPlayerLost);
                        break;
                }

                matrix = SpreadBunnies(matrix, ref hasPlayerLost);

                

                if (hasPlayerWon)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }

                playerRow = newPlayerRow;
                playerCol = newPlayerCol;

                if (hasPlayerLost)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
            }          
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] SpreadBunnies(char[,] matrix, ref bool hasPlayerLost )
        {
            char[,] newMatrix = CopyMatrix(matrix);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (isCellValid(row + 1, col, matrix))
                        {
                            if (matrix[row + 1, col] == 'P')
                            {
                                hasPlayerLost = true;
                            }
                            newMatrix[row + 1, col] = 'B';
                        }
                        if (isCellValid(row - 1, col, matrix))
                        {
                            if (matrix[row - 1, col]== 'P')
                            {
                                hasPlayerLost = true;
                            }
                            newMatrix[row - 1, col] = 'B';
                        }
                        if (isCellValid(row, col + 1, matrix))
                        {
                            if (matrix[row, col + 1] == 'P')
                            {
                                hasPlayerLost = true;
                            }
                            newMatrix[row, col + 1] = 'B';
                        }
                        if (isCellValid(row, col - 1, matrix))
                        {
                            if (matrix[row, col - 1] == 'P')
                            {
                                hasPlayerLost = true;
                            }
                            newMatrix[row, col - 1] = 'B';
                        }
                        
                    }
                }
            }
            return newMatrix;
        }

        private static char[,] CopyMatrix(char[,] matrix)
        {
            char[,] copy = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    copy[row, col] = matrix[row, col];
                }
            }

            return copy;
        }

        private static void MovePlayer(int playerRow, int playerCol, char[,] matrix, ref bool hasPlayerWon, ref bool hasPlayerLost)
        {
            if (isCellValid(playerRow, playerCol, matrix))
            {
                if (matrix[playerRow, playerCol] == 'B')
                {
                    hasPlayerLost = true;
                }
                else
                {
                    matrix[playerRow, playerCol] = 'P';
                }
            }
            else
            {
                hasPlayerWon = true;
            }
        }

        private static bool isCellValid(int playerRow, int playerCol, char[,] matrix)
        {
            return playerRow >= 0
                && playerRow < matrix.GetLength(0)
                && playerCol >= 0
                && playerCol < matrix.GetLength(1);
        }
    }
}
