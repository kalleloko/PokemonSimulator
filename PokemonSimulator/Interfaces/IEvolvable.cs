namespace PokemonSimulator.Interfaces
{
    internal interface IEvolvable
    {
        /// <summary>
        /// Evolves the entity to its next state, if eligible, and returns information about the evolution process.
        /// </summary>
        /// <remarks>The evolution process may depend on specific conditions such as the entity's current
        /// level or other criteria. If the entity does not meet the requirements for evolution, the method returns <see
        /// langword="false"/> for <c>didEvolve</c>, and the entity remains unchanged.</remarks>
        /// <returns>A tuple containing the following: <list type="bullet"> <item> <description><c>oldName</c>: The name of the
        /// entity before evolution.</description> </item> <item> <description><c>oldLevel</c>: The level of the entity
        /// before evolution.</description> </item> <item> <description><c>didEvolve</c>: <see langword="true"/> if the
        /// entity successfully evolved; otherwise, <see langword="false"/>.</description> </item> </list></returns>
        public (string oldName, int oldLevel, bool didEvolve) Evolve();
    }
}