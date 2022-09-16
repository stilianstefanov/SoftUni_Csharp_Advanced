using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            int carsPassed = 0;
            Queue<string> carQueue = new Queue<string>();
            while (command != "END")
            {                              
                if(command == "green" && carQueue.Count > 0)
                {
                    string curCarName = carQueue.Dequeue();                    
                    Queue<char> currCarToPass = new Queue<char>(curCarName);

                    for (int i = 0; i < greenDuration; i++)
                    {
                        if (currCarToPass.Count > 0)
                        {
                            currCarToPass.Dequeue();
                            if (currCarToPass.Count == 0)
                            {
                                carsPassed++;
                            }
                        }
                        else
                        {
                            if (carQueue.Count > 0)
                            {
                                curCarName = carQueue.Dequeue();
                                foreach (var ch in curCarName)
                                {
                                    currCarToPass.Enqueue(ch);
                                }
                                currCarToPass.Dequeue();
                            }
                        }
                    }
                    for (int i = 0; i < freeWindow; i++)
                    {
                        if (currCarToPass.Count > 0)
                        {
                            currCarToPass.Dequeue();
                            if (currCarToPass.Count == 0)
                            {
                                carsPassed++;
                            }
                        }
                    }
                                        
                    if (currCarToPass.Count > 0)
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{curCarName} was hit at {currCarToPass.Peek()}.");
                        return;
                    }
                }
                else
                {
                    carQueue.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
