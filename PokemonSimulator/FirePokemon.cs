namespace PokemonSimulator;

internal class FirePokemon : Pokemon
{
    public FirePokemon(int level, List<Attack> attacks) : base(level, attacks)
    {
        Type = ElementType.Fire;
    }

}