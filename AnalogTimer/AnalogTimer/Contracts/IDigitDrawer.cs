namespace AnalogTimer.Contracts;

public interface IDigitDrawer
{
    void Draw(int positionLeft, ITimerTemplate template);

    void DrawDown(int positionLeft, ITimerTemplate template);

    void DrawUp(int positionLeft, ITimerTemplate template);
}
