using AnalogTimer.Contracts;

namespace AnalogTimer.DigitDrawers;

public abstract class DigitDrawerBase : IDigitDrawer
{
    private const int _partialHeight = 3;

    private const int _width = 8;

    protected const char _empty = ' ';

    public abstract void Draw(int positionLeft, ITimerTemplate template);

    protected static void Clear(int positionLeft)
    {
        PrintWidthLine(0, positionLeft, _empty);
        PrintWidthLine(3, positionLeft, _empty);
        PrintWidthLine(6, positionLeft, _empty);

        PrintHeightLine(true, positionLeft, _empty);
        PrintHeightLine(true, positionLeft + 7, _empty);

        PrintHeightLine(false, positionLeft, _empty);
        PrintHeightLine(false, positionLeft + 7, _empty);

        Console.CursorTop = 9;
    }

    protected static void PrintWidthLine(int top, int left, char pattern)
    {
        Console.CursorTop = top;
        Console.CursorLeft = left;

        for (int i = 0; i < _width; i++)
        {
            Console.Write(pattern);
        }

        Console.CursorLeft = default;
    }

    protected static void CrearWidthLine(int top, int left)
    {
        Console.CursorTop = top;
        Console.CursorLeft = left + 1;

        for(int i = 1;  i < _width - 1; i++)
        {
            Console.Write(_empty);
        }

        Console.CursorLeft = default;
    }

    protected static void PrintHeightLine(bool isTop, int positionLeft, char pattern)
    {
        Console.CursorTop = isTop ? 0 : 3;
        Console.CursorLeft = positionLeft;

        for (int i = 0; i <= _partialHeight; i++)
        {
            Console.WriteLine(pattern);
            Console.CursorLeft = positionLeft;
        }
    }

    protected static void ClearHeightLine(bool isTop, int left)
    {
        Console.CursorTop = isTop ? 1 : 4;
        Console.CursorLeft = left;

        for(int i = 1; i <= _partialHeight - 1; i++)
        {
            Console.WriteLine(_empty);
        }

        Console.CursorLeft = default;
    }
}
