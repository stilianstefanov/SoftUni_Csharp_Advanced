using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Fish = new List<Fish>();
            Material = material;
            Capacity = capacity;
        }

        public List<Fish> Fish { get; set; }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Fish.Count; } }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            else if (this.Count >= this.Capacity)
            {
                return "Fishing net is full.";
            }
            else
            {
                this.Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }
        public bool ReleaseFish(double weight)
        {
            if (this.Fish.Any(f => f.Weight == weight))
            {
                this.Fish.Remove(this.Fish.Find(f => f.Weight == weight));
                return true;
            }
            else
            {
                return false;
            }
        }
        public Fish GetFish(string fishType)
        {
            var fish = this.Fish.FirstOrDefault(x => x.FishType == fishType);

            return fish;
        }
        public Fish GetBiggestFish()
        {
            return this.Fish.OrderByDescending(f => f.Length).First();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var fish in Fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine($"{fish.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
