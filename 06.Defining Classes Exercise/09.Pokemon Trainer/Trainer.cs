using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            PokemonCollection = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> PokemonCollection { get; set; }
    }
}
