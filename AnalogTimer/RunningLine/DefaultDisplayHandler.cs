using ConsoleApplicationBuilder.Helpers;
using ConsoleOutputEngine.Contracts;

namespace AnalogTimer.RunningLineDisplayHandlers;

internal class DefaultDisplayHandler
{
    private readonly IConsoleOutput _output = IConsoleOutput.Create();

    private readonly List<string> _cleanWindowPattern;

    public DefaultDisplayHandler()
    {
        _cleanWindowPattern = new List<string>();

        for (int i = 1; i < 6; i++)
        {
            _cleanWindowPattern.Add(new string(' ', Console.BufferWidth));
        }
    }

    public void Clean()
    {
        _output.PositionLeft = 1;
        _output.Out(new string(' ', Console.BufferWidth));

        //TODO: Review
        //.Display(_cleanWindowPattern, 1);
    }

    public void Display(string text, int position)
    {
        Clean();

        _output.PositionLeft = position;
        _output.Out(text);

        // Review
        //_matrixDisplay.Display(text.ToList(), position);

        UIHelper.SetCursor();
    }
}
