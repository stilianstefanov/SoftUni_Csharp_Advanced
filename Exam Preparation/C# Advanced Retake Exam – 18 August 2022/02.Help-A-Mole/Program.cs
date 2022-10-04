using System;

namespace _02._Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;

            int firstSpecialRow = -1;
            int firstSpecialCol = -1;

            int secondSpecialRow = -1;
            int secondSpecialCol = -1;

            for (int row = 0; row < size; row++)
            {
                char[] curRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    if (curRow[col] == 'M')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (curRow[col] == 'S' && firstSpecialCol != -1)
                    {
                        secondSpecialRow = row;
                        secondSpecialCol = col;
                    }
                    else if (curRow[col] == 'S' && firstSpecialCol == -1)
                    {
                        firstSpecialRow = row;
                        firstSpecialCol = col;
                    }
                    matrix[row, col] = curRow[col];
                }
            }
            int totalPoints = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (totalPoints >= 25)
                {
                    break;
                }

                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;               

                switch (command)
                {
                    case "up":
                        
                        if (IsValidMove(newPlayerRow - 1, playerCol, matrix))
                        {
                            newPlayerRow--;
                            matrix[playerRow, playerCol] = '-';
                            if (char.IsDigit(matrix[newPlayerRow, playerCol]))
                            {
                                int curPoints = int.Parse(matrix[newPlayerRow, playerCol].ToString());
                                totalPoints += curPoints;
                            }
                            else if (matrix[newPlayerRow, playerCol] == 'S')
                            {
                                if (newPlayerRow == firstSpecialRow && playerCol == firstSpecialCol)
                                {
                                    newPlayerRow = secondSpecialRow;
                                    newPlayerCol = secondSpecialCol;
                                    matrix[firstSpecialRow, firstSpecialCol] = '-';
                                }
                                else
                                {
                                    newPlayerRow = firstSpecialRow;
                                    newPlayerCol = firstSpecialCol;
                                    matrix[secondSpecialRow, secondSpecialCol] = '-';
                                }
                                totalPoints -= 3;
                            }
                        }
                        break;
                    case "down":

                        if (IsValidMove(newPlayerRow + 1, playerCol, matrix))
                        {
                            newPlayerRow++;
                            matrix[playerRow, playerCol] = '-';
                            if (char.IsDigit(matrix[newPlayerRow, playerCol]))
                            {
                                int curPoints = int.Parse(matrix[newPlayerRow, playerCol].ToString());
                                totalPoints += curPoints;
                            }
                            else if (matrix[newPlayerRow, playerCol] == 'S')
                            {
                                if (newPlayerRow == firstSpecialRow && playerCol == firstSpecialCol)
                                {
                                    newPlayerRow = secondSpecialRow;
                                    newPlayerCol = secondSpecialCol;
                                    matrix[firstSpecialRow, firstSpecialCol] = '-';
                                }
                                else
                                {
                                    newPlayerRow = firstSpecialRow;
                                    newPlayerCol = firstSpecialCol;
                                    matrix[secondSpecialRow, secondSpecialCol] = '-';
                                }
                                totalPoints -= 3;
                            }
                        }
                        break;
                    case "left":

                        if (IsValidMove(playerRow , newPlayerCol - 1, matrix))
                        {
                            newPlayerCol--;
                            matrix[playerRow, playerCol] = '-';
                            if (char.IsDigit(matrix[playerRow, newPlayerCol]))
                            {
                                int curPoints = int.Parse(matrix[playerRow, newPlayerCol].ToString());
                                totalPoints += curPoints;
                            }
                            else if (matrix[playerRow, newPlayerCol] == 'S')
                            {
                                if (playerRow == firstSpecialRow && newPlayerCol == firstSpecialCol)
                                {
                                    newPlayerRow = secondSpecialRow;
                                    newPlayerCol = secondSpecialCol;
                                    matrix[firstSpecialRow, firstSpecialCol] = '-';
                                }
                                else
                                {
                                    newPlayerRow = firstSpecialRow;
                                    newPlayerCol = firstSpecialCol;
                                    matrix[secondSpecialRow, secondSpecialCol] = '-';
                                }
                                totalPoints -= 3;
                            }
                        }
                        break;
                    case "right":

                        if (IsValidMove(newPlayerRow, playerCol + 1, matrix))
                        {
                            newPlayerCol++;
                            matrix[playerRow, playerCol] = '-';
                            if (char.IsDigit(matrix[playerRow, newPlayerCol]))
                            {
                                int curPoints = int.Parse(matrix[playerRow, newPlayerCol].ToString());
                                totalPoints += curPoints;
                            }
                            else if (matrix[playerRow, newPlayerCol] == 'S')
                            {
                                if (playerRow == firstSpecialRow && newPlayerCol == firstSpecialCol)
                                {
                                    newPlayerRow = secondSpecialRow;
                                    newPlayerCol = secondSpecialCol;
                                    matrix[firstSpecialRow, firstSpecialCol] = '-';
                                }
                                else
                                {
                                    newPlayerRow = firstSpecialRow;
                                    newPlayerCol = firstSpecialCol;
                                    matrix[secondSpecialRow, secondSpecialCol] = '-';
                                }
                                totalPoints -= 3;
                            }
                        }
                        break;
                }
                playerRow = newPlayerRow;
                playerCol = newPlayerCol;
                matrix[playerRow, playerCol] = 'M';
            }

            if (totalPoints >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {totalPoints} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {totalPoints} points.");
            }
            PrintMatrix(matrix);

        }

        private static bool IsValidMove(int playerRow, int playerCol, char[,] matrix)
        {
            if (playerRow >= 0 && playerRow < matrix.GetLength(0)
                && playerCol >= 0 && playerCol < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Don't try to escape the playing field!");
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
