﻿using AnalogTimer.Models;
using AnalogTimer.Models.Enums;

namespace AnalogTimer.Contracts;

public interface IDisplayService
{
    void Display(TimerState state);
}
