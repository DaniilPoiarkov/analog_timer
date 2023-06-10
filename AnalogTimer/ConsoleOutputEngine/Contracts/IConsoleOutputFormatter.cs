namespace ConsoleOutputEngine.Contracts;

public interface IConsoleOutputFormatter
{
    IEnumerable<string> Format(IEnumerable<string> pattern);
}
