using AnalogTimer.Helpers;
using NLog;

namespace AnalogTimer;

internal abstract class ConsoleApplication
{
    protected const int _inputLine = 9;

    protected const int _exceptionLine = 8;

    protected readonly Logger _logger = LogManager.GetCurrentClassLogger();

    protected static string GetUserInput()
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

            if (!char.IsControl(key.KeyChar))
                UIHelper.Add(key.KeyChar);
        }

        return UIHelper.GetInput();
    }

    protected void PrintException(string message, Exception? ex = null)
    {
        Console.CursorTop = _exceptionLine;
        Console.WriteLine(new string(' ', Console.WindowWidth));

        Console.CursorTop = _exceptionLine;
        Console.WriteLine($"Exception: {message}");
        _logger.Error(ex, message);
    }

    public async Task Run()
    {
        DisplayInstruction();

        while (true)
        {
            try
            {
                string? input = GetUserInput();
                Console.CursorTop = _inputLine;
                Console.WriteLine(new string(' ', Console.BufferWidth));
                await HandleUserInput(input);
            }
            catch (Exception ex)
            {
                lock (this)
                {
                    PrintException(ex.Message, ex);
                }
            }
        }
    }

    protected abstract void DisplayInstruction();

    protected abstract Task HandleUserInput(string? input);
}
