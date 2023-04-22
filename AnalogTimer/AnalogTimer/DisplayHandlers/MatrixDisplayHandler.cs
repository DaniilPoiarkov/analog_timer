using AnalogTimer.Contracts;
using AnalogTimer.DigitDrawers;
using AnalogTimer.Models.Enums;

namespace AnalogTimer.DisplayHandlers;

public class MatrixDisplayHandler : DisplayHandlerBase
{
    private readonly ITimerTemplate _timerTemplate;

    private readonly Dictionary<int, bool[,]> _digitsStore = new();

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
    }

    private void DisplayMatrix(bool[,] matrix, int positionLeft)
    {
        var rows = matrix.GetUpperBound(0) + 1;

        var columns = matrix.Length / rows;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.CursorTop = j;
                Console.CursorLeft = positionLeft + i;

                if (_digitsStore.TryGetValue(positionLeft + i, out var snapshot)
                    && matrix[i, j] == snapshot[i, j])
                    continue;

                Console.WriteLine(matrix[i, j] ? _timerTemplate.Pattern : ' ');
            }
        }
    }
}
