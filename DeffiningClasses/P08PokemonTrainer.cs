using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08PokemonTrainer
{
    class P08PokemonTrainer
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string line;

            while ((line = Console.ReadLine()) != "Tournament")
            {
                string[] trainerPokemonInfo = line.Split();

                string trainerName = trainerPokemonInfo[0];
                string pokemonName = trainerPokemonInfo[1];
                string element = trainerPokemonInfo[2];
                int pokemonHealth = int.Parse(trainerPokemonInfo[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, pokemonHealth);

                if (trainers.Select(x => x.name).Contains(trainerName))
                {
                    trainers.Where(x => x.name == trainerName).Single().pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName, pokemon);
                    trainers.Add(trainer);
                }
            }

            while ((line = Console.ReadLine()) != "End")
            {
                string element = line;
                foreach (Trainer trainer in trainers)
                {
                    trainer.Attack(element);
                }
            }

            foreach (Trainer trainer in trainers.OrderByDescending(x => x.badges))
            {
                Console.WriteLine($"{trainer.name} {trainer.badges} {trainer.pokemons.Count}");
            }
        }
    }
    public class Trainer
    {
        public string name;
        public int badges;
        public List<Pokemon> pokemons = new List<Pokemon>();
        public Trainer(string name, Pokemon pokemon)
        {
            this.name = name;
            this.badges = badges;
            this.pokemons.Add(pokemon);
        }
        public void Attack(string element)
        {
            bool hasElement = false;
            foreach (Pokemon pokemon in pokemons)
            {
                if (pokemon.element == element)
                {
                    hasElement = true;
                    break;
                }
            }
            if (hasElement)
            {
                badges++;
            }
            else
            {
                foreach (Pokemon pokemon in pokemons)
                {
                    pokemon.health -= 10;
                }
            }

            pokemons = pokemons.Where(x => x.health > 0).ToList();
        }
    }
    public class Pokemon
    {
        public string name;
        public string element;
        public int health;

        public Pokemon(string name, string element, int health)
        {
            this.name = name;
            this.element = element;
            this.health = health;
        }
    }
}
