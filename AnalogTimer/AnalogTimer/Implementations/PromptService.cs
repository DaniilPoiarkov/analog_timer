using AnalogTimer.Contracts;
using AnalogTimer.Helpers;
using NLog;

namespace AnalogTimer.Implementations;

public class PromptService : IPromptService
{
    private readonly IEnumerable<IPrompt> _prompts;

    private readonly IAnalogTimer _analogTimer;

    private const int _exceptionLine = 8;
    
    private const int _inputLine = 9;

    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public PromptService(
        IEnumerable<IPrompt> prompts,
        IAnalogTimer analogTimer)
    {
        _prompts = prompts;
        _analogTimer = analogTimer;
    }

    public void DisplayPrompts()
    {
        Console.CursorTop = 12;

        foreach (var prompt in _prompts)
        {
            Console.WriteLine(prompt.Instruction);
        }
    }

    public async Task Run()
    {
        Console.CursorTop = _inputLine;

        while(true)
        {
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter)
                break;

            if (key.Key == ConsoleKey.Backspace)
            {
                UIHelper.RemoveLast();
                Console.CursorLeft = UIHelper.CursorPosition;
                Console.Write(' ');
                Console.CursorLeft = UIHelper.CursorPosition;
                continue;
            }

            UIHelper.Add(key.KeyChar);
        }

        var input = UIHelper.GetInput();
        Console.CursorTop = _inputLine;
        Console.WriteLine(new string(' ', Console.BufferWidth));

        var values = input?
            .TrimEnd()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(v => v.ToLower())
            .ToList();

        if (values is null || !values.Any() || string.IsNullOrEmpty(input))
        {
            PrintException("Invalid input");
            return;
        }

        var prompt = _prompts.FirstOrDefault(p => 
                p.Name.ToLower().Equals(values[0])
             || p.Shortcut.ToLower().Equals(values[0]));

        if (prompt is null)
        {
            var name = values[0].StartsWith('-') ? "shortcut" : "name";

            PrintException($"Prompt with {name} \'{values[0]}\' not found",
                new Exception($"Input: \'{input}\', Values: {string.Join(' ', values)}"));

            return;
        }

        try
        {
            await prompt.Proceed(input, _analogTimer);
        }
        catch (Exception ex)
        {
            lock (this)
            {
                PrintException(ex.Message, ex);
            }
        }
    }

    private void PrintException(string message, Exception? ex = null)
    {
        Console.CursorTop = _exceptionLine;
        Console.WriteLine(new string(' ', Console.WindowWidth));

        Console.CursorTop = _exceptionLine;
        Console.WriteLine($"Exception: {message}");
        _logger.Error(ex, message);
    }
}
