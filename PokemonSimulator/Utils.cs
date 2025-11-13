namespace PokemonSimulator;

internal class Utils
{
    public static T SelectNext<T>(T currentItem, List<T> itemList)
    {
        int currentIndex = itemList.IndexOf(currentItem);
        int nextIndex = Math.Min((currentIndex + 1), (itemList.Count - 1));
        return itemList[nextIndex];
    }
}
