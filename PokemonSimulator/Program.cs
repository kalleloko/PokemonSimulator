using PokemonSimulator.Utilities;
using System.Diagnostics;

namespace PokemonSimulator;

internal class Program
{
    static IUI ui = new ConsoleUI();
    static void Main(string[] args)
    {

        Attack flamethrower = new Attack(name: "Flamethrower", type: ElementType.Fire, basePower: 12);
        Attack ember = new Attack(name: "Ember", type: ElementType.Fire, basePower: 8);
        Attack waterGun = new Attack(name: "Water Gun", type: ElementType.Water, basePower: 6);
        Attack bubble = new Attack(name: "Bubble", type: ElementType.Water, basePower: 5);
        Attack vineWhip = new Attack(name: "Vine Whip", type: ElementType.Grass, basePower: 7);
        Attack razorLeaf = new Attack(name: "Razor Leaf", type: ElementType.Grass, basePower: 10);

        List<Pokemon> pokemons = new List<Pokemon>();
        pokemons.Add(new Charmander(level: 1, new List<Attack>() { flamethrower, ember }));
        pokemons.Add(new Squirtle(level: 1, new List<Attack>() { waterGun, bubble }));
        pokemons.Add(new Bulbasaur(level: 1, new List<Attack>() { vineWhip, razorLeaf }));

        while (true)
        {
            ui.Clear();
            ui.PrintLine("Starting a new training round...");
            ui.PrintLine("--------------------------------");
            ui.PrintEmptyLines();
            foreach (Pokemon pokemon in pokemons)
            {
                ui.PrintLine($"Training {pokemon.Name} (Level {pokemon.Level})...");
                try
                {
                    ui.PrintEmptyLines();
                    pokemon.RaiseLevel();
                    ui.PrintEmptyLines();
                    int attackIndex = AskForAttackIndex(pokemon);
                    pokemon.Attack(1);
                    if (pokemon is IEvolvable evolvablePokemon)
                    {
                        evolvablePokemon.Evolve();
                    }
                }
                catch (Exception ex)
                {
                    ui.PrintErrorLine($"Failed to train {pokemon.Name}: {ex.Message}");
                    ui.PrintLine(ex.StackTrace);
                }
            }
            ui.PrintEmptyLines();
            ui.PrintLine("Training round completed!");
            ui.Print($"Press anything to continue training, or 'q' to quit.{Environment.NewLine}");
            ConsoleKey key = Console.ReadKey(true).Key;
            if(key == ConsoleKey.Q)
            {
                ui.Print("bye");
                break;
            }
        }

    }

    private static int AskForAttackIndex(Pokemon pokemon)
    {
        return ui.SelectInput<int>(
            options: pokemon.Attacks
                .Select((attack, index) => new { attack, index })
                .ToDictionary(a => (char)('A' + a.index), a => a.index),
            displayFunc: attackIndex => 
            {
                Attack attack = pokemon.Attacks.ElementAt(attackIndex);
                return $"{attack.Name} (Type: {attack.Type}, Power: {attack.BasePower})";
            },
            prompt: $"Select an attack for {pokemon.Name}:",
            errorMessage: "Invalid attack selection, please try again."
        );
    }
}
