﻿using AnalogTimer.Contracts;
using AnalogTimer.DigitDrawers;
using AnalogTimer.DisplayHandlers;
using AnalogTimer.Helpers;
using AnalogTimer.Models;
using AnalogTimer.Models.Enums;

namespace AnalogTimer.Implementations;

public class DisplayService : IDisplayService
{
    private readonly ITimerTemplate _timerTemplate;

    private TimerState? _snapshot;

    private IDisplayHandler _handler;

    private DisplayMode Mode { get; set; }

    private const int _dotsBetweenHourAndMinute = 23;

    private const int _dotsBetweenMinuteAndSecond = 49;

    private const int _dotsBetweenSecondsAndMilliseconds = 75;

    public DisplayService(ITimerTemplate timerTemplate)
    {
        _timerTemplate = timerTemplate;
        Mode = DisplayMode.Full;
        _handler = new MatrixDisplayHandler();

        PrintDots(_dotsBetweenHourAndMinute);
        PrintDots(_dotsBetweenMinuteAndSecond);
        PrintDots(_dotsBetweenSecondsAndMilliseconds);

        Display(new());
    }

    public void Display(TimerState state)
    {
        if (state.Hours != _snapshot?.Hours)
            _handler.Update(state.Hours, TimerValue.Hour);

        if (state.Minutes != _snapshot?.Minutes)
            _handler.Update(state.Minutes, TimerValue.Minute);

        if (state.Seconds != _snapshot?.Seconds)
            _handler.Update(state.Seconds, TimerValue.Second);

        if (state.Milliseconds != _snapshot?.Milliseconds)
            _handler.Update(state.Milliseconds, TimerValue.Millisecond);

        _snapshot = new(state.Hours, state.Minutes, state.Seconds, state.Milliseconds);
    }

    public void SetMode(DisplayMode mode)
    {
        Mode = mode;
    }

    public void ChangeHandler(DisplayHandler handler)
    {
        if (handler == DisplayHandler.ViaDrawer)
        {
            _handler = new DrawerDisplayHandler(_timerTemplate, _snapshot, Mode);
        }
        else
        {
            _handler = new MatrixDisplayHandler();
        }
    }

    private void PrintDots(int position)
    {
        Console.CursorTop = 2;
        Console.CursorLeft = position;

        Console.WriteLine(_timerTemplate.Pattern);

        Console.CursorTop = 5;
        Console.CursorLeft = position;

        Console.WriteLine(_timerTemplate.Pattern);
    }

    public async Task StartBackgroundDisplay(CancellationToken token)
    {
        const int position = 91;
        var handler = new MatrixDisplayHandler();

        while (!token.IsCancellationRequested)
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100, token);
                var drawer = DigitDrawerProvider.GetDrawer(i);
                handler.DisplayPattern(drawer.Pattern, position);
            }

            UIHelper.SetCursor();
        }
    }
}
