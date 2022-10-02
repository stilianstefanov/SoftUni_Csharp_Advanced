using System;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
		public Car()
		{
			this.Make = "VW";
			this.Model = "Golf";
			this.Year = 2025;
			this.FuelQuantity = 200;
			this.FuelConsumption = 10;
		}
		public Car(string make, string model, int year) : this()
		{
			this.Make = make;
			this.Model = model;
			this.Year = year;
		}
		public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
		{
			this.FuelQuantity = fuelQuantity;
			this.FuelConsumption = fuelConsumption;
		}

		public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
			: this(make, model, year, fuelQuantity, fuelConsumption)
		{
			this.Engine = engine;
			this.Tires = tires;
		}

		private string make;

		public string Make
		{
			get { return make; }
			set { make = value; }
		}
		private string model;

		public string Model
		{
			get { return model; }
			set { model = value; }
		}
		private int year;

		public int Year
		{
			get { return year; }
			set { year = value; }
		}

		private double fuelQuantity;

		public double FuelQuantity
        {
			get { return fuelQuantity; }
			set { fuelQuantity = value; }
		}

		private double fuelConsumption;

		public double FuelConsumption
        {
			get { return fuelConsumption; }
			set { fuelConsumption = value; }
		}

		private Engine engine;

		public Engine Engine
		{
			get { return engine; }
			set { engine = value; }
		}

		private Tire[] tires;

		public Tire[] Tires
		{
			get { return tires; }
			set { tires = value; }
		}


		public void Drive (double distance)
		{
			double fuelLeft = this.FuelQuantity - (distance * fuelConsumption / 100);
			
			if (fuelLeft <= 0)
			{
				Console.WriteLine("Not enough fuel to perform this trip!");
				return;
			}

			this.FuelQuantity = fuelLeft;
		}

		public string WhoAmI()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"Make: {this.Make}");
			sb.AppendLine($"Model: {this.Model}");
			sb.AppendLine($"Year: {this.Year}");
			sb.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
			sb.AppendLine($"FuelQuantity: {this.FuelQuantity}");


			return sb.ToString();
		}

    }
}
