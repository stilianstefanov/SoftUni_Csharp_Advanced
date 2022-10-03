using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car()
        {
            Weight = -1;
            Color = "n/a";
        }
        public Car(string model, Engine engine):this()
        {
            Model = model;
            Engine = engine;           
        }
        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            Weight = weight;            
        }
        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Color = color;
        }
        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"{this.Engine}");
            if (this.Weight == -1)
            {
                sb.AppendLine("  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {this.Weight}");
            }
            sb.Append($"  Color: {this.Color}");

            return sb.ToString();
        }
    }
}
