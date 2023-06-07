using RunningLineEngine.Contracts;
using ConsoleInterface.Helpers;
using RunningLineEngine.LetterPatterns;

namespace RunningLineEngine.Implementations;

public class RunningLine : IRunningLine
{
    private int _speedCoefficient;

    public bool IsRunning { get; private set; }

    private Func<Task>? Runner { get; set; }

    private Task? Execution { get; set; }

    private string? Sentence { get; set; }

    private List<string> _sentencePatterns;


    private readonly ILineDisplay _lineDisplay;

    private bool IsCleaned = false;

    private int Position { get; set; }

    public int TicksPerSecond => _speedCoefficient;

    public RunningLine(ILineDisplay lineDisplay)
    {
        _speedCoefficient = 10;
        _lineDisplay = lineDisplay;
        Position = Console.BufferWidth - 1;
        _sentencePatterns = new List<string>();
    }

    public void ChangeSpeed(int coefficient)
    {
        _speedCoefficient = coefficient;
    }

    private async Task RunTemplate()
    {
        while (IsRunning)
        {
            var index = 1;

            var sentenceLength = _sentencePatterns.First().Length;

            while (IsRunning && Console.BufferWidth - 1 - sentenceLength < Position)
            {
                await Task.Delay(_speedCoefficient);

                var partial = _sentencePatterns.Select(p => p[..index]);

                _lineDisplay.Display(partial, Position);

                index++;
                Position--;
            }

            while (Position != 0 && IsRunning)
            {
                await Task.Delay(_speedCoefficient);
                _lineDisplay.Display(_sentencePatterns, Position);

                Position--;
            }

            index = 1;

            while (Position > sentenceLength * -1 && IsRunning)
            {
                await Task.Delay(_speedCoefficient);

                var partial = _sentencePatterns.Select(p => p[index..]);
                _lineDisplay.Display(partial, 0);

                Position--;
                index++;
            }

            if (IsRunning)
            {
                await Task.Delay(_speedCoefficient);

                Console.CursorLeft = 0;
                Position = Console.BufferWidth - 1;
                await RunTemplate();
            }
        }
    }

    public async Task Stop()
    {
        if (Execution is null || !IsRunning)
        {
            throw new InvalidOperationException("Line is not running");
        }

        IsRunning = false;

        await Execution;

        Execution = null;
    }

    public void Set(string sentence)
    {
        Sentence = sentence;

        _sentencePatterns = sentence.ToUpper()
            .Select(LetterPatternProvider.Get)
            .Select(p => p.Pattern)
            .AggregateToDisplayModel();
    }

    public void Start()
    {
        if (IsRunning)
        {
            throw new InvalidOperationException("Line is already running");
        }

        if (string.IsNullOrEmpty(Sentence))
        {
            throw new InvalidDataException("No sentence provided");
        }

        IsRunning = true;

        if (IsCleaned || Runner is null)
        {
            Runner = RunTemplate;
            IsCleaned = false;
        }

        Execution = Runner.Invoke();
    }

    public void Clean()
    {
        if (IsRunning)
        {
            throw new InvalidOperationException("Cannot clean line when it's running.");
        }

        _lineDisplay.Clean();

        Runner = null;
        Position = Console.BufferWidth - 1;
        IsCleaned = true;
    }
}
