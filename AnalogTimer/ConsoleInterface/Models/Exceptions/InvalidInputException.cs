using ConsoleInterface.Models.Enums;

namespace ConsoleInterface.Models.Exceptions;

internal class InvalidInputException : Exception
{
    public InvalidInputException(InputExceptionType exceptionType, Exception? inner = null)
        : this
        (exceptionType switch
        {
            InputExceptionType.ClosureTag => "Invalid or missing closure tag",
            _ => throw new ArgumentOutOfRangeException(nameof(exceptionType))
        }, inner) { }

    private InvalidInputException(string message, Exception? inner = null) : base(message, inner)
    {

    }
}
