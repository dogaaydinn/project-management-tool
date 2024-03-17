namespace Core.Services.Messages;

public class WarningMessage : ServiceMessage
{
    public WarningMessage(string? code, string? description) : base(code, description)
    {
        IsWarning = true;
    }
}