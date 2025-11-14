namespace PokemonSimulator
{
    internal interface IEvolvable
    {
        public (string oldName, int oldLevel, bool didEvolve) Evolve();
    }
}