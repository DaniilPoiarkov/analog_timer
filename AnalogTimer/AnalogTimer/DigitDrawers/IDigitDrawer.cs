using AnalogTimer.Contracts;

namespace AnalogTimer.DigitDrawers;

public interface IDigitDrawer
{
    void Draw(int positionLeft, ITimerTemplate template);
}
