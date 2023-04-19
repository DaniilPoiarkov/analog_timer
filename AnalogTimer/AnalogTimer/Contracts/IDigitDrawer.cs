namespace AnalogTimer.Contracts;

public interface IDigitDrawer
{
    void Draw(int positionLeft, ITimerTemplate template);

    void DrawFromPrevious(int positionLeft, ITimerTemplate template);
}
