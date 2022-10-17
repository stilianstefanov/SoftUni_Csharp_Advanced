using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Ingredients = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel { get { return this.Ingredients.Sum(i => i.Alcohol); } }

        public void Add(Ingredient ingredient)
        {
            if (this.Ingredients.Any(i => i.Name == ingredient.Name))
            {
                return;
            }
            if (this.Ingredients.Count >= this.Capacity)
            {
                return;
            }
            if (this.CurrentAlcoholLevel + ingredient.Alcohol <= this.MaxAlcoholLevel)
            {
                this.Ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            if (!this.Ingredients.Any(i => i.Name == name))
            {
                return false;
            }
            else
            {
                this.Ingredients.Remove(this.Ingredients.Find(i => i.Name == name));
                return true;
            }
        }
        public Ingredient FindIngredient(string name)
        {
            return this.Ingredients.FirstOrDefault(i => i.Name == name);
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            return this.Ingredients.OrderByDescending(i => i.Alcohol).First();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in this.Ingredients)
            {
                sb.AppendLine($"{item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
