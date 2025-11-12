namespace PokemonSimulator;

internal class FirePokemon : Pokemon, IEvolvable
{
    public FirePokemon(string name, int level) : base(name, level)
    {
    }

    public void Evolve()
    {
        throw new NotImplementedException();
    }
}