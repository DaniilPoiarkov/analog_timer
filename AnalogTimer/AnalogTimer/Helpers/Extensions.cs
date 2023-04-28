namespace AnalogTimer.Helpers;

public static class Extensions
{
    public static IEnumerable<(int Index, T Value)> IntersectWithIndex<T>(this IEnumerable<T> first, IEnumerable<T>? second)
    {
        if (first.SequenceEqual(second ?? Enumerable.Empty<T>()))
        {
            return Enumerable.Empty<(int Index, T Value)>();
        }

        if (second is null || !second.Any())
        {
            return ExtractItems(first, 0);
        }

        var firstAsList = first.ToList();
        var secondAsList = second.ToList();

        var (limit, from) = firstAsList.Count - secondAsList.Count >= 0
            ? (secondAsList.Count, firstAsList)
            : (firstAsList.Count, secondAsList);

        var result = new List<(int, T)>();

        var index = GetDifference(firstAsList, secondAsList, limit, result);

        var missing = ExtractItems(from, index);

        result.AddRange(missing);

        return result;
    }

    private static IEnumerable<(int Index, T Value)> ExtractItems<T>(IEnumerable<T> from, int index)
    {
        return from.Skip(index)
                    .Select(v =>
                    {
                        var idx = index;
                        index++;
                        return (idx, v);
                    });
    }

    private static int GetDifference<T>(List<T> firstAsList, List<T> secondAsList, int limit, List<(int, T)> result)
    {
        int index;

        for (index = 0; index < limit; index++)
        {
            var x = firstAsList[index];
            var y = secondAsList[index];

            if (x is null && y is null)
            {
                continue;
            }

            if (x is null || y is null)
            {
                result.Add((index, x));
                continue;
            }

            if (x.Equals(y))
            {
                continue;
            }

            result.Add((index, x));
        }

        return index;
    }
}
