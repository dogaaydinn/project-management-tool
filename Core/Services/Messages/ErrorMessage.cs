namespace Core.Services.Messages;

public class ErrorMessage : ServiceMessage
{
    public ErrorMessage(string? code, string? description) : base(code, description)
    {
        IsError = true;
    }
}