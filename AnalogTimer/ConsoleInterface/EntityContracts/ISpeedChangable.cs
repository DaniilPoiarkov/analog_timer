namespace ConsoleInterface.EntityContracts;

public interface ISpeedChangable
{
    void ChangeSpeed(int coefficient);

    int TicksPerSecond { get; }
}
