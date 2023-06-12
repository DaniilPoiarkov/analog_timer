namespace RunningLineEngine.Contracts;

public interface IRunningLineSpeed
{
    void ChangeSpeed(int coefficient);

    int TicksPerSecond { get; }
}
