using RunningLineEngine.Contracts;

namespace RunningLineEngine.Implementations;

public class RunningLine : IRunningLine
{
    private int _speedCoefficient;

    public bool IsRunning { get; private set; }

    private Func<string, Task>? Runner { get; set; }

    private Task? Execution { get; set; }

    private string? Sentence { get; set; }

    private readonly ILineDisplay _lineDisplay;

    public RunningLine(ILineDisplay lineDisplay)
    {
        _speedCoefficient = 50;
        _lineDisplay = lineDisplay;

    }

    public void ChangeSpeed(int coefficient)
    {
        _speedCoefficient = coefficient;
    }

    private async Task RunTemplate(string sentence)
    {
        var width = Console.BufferWidth - 1;

        var index = 1;
        var start = 0;

        while (start != sentence.Length && IsRunning)
        {
            await Task.Delay(_speedCoefficient);

            var partial = sentence[..index];
            _lineDisplay.Display(partial, width);

            start++;
            index++;
            width--;
        }

        while (width != 0 && IsRunning)
        {
            await Task.Delay(_speedCoefficient);
            _lineDisplay.Display(sentence, width);

            width--;
        }

        index = 1;

        while (width > sentence.Length * -1 && IsRunning)
        {
            await Task.Delay(_speedCoefficient);

            sentence = sentence[index..];
            _lineDisplay.Display(sentence, 0);

            width--;
            index++;
        }

        if (!IsRunning)
        {
            return;
        }
        
        await Task.Delay(_speedCoefficient);
        _lineDisplay.Display(string.Empty, 0);

        Console.CursorLeft = 0;
    }

    public async Task Stop()
    {
        if (Execution is null || !IsRunning)
        {
            throw new InvalidOperationException("Line is not running");
        }

        IsRunning = false;

        await Execution;

        Runner = null;
        Execution = null;
    }

    public void Set(string sentence)
    {
        Sentence = sentence;
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

        Runner = RunTemplate;
        IsRunning = true;

        Execution = Runner.Invoke(Sentence);
    }

    public void Clean()
    {
        Console.CursorLeft = 0;
        Console.CursorTop = 1;
        Console.Write(new string(' ', Console.BufferWidth));
    }
}
