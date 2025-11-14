namespace PokemonSimulator.Extensions;

public static class ListExtensions
{
    public static T? SelectItemAfter<T>(this List<T> list, T currentItem)
    {
        if (list is null || list.Count == 0)
        {
            return default;
        }
        int currentIndex = list.IndexOf(currentItem);
        return list[currentIndex + 1] ?? default;
    }
}
