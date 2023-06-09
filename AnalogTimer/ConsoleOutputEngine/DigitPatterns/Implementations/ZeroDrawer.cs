﻿using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.DigitPatterns.Implementations;

internal class ZeroDrawer : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "████████",
        "█      █",
        "█      █",
        "█      █",
        "█      █",
        "█      █",
        "████████",
    };
}
