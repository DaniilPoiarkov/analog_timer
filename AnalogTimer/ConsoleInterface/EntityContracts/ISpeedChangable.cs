using ConsoleInterface.Contracts;

namespace ConsoleInterface.EntityContracts;

public interface ISpeedChangable
{
    void ChangeSpeed(int coefficient);
}
