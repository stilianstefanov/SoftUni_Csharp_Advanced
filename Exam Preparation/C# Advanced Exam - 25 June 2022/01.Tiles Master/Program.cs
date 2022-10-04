using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTilesInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] grayTilesInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> whiteTiles = new Stack<int>();
            Queue<int> grayTiles = new Queue<int>();

            for (int i = 0; i < whiteTilesInfo.Length; i++)
            {
                whiteTiles.Push(whiteTilesInfo[i]);
            }
            for (int i = 0; i < grayTilesInfo.Length; i++)
            {
                grayTiles.Enqueue(grayTilesInfo[i]);
            }

            Dictionary<int, string> tilesReq = new Dictionary<int, string>();
            tilesReq.Add(40, "Sink");
            tilesReq.Add(50, "Oven");
            tilesReq.Add(60, "Countertop");
            tilesReq.Add(70, "Wall");

            Dictionary<string, int> tilesDone = new Dictionary<string, int>();

            while (whiteTiles.Any() && grayTiles.Any())
            {
                int curWhiteTile = whiteTiles.Peek();
                int curGrayTile = grayTiles.Peek();

                if (curWhiteTile == curGrayTile)
                {
                    int newTileSum = curWhiteTile + curGrayTile;
                    if (tilesReq.ContainsKey(newTileSum))
                    {
                        string curNewTile = tilesReq[newTileSum];
                        if (!tilesDone.Any(t => t.Key == curNewTile))
                        {
                            tilesDone.Add(curNewTile, 0);
                        }
                        tilesDone[curNewTile]++;
                    }
                    else
                    {
                        if (!tilesDone.Any(t => t.Key == "Floor"))
                        {
                            tilesDone.Add("Floor", 0);
                        }
                        tilesDone["Floor"]++;
                    }
                    whiteTiles.Pop();
                    grayTiles.Dequeue();
                }
                else
                {
                    whiteTiles.Push(whiteTiles.Pop() / 2);
                    grayTiles.Enqueue(grayTiles.Dequeue());                    
                }
            }

            if (!whiteTiles.Any())
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            if (!grayTiles.Any())
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grayTiles)}");
            }

            foreach (var tile in tilesDone.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine($"{tile.Key}: {tile.Value}");
            }
        }
    }
}
