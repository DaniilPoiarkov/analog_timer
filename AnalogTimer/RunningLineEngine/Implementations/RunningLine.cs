using RunningLineEngine.Contracts;
using NLog;
using RunningLineEngine.Models;

namespace RunningLineEngine.Implementations;

public class RunningLine : IRunningLine
{
    private int _speedCoefficient;
    public int TicksPerSecond => _speedCoefficient;


    private bool IsCleaned = false;
    public bool IsRunning { get; private set; }

    private Func<Task>? Runner { get; set; }

    private Task? Execution { get; set; }


    private int SentenceLength { get; set; }


    private static int _maxWindowWidth;
    private static int BasePosition => _maxWindowWidth - 1;
    private int Position { get; set; }


    private int Index { get; set; } = 1;
    private int LastIndex { get; set; } = 1;


    public event EventHandler<RunningLineEventArgs>? Move;

    public event EventHandler<EventArgs>? CleanEvent;


    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public RunningLine(RunningLineConfiguration configuration)
    {
        _speedCoefficient = 10;
        _maxWindowWidth = configuration.MaxWindowWidth;

        Position = BasePosition;
    }

    public void ChangeSpeed(int coefficient)
    {
        _speedCoefficient = coefficient;
    }

    private async Task RunTemplate()
    {
        try
        {
            if (SentenceLength < _maxWindowWidth)
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
        if (Position == BasePosition)
        {
            Index = 1;
        }

        while (Position > 0 && IsRunning)
        {
            await Task.Delay(_speedCoefficient);

            Move?.Invoke(this, new RunningLineEventArgs
            {
                Position = Position,
                IndexEnd = Index,
            });

            Index++;
            Position--;
        }

        if (Position == 0)
        {
            Index = 1;
            LastIndex = SentenceLength - (SentenceLength - _maxWindowWidth);
        }

        while (Position > SentenceLength * -1 && IsRunning)
        {
            await Task.Delay(_speedCoefficient);
            
            var args = SentenceLength <= _maxWindowWidth
                ? new RunningLineEventArgs()
                : new RunningLineEventArgs { IndexEnd = LastIndex };

            args.IndexStart = Index;
            args.Position = Position;

            Move?.Invoke(this, args);

            Index++;

            if (LastIndex < SentenceLength)
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
        while (BasePosition - SentenceLength < Position && IsRunning)
        {
            await Task.Delay(_speedCoefficient);

            Move?.Invoke(this, new RunningLineEventArgs
            {
                Position = Position,
                IndexEnd = Index,
            });

            Index++;
            Position--;
        }

        while (Position > 0 && IsRunning)
        {
            await Task.Delay(_speedCoefficient);
            
            Move?.Invoke(this, new RunningLineEventArgs
            {
                Position = Position
            });

            Position--;
        }

        if (Position == 0)
        {
            Index = 1;
        }

        while (Position > SentenceLength * -1 && IsRunning)
        {
            await Task.Delay(_speedCoefficient);

            Move?.Invoke(this, new RunningLineEventArgs
            {
                Position = Position,
                IndexStart = Index,
            });

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

    public void Set(int sentenceLength)
    {
        if (IsRunning)
        {
            throw new Exception("Cannot update sentence in when line is running.");
        }

        SentenceLength = sentenceLength;

        Clean();
    }

    public void Start()
    {
        if (IsRunning)
        {
            throw new InvalidOperationException("Line is already running");
        }

        if (SentenceLength <= 0)
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

        CleanEvent?.Invoke(this, EventArgs.Empty);

        Runner = null;
        Position = BasePosition;
        Index = 1;
        IsCleaned = true;
    }
}
