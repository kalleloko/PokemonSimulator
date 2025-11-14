using PokemonSimulator.Enums;

namespace PokemonSimulator.Models;

internal class Attack
{
    public string Name { get; private set; }
    public ElementType Type { get; private set; }
    public int BasePower { get; private set; }

    public Attack(string name, ElementType type, int basePower)
    {
        Name = name;
        Type = type;
        BasePower = basePower;
    }

    /// <summary>
    /// Calculates the total power by adding the specified level to the base power.
    /// </summary>
    /// <param name="level">The level to add to the base power.</param>
    /// <returns>The total power as an integer.</returns>
    public int Use(int level)
    {
        // ToDo: do the actual attack...
        return BasePower + level;
    }
}