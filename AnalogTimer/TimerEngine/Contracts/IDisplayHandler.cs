using AnalogTimer.Models.Enums;

namespace AnalogTimer.Contracts;

// TODO: Rework + remove
public interface IDisplayHandler
{
    void Update(int digit, TimerValue value);
}
