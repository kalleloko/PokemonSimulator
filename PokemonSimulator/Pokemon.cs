namespace PokemonSimulator;

internal abstract class Pokemon
{

    private List<Attack> _attacks = new List<Attack>();
    private string _name = string.Empty;
    private int _level = 1;
    

    public IEnumerable<Attack> Attacks
    {
        get => _attacks;
        protected set { _attacks = value.ToList(); }
    }

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

    public ElementType Type { get; protected set; }

    public Pokemon(int level, List<Attack> attacks)
    {
        Level = level;
        _attacks = attacks;
        Name = GetType().Name;
    }

    public void RandomAttack()
    {
        Random rnd = new Random();
        int attackIndex = rnd.Next(_attacks.Count);
        _attacks[attackIndex].Use(Level);
    }
    public void Attack(int index)
    {
        Attack? attack = _attacks[index] ?? throw new ArgumentOutOfRangeException(
            nameof(index),
            $"No attack found at index {index} in {GetType().Name}."
        );
        attack.Use(Level);
    }

    public void RaiseLevel()
    {
        Level++;
    }
}   