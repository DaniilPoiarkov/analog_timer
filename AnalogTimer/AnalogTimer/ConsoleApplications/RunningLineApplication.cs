namespace AnalogTimer.ConsoleApplications;

internal class RunningLineApplication : ConsoleApplication
{
    protected override void DisplayInstruction()
    {
        Console.WriteLine("Write any sentence and watch how it's going!");
    }

    protected override Task HandleUserInput(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Invalid input!");
            return Task.CompletedTask;
        }



        return Task.CompletedTask;
    }
}
