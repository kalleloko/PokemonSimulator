namespace PokemonSimulator;

internal class Program
{
    static void Main(string[] args)
    {
        List<Pokemon> pokemons = new List<Pokemon>();
        pokemons.Add(new Charmander(level: 1));
        pokemons.Add(new Squirtle(level: 1));
        pokemons.Add(new Bulbasaur(level: 1));

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
