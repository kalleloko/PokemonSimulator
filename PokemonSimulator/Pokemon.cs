namespace PokemonSimulator;

internal abstract class Pokemon
{

    protected List<Attack> _attacks = new List<Attack>();

    protected string _name = string.Empty;
    public string Name
    {
        get => _name;
        protected set
        {
            if (value.Length < 3 || value.Length > 15)
            {
                throw new ArgumentException("Namnet måste vara 3-15 tecken långt.", nameof(value));
            }
            _name = value;
        }
    }

    private int _level = 1;
    public int Level
    {
        get => _level;
        protected set
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Level måste vara minst 1.");
            }

            _level = value;
        }
    }

    protected ElementType? _type = null;

    public ElementType Type { get; protected set; }

    public Pokemon(int level, List<Attack> attacks)
    {
        Level = level;
        _attacks = attacks;
    }

    public void RandomAttack()
    {
        Random rnd = new Random();
        int attackIndex = rnd.Next(_attacks.Count);
        _attacks[attackIndex].Use(Level);
    }
    public void Attack()
    {
        foreach(var attack in _attacks)
        {
            attack.Use(Level);
        }
    }

    public void RaiseLevel(int level)
    {
        Level++;
    }
}