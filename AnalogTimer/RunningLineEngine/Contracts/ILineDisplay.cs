namespace RunningLineEngine.Contracts;

public interface ILineDisplay
{
    void Display(IEnumerable<List<string>> text, int position);
}
