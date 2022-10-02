using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tireSets = new List<Tire[]>();

            string tiresInfo;
            while ((tiresInfo = Console.ReadLine()) != "No more tires")
            {
                string[] tokens = tiresInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                List<Tire> curTireSet = new List<Tire>();

                for (int i = 0; i < tokens.Length; i += 2)
                {
                    int year = int.Parse(tokens[i]);
                    double pressure = double.Parse(tokens[i + 1]);

                    Tire tire = new Tire(year, pressure);
                    curTireSet.Add(tire);
                }
                tireSets.Add(curTireSet.ToArray());
            }

            List<Engine> engines = new List<Engine>();

            string engineInfo;
            while ((engineInfo = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = engineInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();
            string carInfo;
            while ((carInfo = Console.ReadLine()) != "Show special")
            {
                string[] tokens = carInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsuption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsuption, engines[engineIndex], tireSets[tiresIndex]);
                cars.Add(car);
            }

            List<Car> specialCars = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Year >= 2017 && cars[i].Engine.HorsePower > 330
                    && cars[i].Tires.Select(t => t.Pressure).Sum() > 9 
                    && cars[i].Tires.Select(t => t.Pressure).Sum() < 10)
                {                    
                    specialCars.Add(cars[i]);
                }
            }

            foreach (var car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
