using System;
using System.Linq;

namespace _01.ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] create = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            ListyIterator<string> listyIterator = new ListyIterator<string>(create);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        listyIterator.Print();
                        break;                        
                }
            }
        }
    }
}
