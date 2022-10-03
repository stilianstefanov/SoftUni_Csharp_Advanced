using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    Engine engine = new Engine(tokens[0], int.Parse(tokens[1]));
                    engines.Add(engine);
                }
                else if (tokens.Length == 3)
                {
                    int dissplacement = 0;
                    bool isInt = int.TryParse(tokens[2], out dissplacement);
                    if (isInt)
                    {
                        Engine engine = new Engine(tokens[0], int.Parse(tokens[1]), dissplacement);
                        engines.Add(engine);
                    }
                    else
                    {
                        Engine engine = new Engine(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        engines.Add(engine);
                    }
                }
                else
                {
                    Engine engine = new Engine(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]), tokens[3]);
                    engines.Add(engine);
                }
            }

            List<Car> cars = new List<Car>();
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    Engine engine = engines.Find(e => e.Model == tokens[1]);
                    Car car = new Car(tokens[0], engine);
                    cars.Add(car);
                }
                else if (tokens.Length == 3)
                {
                    Engine engine = engines.Find(e => e.Model == tokens[1]);

                    int weight = 0;
                    bool isInt = int.TryParse(tokens[2], out weight);
                    if (isInt)
                    {
                        Car car = new Car(tokens[0], engine, weight);
                        cars.Add(car);
                    }
                    else
                    {
                        Car car = new Car(tokens[0], engine, tokens[2]);
                        cars.Add(car);
                    }
                }
                else
                {
                    Engine engine = engines.Find(e => e.Model == tokens[1]);
                    Car car = new Car(tokens[0], engine, int.Parse(tokens[2]), tokens[3]);
                    cars.Add(car);
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
