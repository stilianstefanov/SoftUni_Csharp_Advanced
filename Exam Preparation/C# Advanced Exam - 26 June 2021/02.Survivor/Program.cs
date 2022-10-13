using System;
using System.Linq;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCnt = int.Parse(Console.ReadLine());

            char[][] jaggedArr = new char[rowsCnt][];

            for (int row = 0; row < rowsCnt; row++)
            {
                char[] curRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                jaggedArr[row] = curRow;
            }

            int collectedTokens = 0;
            int opponentTokens = 0;

            string command;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case "Find":
                        {
                            int row = int.Parse(tokens[1]);
                            int col = int.Parse(tokens[2]);
                            if (row >= 0 && row < rowsCnt && col >= 0 && col < jaggedArr[row].Length)
                            {
                                if (jaggedArr[row][col] == 'T')
                                {
                                    collectedTokens++;
                                    jaggedArr[row][col] = '-';
                                }
                            }
                            break;
                        }
                    case "Opponent":
                        {
                            int row = int.Parse(tokens[1]);
                            int col = int.Parse(tokens[2]);
                            string direction = tokens[3];
                            if (row >= 0 && row < rowsCnt && col >= 0 && col < jaggedArr[row].Length)
                            {
                                if (jaggedArr[row][col] == 'T')
                                {
                                    opponentTokens++;
                                    jaggedArr[row][col] = '-';
                                }
                                MoveOpponent(jaggedArr, row, col, direction, ref opponentTokens);
                            }

                            break;
                        }
                }
            }
            Print(jaggedArr);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static void MoveOpponent(char[][] jaggedArr, int startRow, int startCol, string direction, ref int opponentTokens)
        {
            switch (direction)
            {
                case "up":
                    {
                        int counter = 0;
                        for (int row = startRow; row >= 0; row--)
                        {
                            if (counter == 4)
                            {
                                break;
                            }
                            if (jaggedArr[row][startCol] == 'T')
                            {
                                opponentTokens++;
                            }
                            jaggedArr[row][startCol] = '-';
                            counter++;
                        }
                        break;
                    }
                case "down":
                    {
                        int counter = 0;
                        for (int row = startRow; row < jaggedArr.Length; row++)
                        {
                            if (counter == 4)
                            {
                                break;
                            }
                            if (jaggedArr[row][startCol] == 'T')
                            {
                                opponentTokens++;
                            }
                            jaggedArr[row][startCol] = '-';
                            counter++;
                        }
                        break;
                    }
                case "left":
                    {
                        int counter = 0;
                        for (int col = startCol; col >= 0; col--)
                        {
                            if (counter == 4)
                            {
                                break;
                            }
                            if (jaggedArr[startRow][col] == 'T')
                            {
                                opponentTokens++;
                            }
                            jaggedArr[startRow][col] = '-';
                            counter++;
                        }
                        break;
                    }
                case "right":
                    {
                        int counter = 0;
                        for (int col = startCol; col < jaggedArr[startRow].Length; col++)
                        {
                            if (counter == 4)
                            {
                                break;
                            }
                            if (jaggedArr[startRow][col] == 'T')
                            {
                                opponentTokens++;
                            }
                            jaggedArr[startRow][col] = '-';
                            counter++;
                        }
                        break;
                    }
            }
        }

        private static void Print(char[][] jaggedArr)
        {
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                char[] currentRow = jaggedArr[row];
                Console.WriteLine(String.Join(" ", currentRow));
            }
        }
    }
}
