using RunningLineEngine.Contracts;
using RunningLineEngine.LetterPatterns.Implementations;

namespace RunningLineEngine.Implementations;

public class RunningLine : IRunningLine
{
    private int _speedCoefficient;

    public bool IsRunning { get; private set; }

    private Func<string, Task>? Runner { get; set; }

    private Task? Execution { get; set; }

    private string? Sentence { get; set; }

    private IEnumerable<List<string>> _sentencePatterns;


    private readonly ILineDisplay _lineDisplay;

    private bool IsCleaned = false;

    private int Position { get; set; }

    public int TicksPerSecond => _speedCoefficient;

    public RunningLine(ILineDisplay lineDisplay)
    {
        _speedCoefficient = 50;
        _lineDisplay = lineDisplay;
        Position = Console.BufferWidth - 1;
        _sentencePatterns = new List<List<string>>();
    }

    public void ChangeSpeed(int coefficient)
    {
        _speedCoefficient = coefficient;
    }

    private async Task RunTemplate(string sentence)
    {
        while (IsRunning)
        {
            var index = 1;

            while (IsRunning && Console.BufferWidth - 1 - sentence.Length < Position)
            {
                await Task.Delay(_speedCoefficient);

                var partial = _sentencePatterns.Take(index);
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

            while (Position > sentence.Length * -1 && IsRunning)
            {
                await Task.Delay(_speedCoefficient);

                var partial = _sentencePatterns.Skip(index);
                _lineDisplay.Display(partial, 0);

                Position--;
                index++;
            }

            if (IsRunning)
            {
                await Task.Delay(_speedCoefficient);
                _lineDisplay.Display(new List<List<string>>(), 0);

                Console.CursorLeft = 0;
                Position = Console.BufferWidth - 1;
                await RunTemplate(sentence);
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

        _sentencePatterns = new List<List<string>>()
        {
            new LetterA().Pattern,
            new LetterB().Pattern,
            new LetterC().Pattern,
            new LetterD().Pattern,
        };
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

        Execution = Runner.Invoke(Sentence);
    }

    public void Clean()
    {
        if (IsRunning)
        {
            throw new InvalidOperationException("Cannot clean line when it's running.");
        }

        Console.CursorLeft = 0;
        Console.CursorTop = 1;
        Console.Write(new string(' ', Console.BufferWidth));

        Runner = null;
        Position = Console.BufferWidth - 1;
        IsCleaned = true;
    }
}
