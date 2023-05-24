using AnalogTimer.Helpers;
using RunningLineEngine.Contracts;

namespace AnalogTimer.RunningLineDisplayHandlers;

internal class DefauldDisplayHandler : ILineDisplay
{
    public void Display(string text, int position)
    {
        Console.CursorTop = 1;
        Console.CursorLeft = position;
        var toClean = Console.BufferWidth - position;
        Console.Write(new string(' ', toClean));

        Console.CursorTop = 1;
        Console.CursorLeft = position;
        Console.Write(text);

        UIHelper.SetCursor();
    }
}
