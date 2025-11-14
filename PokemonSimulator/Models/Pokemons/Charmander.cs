using PokemonSimulator.Extensions;
using PokemonSimulator.Interfaces;

namespace PokemonSimulator.Models.Pokemons
{
    internal class Charmander : FirePokemon, IEvolvable
    {

        private List<string> _evolutions =
            [
                "Charmeleon",
                "Charizard"
            ];

        public Charmander(int level, List<Attack> attacks) : base(level, attacks)
        { }

        /// <summary>
        /// Evolves the current entity to its next stage, if possible.
        /// </summary>
        /// <remarks>The evolution process updates the entity's name to the next available stage in the
        /// evolution sequence and increases its level by 10. If the entity cannot evolve further, its name remains
        /// unchanged, and no level increase occurs.
        /// ToDo: This method is duplicated in other IEvolvable Pokemons. Find solution</remarks>
        public (string oldName, int oldLevel, bool didEvolve) Evolve()
        {
            string oldName = Name;
            Name = _evolutions.SelectItemAfter(Name) ?? Name;
            bool didEvolve = oldName != Name;
            int oldLevel = Level;
            if (didEvolve)
            {
                Level += 10;
            }
            return (oldName, oldLevel, didEvolve);
        }
    }
}