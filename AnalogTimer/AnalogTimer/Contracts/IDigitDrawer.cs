namespace AnalogTimer.Contracts;

public interface IDigitDrawer
{
    bool[,] Matrix { get; }

    void Draw(int positionLeft, ITimerTemplate template);

    void DrawDown(int positionLeft, ITimerTemplate template);

    void DrawUp(int positionLeft, ITimerTemplate template);
}
