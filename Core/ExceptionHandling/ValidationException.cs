using Core.Utils;

namespace Core.ExceptionHandling;

public class ValidationException : Exception
{
    public ValidationException()
    {
    }

    public ValidationException(string message) : base(message)
    {
    }

    public ValidationException(string code, string message) : base(message)
    {
        ExceptionCode = code;
    }

    public ValidationException(string message, Exception inner) : base(message, inner)
    {
    }

    public string ExceptionCode { get; set; } = ValidationConstants.DefaultValidationExceptionCode;
}