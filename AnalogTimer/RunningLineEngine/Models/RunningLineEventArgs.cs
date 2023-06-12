namespace RunningLineEngine.Models;

public class RunningLineEventArgs
{
    public int Position { get; internal set; }

    public int IndexStart { get; internal set; }

    public int IndexEnd { get; internal set; }
}
