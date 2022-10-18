using System;

namespace _02.Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;

            int firstPillarRow = -1;
            int firstPillarCol = -1;

            int secondPillarRow = -1;
            int secondPillarCol = -1;

            for (int row = 0; row < size; row++)
            {
                char[] curRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    if (curRow[col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    if (curRow[col] == 'O' && firstPillarRow == -1)
                    {
                        firstPillarRow = row;
                        firstPillarCol = col;
                    }
                    if (curRow[col] == 'O' && firstPillarRow != -1)
                    {
                        secondPillarRow = row;
                        secondPillarCol = col;
                    }
                    matrix[row, col] = curRow[col];
                }
            }

            int moneyEarned = 0;
            while (true)
            {
                string command = Console.ReadLine();
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (command)
                {
                    case "up":
                        if (isValid(newPlayerRow - 1, newPlayerCol, matrix))
                        {
                            newPlayerRow--;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref moneyEarned, firstPillarRow, firstPillarCol, secondPillarRow, secondPillarCol);
                            matrix[playerRow, playerCol] = '-';
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            Console.WriteLine("Bad news, you are out of the bakery.");
                            Console.WriteLine($"Money: {moneyEarned}");
                            PrintMatrix(matrix);
                            return;
                        }
                        break;
                    case "down":
                        if (isValid(newPlayerRow + 1, newPlayerCol, matrix))
                        {
                            newPlayerRow++;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref moneyEarned, firstPillarRow, firstPillarCol, secondPillarRow, secondPillarCol);
                            matrix[playerRow, playerCol] = '-';
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            Console.WriteLine("Bad news, you are out of the bakery.");
                            Console.WriteLine($"Money: {moneyEarned}");
                            PrintMatrix(matrix);
                            return;
                        }
                        break;
                    case "left":
                        if (isValid(newPlayerRow, newPlayerCol - 1, matrix))
                        {
                            newPlayerCol--;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref moneyEarned, firstPillarRow, firstPillarCol, secondPillarRow, secondPillarCol);
                            matrix[playerRow, playerCol] = '-';
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            Console.WriteLine("Bad news, you are out of the bakery.");
                            Console.WriteLine($"Money: {moneyEarned}");
                            PrintMatrix(matrix);
                            return;
                        }
                        break;
                    case "right":
                        if (isValid(newPlayerRow, newPlayerCol + 1, matrix))
                        {
                            newPlayerCol++;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref moneyEarned, firstPillarRow, firstPillarCol, secondPillarRow, secondPillarCol);
                            matrix[playerRow, playerCol] = '-';
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            Console.WriteLine("Bad news, you are out of the bakery.");
                            Console.WriteLine($"Money: {moneyEarned}");
                            PrintMatrix(matrix);
                            return;
                        }
                        break;
                }

                if (moneyEarned >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    Console.WriteLine($"Money: {moneyEarned}");
                    PrintMatrix(matrix);
                    return;
                }
                playerRow = newPlayerRow;
                playerCol = newPlayerCol;
            }
        }

        private static void MovePlayer(ref int newPlayerRow, ref int newPlayerCol, char[,] matrix, ref int moneyEarned, int firstPillarRow, int firstPillarCol, int secondPillarRow, int secondPillarCol)
        {
            if (char.IsDigit(matrix[newPlayerRow, newPlayerCol]))
            {
                moneyEarned += int.Parse(matrix[newPlayerRow, newPlayerCol].ToString());
                matrix[newPlayerRow, newPlayerCol] = 'S';
            }
            else if (matrix[newPlayerRow, newPlayerCol] == 'O')
            {
                matrix[newPlayerRow, newPlayerCol] = '-';

                if (newPlayerRow == firstPillarRow && newPlayerCol == firstPillarCol)
                {
                    newPlayerRow = secondPillarRow;
                    newPlayerCol = secondPillarCol;
                    matrix[newPlayerRow, newPlayerCol] = 'S';
                }
                else
                {
                    newPlayerRow = firstPillarRow;
                    newPlayerCol = firstPillarCol;
                    matrix[newPlayerRow, newPlayerCol] = 'S';
                }
            }
        }

        private static bool isValid(int newPlayerRow, int newPlayerCol, char[,] matrix)
        {
            if (newPlayerRow >= 0 && newPlayerRow < matrix.GetLength(0)
                && newPlayerCol >= 0 && newPlayerCol < matrix.GetLength(1))
            {
                return true;
            }            
            return false;
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
