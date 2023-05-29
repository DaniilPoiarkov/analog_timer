using ConsoleInterface.Models.Enums;

namespace ConsoleInterface.Models.Exceptions;

internal class LexException : InvalidInputException
{
    public LexException(int position)
        : base(InputExceptionType.Lex, new InputExceptionInfo() { Position = position})
    {
    }
}
