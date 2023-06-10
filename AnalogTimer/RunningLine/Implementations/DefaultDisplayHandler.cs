using ConsoleApplicationBuilder.Helpers;
using ConsoleOutputEngine.Contracts;
using RunningLine.Contracts;
using RunningLine.Implementations.OutputFormatter;
using RunningLineEngine.Models;

namespace RunningLine.Implementations;

internal class DefaultDisplayHandler
{
    private readonly IConsoleOutput _output = IConsoleOutput.Create();

    private readonly IRunningLineArgsOutputFormatter _formatter = new RunningLineArgsOutputFormatter();

    public void Clean()
    {
        _output.PositionLeft = 0;
        _output.Out(new string(' ', Console.BufferWidth / 5));
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
