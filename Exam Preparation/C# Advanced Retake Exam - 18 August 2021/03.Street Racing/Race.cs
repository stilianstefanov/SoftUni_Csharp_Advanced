using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Participants = new List<Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count { get { return this.Participants.Count; } }

        public void Add(Car car)
        {
            if (this.Participants.Any(c => c.LicensePlate == car.LicensePlate))
            {
                return;
            }
            else if (this.Count >= this.Capacity)
            {
                return;
            }
            else if (car.HorsePower > MaxHorsePower)
            {
                return;
            }
            else
            {
                this.Participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            if (this.Participants.Any(c => c.LicensePlate == licensePlate))
            {
                this.Participants.Remove(Participants.Find(c => c.LicensePlate == licensePlate));
                return true;
            }
            else
            {
                return false;
            }
        }
        public Car FindParticipant(string licensePlate)
        {
            return this.Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
        }
        public Car GetMostPowerfulCar()
        {
            if (this.Count == 0)
            {
                return null;
            }
            else
            {
                return this.Participants.OrderByDescending(c => c.HorsePower).First();
            }
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var car in Participants)
            {
                sb.AppendLine($"{car.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
