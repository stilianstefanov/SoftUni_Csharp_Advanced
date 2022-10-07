using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield (string name, int capacity, double landingStrip)
        {           
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get { return this.Drones.Count; } }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
            {
                return "Invalid drone.";
            }
            else if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if (this.Count >= this.Capacity)
            {
                return "Airfield is full.";
            }
            else
            {
                this.Drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
        }
        public bool RemoveDrone(string name)
        {
            if (!this.Drones.Any(d => d.Name == name))
            {
                return false;
            }
            else
            {
                this.Drones.Remove(this.Drones.Find(d => d.Name == name));
                return true;
            }
        }
        public int RemoveDroneByBrand(string brand)
        {
            return this.Drones.RemoveAll(d => d.Brand == brand);
        }
        public Drone FlyDrone(string name)
        {
            if (!this.Drones.Any(d => d.Name == name))
            {
                return null;
            }
            else
            {
                Drone drone = this.Drones.Find(d => d.Name == name);
                drone.Available = false;
                return drone;
            }
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> list = this.Drones.Where(d => d.Range >= range).ToList();
            list = list.Select(d => { d.Available = false; return d; }).ToList();

            return list;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var drone in this.Drones.Where(d => d.Available == true))
            {
                sb.AppendLine($"{drone.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
