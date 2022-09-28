using System;
using System.Linq;

namespace _04.Add_VAT
{
    internal class Program
    {
        static Func<decimal, string> addVAT = x => (x * 1.2M).ToString("F2");
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(Environment.NewLine, 
                Console.ReadLine()
                .Split(", " ,StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(x => addVAT(x))
                ));
        }
    }
}
