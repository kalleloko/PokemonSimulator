namespace PokemonSimulator;

internal class Attack
{
	private string _name = string.Empty;

	public string Name
	{
		get;
		private set;
	}

	private ElementType _type;

	public ElementType Type
	{
		get;
		private set;
	}

	private int _basePower;

	public int BasePower
    {
		get;
		private set;
	}

	public Attack(string name, ElementType type, int basePower)
	{
		Name = name;
		Type = type;
		BasePower = basePower;
    }

    public void Use(int level)
    {
        // Implementation of attack usage
    }
}