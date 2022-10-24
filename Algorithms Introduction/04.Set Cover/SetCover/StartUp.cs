namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] universe = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int numberOfSets = int.Parse(Console.ReadLine());

            int[][] sets = new int[numberOfSets][];
            for (int row = 0; row < numberOfSets; row++)
            {
                int[] curSet = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
                sets[row] = curSet;
            }

            List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> result = new List<int[]>();

            while (universe.Count > 0)
            {
                int[] largestSet = sets.OrderByDescending(s => s.Count(c => universe.Contains(c))).FirstOrDefault();
                result.Add(largestSet);

                universe = universe.Where(d => !largestSet.Contains(d)).ToList();

                sets.Remove(largestSet);
            }
            
            return result;
        }
    }
}
