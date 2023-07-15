using ConsoleApplicationBuilder.Models.Enums;

namespace ConsoleApplicationBuilder.Models.Exceptions;

internal class LexException : InvalidInputException
{
    public LexException(int position)
        : base(InputExceptionType.Lex, new InputExceptionInfo() { Position = position})
    {
    }
}
