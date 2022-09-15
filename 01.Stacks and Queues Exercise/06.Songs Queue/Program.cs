using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var initialSongs = Console.ReadLine()
                .Split(", ");

            var songsQueue = new Queue<string>();

            foreach (var s in initialSongs)
            {
                songsQueue.Enqueue(s);
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (songsQueue.Count > 0)
                {
                    switch (command[0])
                    {
                        case "Play":
                            songsQueue.Dequeue();
                            break;
                        case "Add":
                            AddSong(songsQueue, command);
                            break;
                        case "Show":
                            Console.WriteLine(string.Join(", ", songsQueue));
                            break;
                    }
                    if (songsQueue.Count == 0)
                    {
                        Console.WriteLine("No more songs!");
                        return;
                    }
                }
            }
        }

        private static void AddSong(Queue<string> songsQueue, string[] command)
        {
            List<string> song = command.ToList();
            song.RemoveAt(0);
            string songToAdd = string.Join(" ", song);

            bool isContained = false;

            for (int i = 0; i < songsQueue.Count; i++)
            {
                string currSongToCheck = songsQueue.Dequeue();

                if (currSongToCheck == songToAdd)
                {
                    isContained = true;
                }
                songsQueue.Enqueue(currSongToCheck);
            }

            if (!isContained)
            {
                songsQueue.Enqueue(songToAdd);
            }
            else
            {
                Console.WriteLine($"{songToAdd} is already contained!");
            }
        }
    }
}
