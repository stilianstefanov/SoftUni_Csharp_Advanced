using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string info;
            while ((info = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = info.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    trainers.Add(newTrainer);
                }

                var trainer = trainers.Find(t => t.Name == trainerName);
                trainer.PokemonCollection.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));                
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.PokemonCollection.Any(p => p.Element == command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.PokemonCollection = trainer.PokemonCollection.Select(p => { p.Health -= 10; return p; }).ToList();
                        if (trainer.PokemonCollection.Any(p => p.Health <= 0))
                        {
                            trainer.PokemonCollection = trainer.PokemonCollection.Where(p => p.Health > 0).ToList();
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.PokemonCollection.Count}");
            }
        }
    }
}
