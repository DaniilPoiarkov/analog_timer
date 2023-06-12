namespace ConsoleOutputEngine.Helpers;

public static class Extensions
{
    private const char _empty = ' ';

    private const int _spaceBetweenMatrixes = 2;

    public static List<string> ToAggregateModel(this IEnumerable<List<string>> matrix)
    {
        return matrix.Aggregate((first, second) =>
                first.Zip(second)
                    .Select((pair) => $"{pair.First}{new string(_empty, _spaceBetweenMatrixes)}{pair.Second}")
                    .ToList());
    }
}
