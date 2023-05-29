using ConsoleInterface.Models.Enums;

namespace ConsoleInterface.Models.Exceptions;

internal class InvalidInputException : Exception
{
    public InvalidInputException(InputExceptionType exceptionType, InputExceptionInfo? info = null, Exception? inner = null)
        : this
        (exceptionType switch
        {
            InputExceptionType.ClosureTag => $"Invalid or missing closure tag. Expected: {info!.Closure}.",
            InputExceptionType.Lex => $"An error occured when parsing word in {info!.Position!.Value} position.",
            _ => throw new ArgumentOutOfRangeException(nameof(exceptionType))
        }, inner) { }

    private InvalidInputException(string message, Exception? inner = null)
        : base(message, inner)
    {

    }
}
