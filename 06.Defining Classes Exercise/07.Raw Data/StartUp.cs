using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int inputCnt = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCnt; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];
                Tire[] tires = GetTires(tokens);
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            switch (command)
            {
                case "fragile":
                    Console.WriteLine(string.Join(Environment.NewLine,
                        cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                        .Select(c => c.Model)));
                    break;
                case "flammable":
                    Console.WriteLine(string.Join(Environment.NewLine,
                        cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
                        .Select(c => c.Model)));
                    break;
            }
        }

        private static Tire[] GetTires(string[] tokens)
        {
            List<Tire> tires = new List<Tire>();

            for (int i = 5; i < tokens.Length; i += 2)
            {
                double pressure = double.Parse(tokens[i]);
                int age = int.Parse(tokens[i + 1]);
                
                Tire tire = new Tire(age, pressure);
                tires.Add(tire);
            }
            return tires.ToArray();
        }
    }
}
