using AnalogTimer.Contracts;
using AnalogTimer.Helpers;

namespace AnalogTimer.Implementations;

public class PromptService : IPromptService
{
    private readonly IEnumerable<IPrompt> _prompts;

    private readonly IAnalogTimer _analogTimer;
    
    private const int _inputLine = 9;

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
        string? input = GetUserInput();
        Console.CursorTop = _inputLine;
        Console.WriteLine(new string(' ', Console.BufferWidth));
        await Consume(input);
    }

    public async Task Consume(string input)
    {
        var values = input?
            .TrimEnd()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(v => v.ToLower())
            .ToList();

        if (values is null || !values.Any() || string.IsNullOrEmpty(input))
        {
            throw new Exception("Invalid input");
        }

        var prompt = _prompts.FirstOrDefault(p =>
                p.Name.ToLower().Equals(values[0])
             || p.Shortcut.ToLower().Equals(values[0]));

        if (prompt is null)
        {
            var name = values[0].StartsWith('-') ? "shortcut" : "name";

            throw new Exception($"Prompt with {name} \'{values[0]}\' not found",
                new Exception($"Input: \'{input}\', Values: {string.Join(' ', values)}"));
        }

        await prompt.Proceed(input, _analogTimer);
    }

    private static string GetUserInput()
    {
        Console.CursorTop = _inputLine;

        while (true)
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

            if(!char.IsControl(key.KeyChar))
                UIHelper.Add(key.KeyChar);
        }

        var input = UIHelper.GetInput();
        return input;
    }
}
