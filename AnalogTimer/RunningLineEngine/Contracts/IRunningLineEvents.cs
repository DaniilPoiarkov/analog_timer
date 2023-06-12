using RunningLineEngine.Models;

namespace RunningLineEngine.Contracts;

public interface IRunningLineEvents
{
    event EventHandler<RunningLineEventArgs> Move;

    event EventHandler<EventArgs> CleanEvent;
}
