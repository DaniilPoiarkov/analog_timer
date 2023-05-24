using AnalogTimer.Models.Enums;

namespace AnalogTimer.Contracts;

public interface IDisplayHandler
{
    void Update(int digit, TimerValue value);
}
