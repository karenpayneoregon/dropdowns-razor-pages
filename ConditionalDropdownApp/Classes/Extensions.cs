namespace ConditionalDropdownApp.Classes;

public static class Extensions
{
    private static Random _rng = new();

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