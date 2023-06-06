using MatrixDisplayEngine.Contracts;

namespace MatrixDisplayEngine.Implementations;

public sealed class MatrixDisplay : IMatrixDisplay
{
    private readonly object _lock = new();

    private readonly Dictionary<int, string> _patternStore = new();

    private const char _empty = ' ';

    private const int _spaceBetweenMatrixes = 5;

    private MatrixDisplay() { }

    private static readonly Lazy<MatrixDisplay> _instance = new(() => new MatrixDisplay());

    public static IMatrixDisplay Instance => _instance.Value;


    public void Display(IEnumerable<List<string>> multipleMatrixes, int horizontalPosition)
    {
        lock (_lock)
        {
            if (!multipleMatrixes.Any())
            {
                return;
            }

            var values = multipleMatrixes.Aggregate((first, second) =>
                first.Zip(second)
                    .Select((pair) => $"{pair.First}{new string(_empty, _spaceBetweenMatrixes)}{pair.Second}")
                    .ToList());

            Display(values, horizontalPosition);
        }
    }

    public void Display(List<string> matrix, int horizontalPosition)
    {
        lock (_lock)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                var column = matrix[i];
                _patternStore.TryGetValue(horizontalPosition + i, out var value);

                if (column.Equals(value))
                    continue;

                Console.CursorTop = i;
                Console.CursorLeft = horizontalPosition;

                Console.Write(column);
            }
        }
    }
}
