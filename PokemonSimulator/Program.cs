using PokemonSimulator.Enums;
using PokemonSimulator.Interfaces;
using PokemonSimulator.Models;
using PokemonSimulator.Models.Pokemons;
using PokemonSimulator.UI;

namespace PokemonSimulator;

internal class Program
{
    static IUI ui = new ConsoleUI();
    static void Main(string[] args)
    {

        List<Pokemon> pokemons = SeedPokemons();

        while (true)
        {
            ui.Clear();
            ui.PrintLine("Starting a new training round...");
            ui.PrintLine("--------------------------------", 1);
            foreach (Pokemon pokemon in pokemons)
            {
                ui.PrintEmptyLines();
                ui.PrintLine($"Training {pokemon.Name} (Level {pokemon.Level})...");
                try
                {
                    pokemon.RaiseLevel();
                    ui.PrintEmptyLines();
                    int attackIndex = AskForAttackIndex(pokemon);
                    var (attack, power) = pokemon.Attack(attackIndex);
                    ui.PrintLine($"{attack.Name} hit with a total power of {power}");

                    if (pokemon is IEvolvable evolvablePokemon)
                    {
                        var (oldName, oldLevel, didEvolve) = evolvablePokemon.Evolve();
                        ui.PrintLine(didEvolve ?
                            $"{oldName} is evolving... Now it is a {pokemon.Name} and it's level is {pokemon.Level}" :
                            $"{oldName} cannot evolve more"
                        );
                    }
                }
                catch (Exception ex)
                {
                    ui.PrintErrorLine($"Failed to train {pokemon.Name}: {ex.Message}");
                }
            }
            ui.PrintEmptyLines();
            ui.PrintLine("Training round completed!");
            ui.Print($"Press anything to continue training, or 'q' to quit.{Environment.NewLine}");
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Q)
            {
                ui.Print("bye");
                break;
            }
        }

    }

    private static List<Pokemon> SeedPokemons()
    {
        Attack flamethrower = new Attack(name: "Flamethrower", type: ElementType.Fire, basePower: 12);
        Attack ember = new Attack(name: "Ember", type: ElementType.Fire, basePower: 8);
        Attack waterGun = new Attack(name: "Water Gun", type: ElementType.Water, basePower: 6);
        Attack bubble = new Attack(name: "Bubble", type: ElementType.Water, basePower: 5);
        Attack vineWhip = new Attack(name: "Vine Whip", type: ElementType.Grass, basePower: 7);
        Attack razorLeaf = new Attack(name: "Razor Leaf", type: ElementType.Grass, basePower: 10);

        List<Pokemon> pokemons = new();
        pokemons.Add(new Charmander(level: 1, new List<Attack>() { flamethrower, ember }));
        pokemons.Add(new Squirtle(level: 1, new List<Attack>() { waterGun, bubble }));
        pokemons.Add(new Bulbasaur(level: 1, new List<Attack>() { vineWhip, razorLeaf }));
        return pokemons;
    }

    private static int AskForAttackIndex(Pokemon pokemon)
    {
        var options = pokemon.Attacks
                .Select((attack, index) => new { attack, index })
                .ToDictionary(a => (char)('A' + a.index), a => a.index);
        var selected = ui.SelectInput<int>(
            options: options,
            displayFunc: attackIndex =>
            {
                Attack attack = pokemon.Attacks.ElementAt(attackIndex);
                return $"{attack.Name} (Type: {attack.Type}, Power: {attack.BasePower})";
            },
            prompt: $"Select an attack for {pokemon.Name}:",
            errorMessage: "Invalid attack selection, please try again."
        );
        return selected;
    }
}
