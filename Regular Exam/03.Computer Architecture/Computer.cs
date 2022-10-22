using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Multiprocessor = new List<CPU>();
            Model = model;
            Capacity = capacity;
        }

        public List<CPU> Multiprocessor { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count >= Capacity)
            {
                return;
            }
            Multiprocessor.Add(cpu);
        }

        public bool Remove(string brand)
        {
            if (!Multiprocessor.Any(p => p.Brand == brand))
            {
                return false;
            }
            Multiprocessor.Remove(Multiprocessor.Find(p => p.Brand == brand));

            return true;
        }

        public CPU MostPowerful()
        {
            if (Multiprocessor.Count == 0)
            {
                return null;
            }

            return Multiprocessor.OrderByDescending(p => p.Frequency).First();
        }

        public CPU GetCPU(string brand)
        {
            return Multiprocessor.FirstOrDefault(p => p.Brand == brand);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var cpu in Multiprocessor)
            {
                sb.AppendLine($"{cpu.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
