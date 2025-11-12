namespace PokemonSimulator;

internal class WaterPokemon : Pokemon
{
    public WaterPokemon(int level, List<Attack> attacks) : base(level, attacks)
    {
        Type = ElementType.Water;
    }
}