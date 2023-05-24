using AnalogTimer.ConsoleApplications;

Console.WriteLine("Write '1' or '2' to select an application type:\n" +
    "1. Analog Timer\n" +
    "2. Running line");

var input = Console.ReadKey()
    .KeyChar
    .ToString();

Console.Clear();

if (!int.TryParse(input, out var choice)
    || choice < 1
    || choice > 2)
{
    Console.WriteLine("Invalid choice.");
    return;
}

if (choice == 1)
{
    var timerApp = new AnalogTimerApplication();
    await timerApp.Run();
}
if (choice == 2)
{
    var runningLineApp = new RunningLineApplication();
    await runningLineApp.Run();
}
