using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Animals = new List<Animal>();
            Name = name;
            Capacity = capacity;
        }

        public List<Animal> Animals { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }


        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (this.Animals.Count >= this.Capacity)
            {
                return "The zoo is full.";
            }
            else
            {
                this.Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
        }
        public int RemoveAnimals(string species)
        {
            int count = this.Animals.RemoveAll(a => a.Species == species);

            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> list = new List<Animal>();
            list = this.Animals.Where(a => a.Diet == diet).ToList();

            return list;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            Animal animal = this.Animals.FirstOrDefault(a => a.Weight == weight);

            return animal;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            List<Animal> list = this.Animals.Where(a => a.Length >= minimumLength && a.Length <= maximumLength).ToList();

            return $"There are {list.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
