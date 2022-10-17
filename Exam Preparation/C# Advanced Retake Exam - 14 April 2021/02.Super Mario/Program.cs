using System;

namespace _02._Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rowCount = int.Parse(Console.ReadLine());

            int playerRow = 0;
            int playerCol = 0;

            char[] curRow = Console.ReadLine().ToCharArray();
            char[,] matrix = new char[rowCount, curRow.Length];

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < curRow.Length; col++)
                {
                    if (curRow[col] == 'M')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    matrix[row, col] = curRow[col];
                }
                if (row != rowCount - 1)
                {
                    curRow = Console.ReadLine().ToCharArray();
                }
            }

            bool hasWon = false;
            while (lives > 0)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                string direction = tokens[0];
                int spawnRow = int.Parse(tokens[1]);
                int spawnCol = int.Parse(tokens[2]);
                matrix[spawnRow, spawnCol] = 'B';

                switch (direction)
                {
                    case "W":
                        if (isValid(newPlayerRow - 1, newPlayerCol, matrix, ref lives))
                        {
                            newPlayerRow--;
                            MovePlayer(newPlayerRow, newPlayerCol, matrix, ref lives, ref hasWon);
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                    case "S":
                        if (isValid(newPlayerRow + 1, newPlayerCol, matrix, ref lives))
                        {
                            newPlayerRow++;
                            MovePlayer(newPlayerRow, newPlayerCol, matrix, ref lives, ref hasWon);
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                    case "A":
                        if (isValid(newPlayerRow, newPlayerCol - 1, matrix, ref lives))
                        {
                            newPlayerCol--;
                            MovePlayer(newPlayerRow, newPlayerCol, matrix, ref lives, ref hasWon);
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                    case "D":
                        if (isValid(newPlayerRow, newPlayerCol + 1, matrix, ref lives))
                        {
                            newPlayerCol++;
                            MovePlayer(newPlayerRow, newPlayerCol, matrix, ref lives, ref hasWon);
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                }                
                if (hasWon)
                {
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    PrintMatrix(matrix);

                    return;
                }
                if (lives <= 0)
                {
                    matrix[newPlayerRow, newPlayerCol] = 'X';
                    Console.WriteLine($"Mario died at {newPlayerRow};{newPlayerCol}.");
                    PrintMatrix(matrix);

                    return;
                }

                playerRow = newPlayerRow;
                playerCol = newPlayerCol;
            }
            
        }

        private static void MovePlayer(int newPlayerRow, int newPlayerCol, char[,] matrix, ref int lives, ref bool hasWon)
        {
            if (matrix[newPlayerRow, newPlayerCol] == 'B')
            {
                lives -= 2;
                if (lives <= 0)
                {
                    matrix[newPlayerRow, newPlayerCol] = 'X';                    
                }
                else
                {
                    matrix[newPlayerRow, newPlayerCol] = 'M';
                }
            }
            else if (matrix[newPlayerRow, newPlayerCol] == 'P')
            {
                hasWon = true;
                matrix[newPlayerRow, newPlayerCol] = '-';
            }
            else
            {
                matrix[newPlayerRow, newPlayerCol] = 'M';
            }
        }

        private static bool isValid(int newPlayerRow, int newPlayerCol, char[,] matrix, ref int lives)
        {
            lives--;
            if (newPlayerRow >= 0 && newPlayerRow < matrix.GetLength(0)
                && newPlayerCol >= 0 && newPlayerCol < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
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
    }
}
