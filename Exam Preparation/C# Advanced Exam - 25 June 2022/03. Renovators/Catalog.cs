using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public List<Renovator> Renovators { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count { get { return this.Renovators.Count; } }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name)
                || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (this.Count >= this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            else
            {
                this.Renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }
        public bool RemoveRenovator(string name)
        {
            if (!this.Renovators.Any(r => r.Name == name))
            {
                return false;
            }
            else
            {
                this.Renovators.Remove(this.Renovators.Find(r => r.Name == name));
                return true;
            }
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = 0;

            for (int i = 0; i < this.Renovators.Count; i++)
            {
                if (this.Renovators[i].Type == type)
                {
                    count++;
                    this.Renovators.Remove(this.Renovators[i]);
                    i--;
                }
            }
            return count;
        }
        public Renovator HireRenovator(string name)
        {
            if (!this.Renovators.Any(r => r.Name == name))
            {
                return null;
            }
            else
            {
                Renovator renovator = this.Renovators.Find(r => r.Name == name);
                renovator.Hired = true;
                return renovator;
            }
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> list = this.Renovators.Where(r => r.Days >= days).ToList();           
            return list;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");
            foreach (var renovator in this.Renovators)
            {
                if (renovator.Hired == false)
                {
                    sb.AppendLine($"{renovator.ToString()}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
