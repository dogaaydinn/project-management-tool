namespace Core.Services.Messages;

public class SuccessMessage : ServiceMessage
{
    public SuccessMessage(string? code, string? description) : base(code, description)
    {
        IsSuccess = true;
    }
}