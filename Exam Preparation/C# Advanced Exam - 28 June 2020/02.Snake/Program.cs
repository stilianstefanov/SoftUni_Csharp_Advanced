using System;

namespace _02.Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;

            int firstBurrowRow = -1;
            int firstBurrowCol = -1;

            int secondBurrowRow = -1;
            int secondBurrowCol = -1;

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
                    if (curRow[col] == 'B' && firstBurrowRow == -1)
                    {
                        firstBurrowRow = row;
                        firstBurrowCol = col;
                    }
                    if (curRow[col] == 'B' && firstBurrowRow != -1)
                    {
                        secondBurrowRow = row;
                        secondBurrowCol = col;
                    }

                    matrix[row, col] = curRow[col];
                }
            }

            int foodEaten = 0;
            bool hasGoneOut = false;
            while (true)
            {
                string command = Console.ReadLine();
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (command)
                {
                    case "up":
                        if (isValid(newPlayerRow - 1, newPlayerCol, matrix, ref hasGoneOut))
                        {
                            newPlayerRow--;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref foodEaten, firstBurrowRow, firstBurrowCol, secondBurrowRow, secondBurrowCol);
                            matrix[playerRow, playerCol] = '.';
                        }
                        break;
                    case "down":
                        if (isValid(newPlayerRow + 1, newPlayerCol, matrix, ref hasGoneOut))
                        {
                            newPlayerRow++;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref foodEaten, firstBurrowRow, firstBurrowCol, secondBurrowRow, secondBurrowCol);
                            matrix[playerRow, playerCol] = '.';
                        }
                        break;
                    case "left":
                        if (isValid(newPlayerRow, newPlayerCol - 1, matrix, ref hasGoneOut))
                        {
                            newPlayerCol--;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref foodEaten, firstBurrowRow, firstBurrowCol, secondBurrowRow, secondBurrowCol);
                            matrix[playerRow, playerCol] = '.';
                        }
                        break;
                    case "right":
                        if (isValid(newPlayerRow, newPlayerCol + 1, matrix, ref hasGoneOut))
                        {
                            newPlayerCol++;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref foodEaten, firstBurrowRow, firstBurrowCol, secondBurrowRow, secondBurrowCol);
                            matrix[playerRow, playerCol] = '.';
                        }
                        break;
                }
               
                if (hasGoneOut)
                {
                    matrix[playerRow, playerCol] = '.';
                    Console.WriteLine("Game over!");
                    break;
                }
                if (foodEaten >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }
                playerRow = newPlayerRow;
                playerCol = newPlayerCol;
            }
            Console.WriteLine($"Food eaten: {foodEaten}");
            PrintMatrix(matrix);

        }

        private static void MovePlayer(ref int newPlayerRow, ref int newPlayerCol, char[,] matrix, ref int foodEaten, int firstBurrowRow, int firstBurrowCol, int secondBurrowRow, int secondBurrowCol)
        {
            if (matrix[newPlayerRow, newPlayerCol] == '*')
            {
                foodEaten++;
                matrix[newPlayerRow, newPlayerCol] = 'S';
            }
            else if (matrix[newPlayerRow, newPlayerCol] == 'B')
            {
                matrix[newPlayerRow, newPlayerCol] = '.';
                if (newPlayerRow == firstBurrowRow && newPlayerCol == firstBurrowCol)
                {
                    newPlayerRow = secondBurrowRow;
                    newPlayerCol = secondBurrowCol;
                }
                else
                {
                    newPlayerRow = firstBurrowRow;
                    newPlayerCol = firstBurrowCol;
                }
                matrix[newPlayerRow, newPlayerCol] = 'S';
            }
            else
            {
                matrix[newPlayerRow, newPlayerCol] = 'S';
            }
        }

        private static bool isValid(int newPlayerRow, int newPlayerCol, char[,] matrix, ref bool hasGoneOut)
        {
            if (newPlayerRow >= 0 && newPlayerRow < matrix.GetLength(0)
                && newPlayerCol >= 0 && newPlayerCol < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                hasGoneOut = true;

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
