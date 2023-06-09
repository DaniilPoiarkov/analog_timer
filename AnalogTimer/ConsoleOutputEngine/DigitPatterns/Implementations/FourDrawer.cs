﻿using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.DigitPatterns.Implementations;

internal class FourDrawer : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "█      █",
        "█      █",
        "█      █",
        "████████",
        "       █",
        "       █",
        "       █",
    };
}