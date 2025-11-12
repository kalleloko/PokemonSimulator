namespace PokemonSimulator;

internal class GrassPokemon : Pokemon
{
    public GrassPokemon(int level, List<Attack> attacks) : base(level, attacks)
    {
        Type = ElementType.Grass;
    }
}