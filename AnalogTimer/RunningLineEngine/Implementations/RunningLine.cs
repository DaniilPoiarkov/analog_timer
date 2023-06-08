using RunningLineEngine.Contracts;
using ConsoleInterface.Helpers;
using RunningLineEngine.LetterPatterns;
using NLog;

namespace RunningLineEngine.Implementations;

public class RunningLine : IRunningLine
{
    private int _speedCoefficient;
    public int TicksPerSecond => _speedCoefficient;


    public bool IsRunning { get; private set; }

    private Func<Task>? Runner { get; set; }

    private Task? Execution { get; set; }


    private string? Sentence { get; set; }

    private List<string> _sentencePatterns;


    private readonly ILineDisplay _lineDisplay;

    private bool IsCleaned = false;


    private int Position { get; set; }
    private static int BasePosition => Console.BufferWidth - 1;


    private int Index { get; set; } = 1;
    private int LastIndex { get; set; } = 1;


    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public RunningLine(ILineDisplay lineDisplay)
    {
        _speedCoefficient = 10;
        _lineDisplay = lineDisplay;
        Position = BasePosition;
        _sentencePatterns = new List<string>();
    }

    public void ChangeSpeed(int coefficient)
    {
        _speedCoefficient = coefficient;
    }

    private async Task RunTemplate()
    {
        var sentenceLength = _sentencePatterns.First().Length;

        try
        {
            if (sentenceLength < Console.BufferWidth)
            {
                while (IsRunning)
                {
                    await DisplayShortSentence();
                }
            }
            else
            {
                while (IsRunning)
                {
                    await DisplayLargeSentence();
                }
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }
    }

    private async Task DisplayLargeSentence()
    {
        var sentenceLength = _sentencePatterns.First().Length;

        if (Position == BasePosition)
        {
            Index = 1;
        }

        while (Position > 0 && IsRunning)
        {
            await Task.Delay(_speedCoefficient);

            var partial = _sentencePatterns.Select(p => p[..Index]);

            _lineDisplay.Display(partial, Position);

            Index++;
            Position--;
        }

        if (Position == 0)
        {
            Index = 1;
            LastIndex = sentenceLength - (sentenceLength - Console.BufferWidth);
        }

        while (Position > sentenceLength * -1 && IsRunning)
        {
            await Task.Delay(_speedCoefficient);
            
            var partial = _sentencePatterns
                .Select(p => p[Index..].Length <= Console.BufferWidth
                ? p[Index..]
                : p[Index..LastIndex]);

            _lineDisplay.Display(partial, 0);

            Index++;

            if (LastIndex < sentenceLength)
            {
                LastIndex++;
            }

            Position--;
        }

        if (IsRunning)
        {
            await Task.Delay(_speedCoefficient);
            Position = BasePosition;
        }
    }

    private async Task DisplayShortSentence()
    {
        var sentenceLength = _sentencePatterns.First().Length;

        while (BasePosition - sentenceLength < Position && IsRunning)
        {
            await Task.Delay(_speedCoefficient);

            var partial = _sentencePatterns.Select(p => p[..Index]);

            _lineDisplay.Display(partial, Position);

            Index++;
            Position--;
        }

        while (Position > 0 && IsRunning)
        {
            await Task.Delay(_speedCoefficient);
            _lineDisplay.Display(_sentencePatterns, Position);

            Position--;
        }

        if (Position == 0)
        {
            Index = 1;
        }

        while (Position > sentenceLength * -1 && IsRunning)
        {
            await Task.Delay(_speedCoefficient);

            var partial = _sentencePatterns.Select(p => p[Index..]);
            _lineDisplay.Display(partial, 0);

            Position--;
            Index++;
        }

        if (IsRunning)
        {
            await Task.Delay(_speedCoefficient);
            Position = BasePosition;
            Index = 1;
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
        if (IsRunning)
        {
            throw new Exception("Cannot update sentence in when line is running.");
        }

        Sentence = sentence;

        var matrix = sentence.ToUpper()
            .Select(LetterPatternProvider.Get)
            .Select(p => p.Pattern)
            .AggregateToDisplayModel();

        if (!matrix.Any())
        {
            throw new Exception("Empty sentence is not allowed");
        }

        _sentencePatterns = matrix;
        Clean();
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
        Position = BasePosition;
        Index = 1;
        IsCleaned = true;
    }
}
