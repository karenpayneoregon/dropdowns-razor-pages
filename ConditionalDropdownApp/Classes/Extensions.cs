namespace ConditionalDropdownApp.Classes;

public static class Extensions
{
    private static Random _rng = new();
    /// <summary>
    /// For prior to .NET 7
    /// </summary>
    public static void Shuffle<T>(this IList<T> list)
    {
        int value = list.Count;
        while (value > 1)
        {
            value--;
            int index = _rng.Next(value + 1);
            (list[index], list[value]) = (list[value], list[index]);
        }
    }
}