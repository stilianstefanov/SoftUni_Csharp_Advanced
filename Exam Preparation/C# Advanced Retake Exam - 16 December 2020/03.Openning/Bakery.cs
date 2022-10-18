using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.data = new List<Employee>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            if (!data.Any(e => e.Name == name))
            {
                return false;
            }
            data.Remove(data.Find(e => e.Name == name));
            return true;
        }
        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(e => e.Age).First();
        }
        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(e => e.Name == name);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var item in data)
            {
                sb.AppendLine($"{item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
