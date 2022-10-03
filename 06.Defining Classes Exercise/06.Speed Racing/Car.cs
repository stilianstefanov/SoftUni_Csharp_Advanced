using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        public Car()
        {
            this.TravelledDistance = 0;
        }
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer) :this()
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;            
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double amountOfKm)
        {
            double fuelLeft = this.FuelAmount - (amountOfKm * FuelConsumptionPerKilometer);
            if (fuelLeft < 0)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }
            this.FuelAmount = fuelLeft;
            this.TravelledDistance += amountOfKm;
        }
    }
}
