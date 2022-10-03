using System;
using System.Collections.Generic;
using System.Reflection;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsuptionPer1km = double.Parse(tokens[2]);

                Car car = new Car(model, fuelAmount, fuelConsuptionPer1km);
                cars.Add(car);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[1];
                double amountOfKm = double.Parse(tokens[2]);

                Car carToDrive = cars.Find(x => x.Model == model);
                carToDrive.Drive(amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
