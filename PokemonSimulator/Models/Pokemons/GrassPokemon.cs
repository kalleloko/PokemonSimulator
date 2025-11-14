using PokemonSimulator.Enums;

namespace PokemonSimulator.Models.Pokemons;

internal abstract class GrassPokemon : Pokemon
{
    public GrassPokemon(int level, List<Attack> attacks) : base(level, attacks)
    {
        Type = ElementType.Grass;
    }
}