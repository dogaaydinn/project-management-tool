namespace Core.Services.Messages;

public abstract class ServiceMessage(string code, string? description)
{
    public string Code { get; set; } = code;

    public string? Description { get; set; } = description;
    public bool IsWarning { get; set; }
    public bool IsSuccess { get; set; }
    public bool IsError { get; set; }
}