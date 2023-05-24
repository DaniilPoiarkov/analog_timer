using RunningLineEngine.Contracts;

namespace RunningLineEngine.Implementations;

public class RunningLine : IRunningLine
{
    private int _speedCoefficient;

    public bool IsRunning { get; private set; }

    private Func<string, Task>? Runner { get; set; }

    private Task? Execution { get; set; }

    private string? Sentence { get; set; }

    public RunningLine()
    {
        _speedCoefficient = 50;
    }

    public void ChangeSpeed(int coefficient)
    {
        _speedCoefficient = coefficient;
    }

    private async Task RunTemplate(string sentence)
    {
        Console.CursorVisible = false;

        var width = Console.BufferWidth - 1;

        var index = 1;
        var start = 0;

        while (start != sentence.Length)
        {
            await Task.Delay(_speedCoefficient);

            var partial = sentence[..index];
            DisplaySentence(partial, width);

            start++;
            index++;
            width--;
        }

        while (width != 0)
        {
            await Task.Delay(_speedCoefficient);
            DisplaySentence(sentence, width);

            width--;
        }

        index = 1;

        while (width > sentence.Length * -1)
        {
            await Task.Delay(_speedCoefficient);

            sentence = sentence[index..];
            DisplaySentence(sentence, 0);

            width--;
            index++;
        }
        
        await Task.Delay(_speedCoefficient);
        DisplaySentence(string.Empty, 0);

        Console.CursorLeft = 0;
        Console.CursorVisible = true;
    }

    private static void DisplaySentence(string sentence, int positionLeft)
    {
        Console.CursorTop = 1;
        Console.CursorLeft = positionLeft;
        var toClean = Console.BufferWidth - positionLeft;
        Console.Write(new string(' ', toClean));

        Console.CursorTop = 1;
        Console.CursorLeft = positionLeft;
        Console.Write(sentence);
    }

    public async Task Stop()
    {
        if (Execution is null || !IsRunning)
        {
            throw new InvalidOperationException("Line is not running");
        }

        await Execution;

        Runner = null;
        Execution = null;
        IsRunning = false;
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
        Execution = Runner.Invoke(Sentence);

        IsRunning = true;
    }
}
