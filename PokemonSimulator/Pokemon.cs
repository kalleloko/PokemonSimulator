using System.Reflection.Emit;

namespace PokemonSimulator;

internal abstract class Pokemon
{
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

    public Pokemon(int level)
    {
        Level = level;
    }

    internal void Attack()
    {
        throw new NotImplementedException();
    }

    internal void RaiseLevel(int level)
    {
        throw new NotImplementedException();
    }
}