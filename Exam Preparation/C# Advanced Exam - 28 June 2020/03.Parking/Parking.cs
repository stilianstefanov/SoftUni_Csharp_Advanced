using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.data = new List<Car>();
            Type = type;
            Capacity = capacity;
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            if (!data.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                return false;
            }
            data.Remove(data.Find(c => c.Manufacturer == manufacturer && c.Model == model));

            return true;
        }
        public Car GetLatestCar()
        {
            if (data.Count == 0)
            {
                return null;
            }
            return data.OrderByDescending(c => c.Year).First();
        }        
        public Car GetCar(string manufacturer, string model)
        {
            return data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in data)
            {
                sb.AppendLine($"{car.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
