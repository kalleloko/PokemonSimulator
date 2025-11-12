namespace PokemonSimulator;

internal class Program
{
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


        foreach (Pokemon pokemon in pokemons)
        {
            try
            {
                pokemon.RaiseLevel(level: 5);
                pokemon.Attack();
                if (pokemon is IEvolvable evolvablePokemon)
                {
                    evolvablePokemon.Evolve();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to train {pokemon.Name}: {ex.Message}");
            }
        }

    }
}
