using AnalogTimer.Contracts;
using AnalogTimer.Helpers;

namespace AnalogTimer.Implementations;

public class PromptService : IPromptService
{
    private readonly IEnumerable<IPrompt> _prompts;

    private readonly IAnalogTimer _analogTimer;

    private const int _exceptionLine = 8;
    
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

        if (values is null || !values.Any())
        {
            Console.CursorTop = _exceptionLine;
            Console.WriteLine(new string(' ', Console.WindowWidth));

            Console.CursorTop = _exceptionLine;
            Console.WriteLine("Exception: Invalid input");
            return;
        }

        var prompt = _prompts.FirstOrDefault(p => p.Name.ToLower().Equals(values[0]?.ToLower()));

        if(prompt is null)
        {
            Console.CursorTop = _exceptionLine;
            Console.WriteLine(new string(' ', Console.WindowWidth));

            Console.CursorTop = _exceptionLine;
            Console.WriteLine($"Exception: Prompt with name \'{values[0]}\' not found");
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
                Console.CursorTop = _exceptionLine;
                Console.WriteLine(new string(' ', Console.WindowWidth));

                Console.CursorTop = _exceptionLine;
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
