namespace PokemonSimulator;

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

    public void Use(int level)
    {
        Console.WriteLine($"{Name} hit with a total power of {BasePower + level}");
    }
}