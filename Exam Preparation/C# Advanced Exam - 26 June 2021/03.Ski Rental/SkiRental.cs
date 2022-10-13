using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public SkiRental(string name, int capacity)
        {
            Data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public List<Ski> Data
        {
            get { return data; }
            set { data = value; }
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Data.Count; } }

        public void Add(Ski ski)
        {
            if (this.Data.Count < this.Capacity)
            {
                this.Data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            if (this.Data.Any(s => s.Manufacturer == manufacturer && s.Model == model))
            {
                this.Data.Remove(this.Data.Find(s => s.Manufacturer == manufacturer && s.Model == model));

                return true;
            }
            else
            {
                return false;
            }
        }
        public Ski GetNewestSki()
        {
            if (this.Data.Count == 0)
            {
                return null;
            }
            else
            {
                return this.Data.OrderByDescending(s => s.Year).First();
            }
        }
        public Ski GetSki(string manufacturer, string model)
        {
            return this.Data.FirstOrDefault(s => s.Model == model && s.Manufacturer == manufacturer);
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (var item in this.Data)
            {
                sb.AppendLine($"{item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
