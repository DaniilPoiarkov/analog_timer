using AnalogTimer.DigitDrawers;
using AnalogTimer.Helpers;
using AnalogTimer.Models.Enums;

namespace AnalogTimer.DisplayHandlers;

public class MatrixDisplayHandler : DisplayHandlerBase
{
    private readonly Dictionary<int, List<char>> _digitsStore = new();

    private readonly Dictionary<int, string> _patternStore = new();

    private const int _spaceBetweenDigits = 5;

    public override void Update(int digit, TimerValue value)
    {
        var positionLeft = GetPosition(value);
        
        var values = TransformToEnumerable(digit, value)
            .Select(DigitDrawerProvider.GetDrawer)
            .Select(d => d.Pattern)
            .Aggregate((first, second) => first.Zip(second)
                .Select((pair, index) => $"{pair.First}{new string(' ', _spaceBetweenDigits)}{pair.Second}")
                .ToList());

        DisplayPattern(values, positionLeft);

        UIHelper.SetCursor();
    }

    public void DisplayMatrix(List<List<char>> matrix, int positionLeft)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            var values = matrix[i];
            _digitsStore.TryGetValue(positionLeft + i, out var snapshot);

            var diff = values.IntersectWithIndex(snapshot);

            foreach (var val in diff)
            {
                Console.CursorTop = val.Index;
                Console.CursorLeft = positionLeft + i;

                Console.WriteLine(val.Value);
            }

            _digitsStore[positionLeft + i] = values;
        }
    }

    public void DisplayPattern(List<string> pattern, int positionLeft)
    {
        for (int i = 0; i < pattern.Count; i++)
        {
            var column = pattern[i];
            _patternStore.TryGetValue(positionLeft + i, out var value);

            if (column.Equals(value))
                continue;
            
            Console.CursorTop = i;
            Console.CursorLeft = positionLeft;

            Console.WriteLine(column);
        }
    }
}
