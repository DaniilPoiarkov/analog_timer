using ConsoleApplicationBuilder.Helpers;
using ConsoleOutputEngine.Contracts;
using ConsoleOutputEngine.Helpers;
using RunningLine.Contracts;
using RunningLine.Patterns;
using RunningLineEngine.Models;

namespace RunningLine.Implementations;

internal class DefaultDisplayHandler
{
    private readonly IConsoleOutput _output = IConsoleOutput.Create();

    private readonly IRunningLineArgsOutputFormatter _formatter = new RunningLineArgsOutputFormatter();

    private readonly Dictionary<string, List<string>> _mapper = new();

    public void Clean()
    {
        var pattern = GetOrCreate(new string(' ', Console.BufferWidth / 5));

        _output.PositionLeft = 0;
        _output.Out(pattern);
    }

    public int GetLength(string text)
    {
        var pattern = GetOrCreate(text);
        return pattern.First().Length;
    }

    public void Display(string text, RunningLineEventArgs args)
    {
        Clean();

        _output.PositionLeft = args.Position < 0 ? 0 : args.Position;

        _formatter.Update(args);

        var pattern = GetOrCreate(text);

        pattern = _formatter.Format(pattern).ToList();

        _output.Out(pattern);

        UIHelper.SetCursor();
    }

    private List<string> GetOrCreate(string text)
    {
        var normilized = text.ToUpper();
        var pattern = _mapper.GetValueOrDefault(normilized);

        if (pattern is not null)
        {
            return pattern;
        }

        
        pattern = normilized
            .Select(CharacterPatternProvider.Get)
            .Select(p => p.Pattern)
            .ToAggregateModel();

        _mapper.Add(normilized, pattern);

        return pattern;
    }
}
