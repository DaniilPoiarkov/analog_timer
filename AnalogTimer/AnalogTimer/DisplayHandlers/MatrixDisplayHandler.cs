using AnalogTimer.DigitDrawers;
using AnalogTimer.Helpers;
using AnalogTimer.Models.Enums;
using System.Runtime.InteropServices;

namespace AnalogTimer.DisplayHandlers;

public class MatrixDisplayHandler : DisplayHandlerBase
{
    private readonly Dictionary<int, List<char>> _digitsStore = new();

    private readonly Dictionary<int, string> _patternStore = new();

    public override void Update(int digit, TimerValue value)
    {
        var positionLeft = GetPosition(value);

        var values = TransformToEnumerable(digit, value)
            .ToList();

        foreach (var num in CollectionsMarshal.AsSpan(values))
        {
            var drawer = DigitDrawerProvider.GetDrawer(num);

            DisplayPattern(drawer.Pattern, positionLeft);

            positionLeft += _space;
        }

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
