﻿using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

internal class EmptyLetter : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "      ",
        "      ",
        "      ",
        "      ",
        "      ",
    };
}