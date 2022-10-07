using System;

namespace _02.Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;

            int firstMirrorRow = -1;
            int firstMirrorCol = -1;

            int secondMirrorRow = -1;
            int secondMirrorCol = -1;

            for (int row = 0; row < size; row++)
            {
                char[] curRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    if (curRow[col] == 'A')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (curRow[col] == 'M' && firstMirrorRow != -1)
                    {
                        secondMirrorRow = row;
                        secondMirrorCol = col;
                    }
                    else if (curRow[col] == 'M' && firstMirrorCol == -1)
                    {
                        firstMirrorRow = row;
                        firstMirrorCol = col;
                    }
                    matrix[row, col] = curRow[col];
                }
            }

            int goldSpent = 0;
            bool hasGoneOut = false;
            while (goldSpent < 65 && hasGoneOut == false)
            {
                string command = Console.ReadLine();

                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (command)
                {
                    case "up":
                        if (isValidMove(newPlayerRow - 1, newPlayerCol, size, ref hasGoneOut))
                        {
                            newPlayerRow--;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref goldSpent, firstMirrorRow, firstMirrorCol, secondMirrorRow, secondMirrorCol);
                            matrix[playerRow, playerCol] = '-';
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                    case "down":
                        if (isValidMove(newPlayerRow + 1, newPlayerCol, size, ref hasGoneOut))
                        {
                            newPlayerRow++;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref goldSpent, firstMirrorRow, firstMirrorCol, secondMirrorRow, secondMirrorCol);
                            matrix[playerRow, playerCol] = '-';
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                    case "left":
                        if (isValidMove(newPlayerRow, newPlayerCol - 1, size, ref hasGoneOut))
                        {
                            newPlayerCol--;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref goldSpent, firstMirrorRow, firstMirrorCol, secondMirrorRow, secondMirrorCol);
                            matrix[playerRow, playerCol] = '-';
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                    case "right":
                        if (isValidMove(newPlayerRow, newPlayerCol + 1, size, ref hasGoneOut))
                        {
                            newPlayerCol++;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref goldSpent, firstMirrorRow, firstMirrorCol, secondMirrorRow, secondMirrorCol);
                            matrix[playerRow, playerCol] = '-';
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                }

                playerRow = newPlayerRow;
                playerCol = newPlayerCol;              
            }

            if (hasGoneOut)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {goldSpent} gold coins.");
            PrintMatrix(matrix);
        }

        private static void MovePlayer(ref int newPlayerRow, ref int newPlayerCol, char[,] matrix, ref int goldSpent, int firstMirrorRow, int firstMirrorCol, int secondMirrorRow, int secondMirrorCol)
        {
            if (char.IsDigit(matrix[newPlayerRow, newPlayerCol]))
            {
                goldSpent += int.Parse(matrix[newPlayerRow, newPlayerCol].ToString());
                matrix[newPlayerRow, newPlayerCol] = 'A';
            }
            else if (matrix[newPlayerRow, newPlayerCol] == 'M')
            {
                matrix[newPlayerRow, newPlayerCol] = '-';

                if (newPlayerRow == firstMirrorRow && newPlayerCol == firstMirrorCol)
                {                    
                    newPlayerRow = secondMirrorRow;
                    newPlayerCol = secondMirrorCol;                    
                }
                else
                {
                    newPlayerRow = firstMirrorRow;
                    newPlayerCol = firstMirrorCol;
                }
                matrix[newPlayerRow, newPlayerCol] = 'A';
            }
            else
            {
                matrix[newPlayerRow, newPlayerCol] = 'A';
            }
        }

        private static bool isValidMove(int newPlayerRow, int newPlayerCol, int size, ref bool hasGoneOut)
        {
            if (newPlayerRow >= 0 && newPlayerRow < size
                && newPlayerCol >= 0 && newPlayerCol < size)
            {
                return true;
            }
            else
            {
                hasGoneOut = true;

                return false;
            }
        }

        public static void PrintMatrix(char[,] matrix)
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
