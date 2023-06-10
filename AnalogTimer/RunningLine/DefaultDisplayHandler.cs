using ConsoleApplicationBuilder.Helpers;
using ConsoleOutputEngine.Contracts;
using RunningLine.Contracts;
using RunningLine.Implementations.OutputFormatter;
using RunningLineEngine.Models;

namespace RunningLine.RunningLineDisplayHandlers;

internal class DefaultDisplayHandler
{
    private readonly IConsoleOutput _output = IConsoleOutput.Create();

    private readonly IRunningLineArgsOutputFormatter _formatter = new RunningLineArgsOutputFormatter();

    public void Clean()
    {
        _output.PositionLeft = 1;
        _output.Out(new string(' ', Console.BufferWidth));
    }

    public void Display(string text, RunningLineEventArgs args)
    {
        Clean();

        _formatter.Update(args);
        _output.PositionLeft = args.Position < 0 ? 0 : args.Position;

        _output.Out(text, _formatter);

        UIHelper.SetCursor();
    }
}
