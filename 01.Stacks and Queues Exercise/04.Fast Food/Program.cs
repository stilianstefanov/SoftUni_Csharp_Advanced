using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04.Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialFood = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var ordersQueue = new Queue<int>();

            foreach (var item in orders)
            {
                ordersQueue.Enqueue(item);
            }

            FindMaxOrder(ordersQueue);

            while (ordersQueue.Count > 0)
            {
                int currOrderValue = ordersQueue.Peek();

                if (currOrderValue <= initialFood)
                {
                    initialFood -= currOrderValue;
                    ordersQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }

        private static void FindMaxOrder(Queue<int> ordersQueue)
        {
            int maxOrder = int.MinValue;
            int ordersCount = ordersQueue.Count;

            for (int i = 0; i < ordersCount; i++)
            {
                int currOrder = ordersQueue.Dequeue();
                if (currOrder > maxOrder)
                {
                    maxOrder = currOrder;
                }
                ordersQueue.Enqueue(currOrder);
            }
            Console.WriteLine(maxOrder);
        }
    }
}
