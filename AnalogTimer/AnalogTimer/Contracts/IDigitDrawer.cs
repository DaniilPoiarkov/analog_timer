﻿namespace AnalogTimer.Contracts;

public interface IDigitDrawer
{
    List<List<char>> Matrix { get; }

    List<string> Pattern { get; }

    void Draw(int positionLeft, ITimerTemplate template);

    void DrawDown(int positionLeft, ITimerTemplate template);

    void DrawUp(int positionLeft, ITimerTemplate template);
}
