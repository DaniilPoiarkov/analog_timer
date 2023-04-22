using AnalogTimer.Contracts;
using AnalogTimer.DigitDrawers;
using AnalogTimer.Helpers;
using AnalogTimer.Models.Enums;

namespace AnalogTimer.DisplayHandlers;

public class MatrixDisplayHandler : DisplayHandlerBase
{
    private readonly ITimerTemplate _timerTemplate;

    private readonly Dictionary<int, List<bool>> _digitsStore = new();

    public MatrixDisplayHandler(ITimerTemplate timerTemplate)
    {
        _timerTemplate = timerTemplate;
    }

    public override void Update(int digit, TimerValue value)
    {
        var positionLeft = GetPosition(value);

        var values = TransformToEnumerable(digit, value);

        foreach (var num in values)
        {
            var drawer = DigitDrawerProvider.GetDrawer(num);

            DisplayMatrix(drawer.Matrix, positionLeft);

            positionLeft += _space;
        }

        UIHelper.SetCursor();
    }

    private void DisplayMatrix(List<List<bool>> matrix, int positionLeft)
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

                Console.WriteLine(val.Value ? _timerTemplate.Pattern : _empty);
            }

            _digitsStore[positionLeft + i] = values;
        }
    }
}
