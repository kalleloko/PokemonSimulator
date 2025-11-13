namespace PokemonSimulator;

internal class Squirtle : WaterPokemon, IEvolvable
{
    private List<string> _evolutions =
        [
            "Wartortle",
            "Blastoise"
        ];
    public Squirtle(int level, List<Attack> attacks) : base(level, attacks)
    { }

    public void Evolve()
    {
        string oldName = Name;
        Name = Utils.SelectNext<string>(Name, _evolutions);
        if (oldName == Name)
        {
            Console.WriteLine($"{oldName} cannot evolve more");
            return;
        }
        Level += 10;
        Console.WriteLine($"{oldName} is evolving... Now it is a {Name} and it's level is {Level}");
    }
}