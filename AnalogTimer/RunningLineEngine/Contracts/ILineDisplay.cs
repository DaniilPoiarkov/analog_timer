namespace RunningLineEngine.Contracts;

public interface ILineDisplay
{
    void Display(IEnumerable<string> text, int position);

    void Clean();
}
