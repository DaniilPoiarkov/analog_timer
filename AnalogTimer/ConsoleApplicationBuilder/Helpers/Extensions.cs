namespace ConsoleApplicationBuilder.Helpers;

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
            return first.Select((value, index) => (index, value));
        }

        return first
            .Select((value, index) => (Value: value, Index: index))
            .Zip(second.Select((value, index) => (Value: value, Index: index)))
            .Where(pair => pair.First.Value is not null
                && !pair.First.Value.Equals(pair.Second.Value))
            .Select(pair => (pair.First.Index, pair.First.Value));
    }
}
