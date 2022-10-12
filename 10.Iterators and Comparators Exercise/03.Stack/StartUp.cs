using System;
using System.Linq;

namespace _03.Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> myStack = new Stack<int>();

            string tokens;
            while ((tokens = Console.ReadLine()) != "END")
            {
                if (tokens.Contains("Push"))
                {
                    string[] entries = tokens.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    entries = entries.Skip(1).ToArray();
                    int[] elements = entries.Select(int.Parse).ToArray();

                    myStack.Push(elements);
                }
                else
                {
                    myStack.Pop();
                }
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
