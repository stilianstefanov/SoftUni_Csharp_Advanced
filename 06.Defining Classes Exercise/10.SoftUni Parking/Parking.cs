using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
		public Parking(int capacity)
		{
			Cars = new List<Car>();
			this.capacity = capacity;
		}

        private int capacity;
        private List<Car> cars;

		public List<Car> Cars
        {
			get { return cars; }
			set { cars = value; }
		}
		
		public int Count
		{
			get { return cars.Count; }			
		}


		public string AddCar(Car car)
		{
			if (this.cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
			{
				return "Car with that registration number, already exists!";
            }
			else if (capacity <= this.cars.Count)
			{
				return "Parking is full!";
            }
			else
			{
                this.cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }			
        }
		public string RemoveCar(string registrationNumber)
		{
			if (!cars.Any(c => c.RegistrationNumber == registrationNumber))
			{
				return "Car with that registration number, doesn't exist!";

            }
			else
			{
                cars.Remove(cars.Find(c => c.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }			
        }

		public Car GetCar(string registrationNumber)
		{
			return cars.Find(c => c.RegistrationNumber == registrationNumber);
		}

		public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
		{
			for (int i = 0; i < registrationNumbers.Count; i++)
			{
				RemoveCar(registrationNumbers[i]);
			}
		}
    }
}
