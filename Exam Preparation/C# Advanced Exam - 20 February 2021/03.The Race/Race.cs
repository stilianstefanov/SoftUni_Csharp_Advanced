using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            this.data = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.data.Count; } }

        public void Add(Racer Racer)
        {
            if (this.data.Count >= Capacity)
            {
                return;
            }
            this.data.Add(Racer);
        }
        public bool Remove(string name)
        {
            if (!this.data.Any(r => r.Name == name))
            {
                return false;
            }
            this.data.Remove(this.data.Find(r => r.Name == name));
            return true;
        }
        public Racer GetOldestRacer()
        {
            return this.data.OrderByDescending(r => r.Age).First();
        }
        public Racer GetRacer(string name)
        {
            return this.data.FirstOrDefault(r => r.Name == name);
        }
        public Racer GetFastestRacer()
        {
            return this.data.OrderByDescending(r => r.Car.Speed).First();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var item in this.data)
            {
                sb.AppendLine($"{item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
