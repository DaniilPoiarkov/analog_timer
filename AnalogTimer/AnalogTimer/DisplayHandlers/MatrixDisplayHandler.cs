using AnalogTimer.DigitDrawers;
using AnalogTimer.Helpers;
using AnalogTimer.Models.Enums;
using System.Runtime.InteropServices;

namespace AnalogTimer.DisplayHandlers;

public class MatrixDisplayHandler : DisplayHandlerBase
{
    private readonly Dictionary<int, List<char>> _digitsStore = new();

    public override void Update(int digit, TimerValue value)
    {
        var positionLeft = GetPosition(value);

        var values = TransformToEnumerable(digit, value)
            .ToList();

        foreach (var num in CollectionsMarshal.AsSpan(values))
        {
            var drawer = DigitDrawerProvider.GetDrawer(num);
            
            DisplayMatrix(drawer.Matrix, positionLeft);

            positionLeft += _space;
        }

        UIHelper.SetCursor();
    }

    private void DisplayMatrix(List<List<char>> matrix, int positionLeft)
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
}
