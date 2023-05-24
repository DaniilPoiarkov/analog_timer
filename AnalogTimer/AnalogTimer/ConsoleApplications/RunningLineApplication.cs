namespace AnalogTimer.ConsoleApplications;

internal class RunningLineApplication : ConsoleApplication
{
    protected override void DisplayInstruction()
    {
        Console.WriteLine("Write any sentence and watch how it's going!");
    }

    protected override async Task HandleUserInput(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        var consoleWidth = Console.BufferWidth - input.Length;

        while (consoleWidth != 0)
        {
            Console.CursorTop = 2;
            Console.Write(input);
            consoleWidth--;
            await Task.Delay(100);
            Console.CursorLeft = consoleWidth;
            Console.Write(new string(' ', consoleWidth));
        }
    }
}
