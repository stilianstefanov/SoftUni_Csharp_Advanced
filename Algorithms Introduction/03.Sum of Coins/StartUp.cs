namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] coins = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int targetSum = int.Parse(Console.ReadLine());

            var selectedCoins = ChooseCoins(coins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");

            foreach (var item in selectedCoins)
            {
                Console.WriteLine($"{item.Value} coin(s) with value {item.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            int[] sortedCoins = coins.OrderByDescending(c => c).ToArray();

            int index = 0;
            int currentSum = 0;
            while (index < sortedCoins.Length && currentSum != targetSum)
            {
                if (currentSum + sortedCoins[index] <= targetSum)
                {
                    currentSum += sortedCoins[index];
                    if (!result.ContainsKey(sortedCoins[index]))
                    {
                        result.Add(sortedCoins[index], 0);
                    }
                    result[sortedCoins[index]]++;
                }
                else
                {
                    index++;
                }
            }

            if (currentSum != targetSum)
            {
                throw new InvalidOperationException();
            }

            return result;
        }
    }
}