namespace PokemonSimulator;

internal class Program
{
    static void Main(string[] args)
    {
        List<Pokemon> pokemons = new List<Pokemon>();
        Pokemon charmander = new FirePokemon(name: "Charmander", level: 1);
        Pokemon squirtle = new WaterPokemon(name: "Squirtle", level: 1);
        Pokemon bulbasaur = new GrassPokemon(name: "Bulbasaur", level: 1);
        pokemons.Add(charmander);
        pokemons.Add(squirtle);
        pokemons.Add(bulbasaur);

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
