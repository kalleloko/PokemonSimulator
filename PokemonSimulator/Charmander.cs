namespace PokemonSimulator
{
    internal class Charmander : FirePokemon, IEvolvable
    {
        public Charmander(int level, List<Attack> attacks) : base(level, attacks)
        {
            Name = "Charmander";
        }

        public void Evolve()
        {
            Name = "Charmeleon";
        }
    }
}