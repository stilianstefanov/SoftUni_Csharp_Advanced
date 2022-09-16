using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] locks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int reward = int.Parse(Console.ReadLine());

            var bulletStack = new Stack<int>(bullets);
            var locksQueue = new Queue<int>(locks);

            int bulletsShooted = 0;

            while (bulletStack.Any() && locksQueue.Any())
            {
                ShootAtLock(bulletStack, locksQueue, ref bulletsShooted);

                if (bulletsShooted % barrelSize == 0 && bulletStack.Any())
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locksQueue.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                int moneyEarned = reward - bulletsShooted * bulletPrice;
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${moneyEarned}");
            }
        }

        private static void ShootAtLock(Stack<int> bulletStack, Queue<int> locksQueue, ref int bulletsShooted)
        {
            int currBullet = bulletStack.Pop();
            int currLock = locksQueue.Peek();

            if (currBullet <= currLock)
            {
                Console.WriteLine("Bang!");
                locksQueue.Dequeue();
            }
            else
            {
                Console.WriteLine("Ping!");
            }

            bulletsShooted++;
        }
    }
}
