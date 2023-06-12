namespace ConsoleInterface.Helpers;

public static class LinqExt
{
    private const char _empty = ' ';

    private const int _spaceBetweenMatrixes = 5;

    public static List<string> AggregateToDisplayModel(this IEnumerable<List<string>> matrix)
    {
        return matrix.Aggregate((first, second) =>
                first.Zip(second)
                    .Select((pair) => $"{pair.First}{new string(_empty, _spaceBetweenMatrixes)}{pair.Second}")
                    .ToList());
    }
}
