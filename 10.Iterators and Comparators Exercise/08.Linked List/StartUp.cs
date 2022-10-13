using System;

namespace _07.Implementing_LinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList<int> linkedList = new CustomDoublyLinkedList<int>();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            linkedList.AddFirst(0);
            linkedList.AddFirst(-1);
            linkedList.AddFirst(-2);

            int firstValue = linkedList.RemoveFirst();
            int lastValue = linkedList.RemoveLast();

            linkedList.ForEach(x => Console.WriteLine(x));

            int[] testArr = linkedList.ToArray();

            Console.WriteLine(string.Join(" ", testArr));

            foreach (var item in testArr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
