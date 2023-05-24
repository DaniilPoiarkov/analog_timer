using RunningLineEngine.Contracts;

namespace RunningLineEngine.Implementations;

public class RunningLine : IRunningLine
{
    private int _speedCoefficient;

    public RunningLine()
    {
        _speedCoefficient = 100;
    }

    public void ChangeSpeed(int coefficient)
    {
        _speedCoefficient = coefficient;
    }

    public async Task Run(string sentence)
    {
        var width = Console.BufferWidth - sentence.Length;

        while (width != 0)
        {
            await Task.Delay(_speedCoefficient);
            DisplaySentence(sentence, width);

            width--;
        }

        while (width > sentence.Length)
        {
            await Task.Delay(_speedCoefficient);

            sentence = sentence[1..];
            DisplaySentence(sentence, width);

            width--;
        }
    }

    private static void DisplaySentence(string sentence, int width)
    {
        Console.CursorTop = 1;
        Console.CursorLeft = width;
        Console.Write(new string(' ', width + 1));

        Console.CursorTop = 1;
        Console.CursorLeft = width;
        Console.Write(sentence);
    }
}
