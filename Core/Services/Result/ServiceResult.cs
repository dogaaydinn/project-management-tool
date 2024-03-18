using Core.ExceptionHandling;
using Core.Services.Messages;
using Core.Services.Payload;

namespace Core.Services.Result;

public abstract class ServiceResult
{
    public bool HasFailed { get; set; }
    public IList<ServiceMessage> Messages { get; set; } = new List<ServiceMessage>();
    public IList<ServicePayloadItem> ExtraData { get; set; } = new List<ServicePayloadItem>();
    public string? ResultCode { get; set; }
    public string? DataType { get; protected set; }
    public bool IsList { get; protected set; }

    # region Success

    private void Success(string code, string description)
    {
        Messages.Add(new SuccessMessage(code, description));
    }

    public void Success(string description)
    {
        Success("S", description);
    }

    # endregion Success

    # region Warning

    private void Warning(string code, string description)
    {
        Messages.Add(new WarningMessage(code, description));
    }

    public void Warning(string description)
    {
        Warning("W", description);
    }

    # endregion Warning

    # region Error

    public virtual void Fail()
    {
        HasFailed = true;
    }

    public virtual void Fail(ServiceMessage message)
    {
        Messages.Add(message);
        Fail();
    }

    public virtual void Fail(string code, string description)
    {
        Fail(new ErrorMessage(code, description));
    }

    public virtual void Fail(string description)
    {
        Fail("E", description);
    }

    public virtual void Fail(IList<ServiceMessage>? messages)
    {
        Fail(messages?.AsEnumerable());
    }

    public virtual void Fail(IEnumerable<ServiceMessage>? messages)
    {
        if (messages == null) return;
        var serviceMessages = messages.ToList();
        if (serviceMessages.Count == 0) return;
        foreach (var message in serviceMessages)
            Fail(message);
    }

    public void Fail(IEnumerable<IEnumerable<ServiceMessage>>? messages)
    {
        if (messages == null) return;

        var messagesEnumerable = messages.ToList();
        if (messagesEnumerable.Count == 0) return;
        foreach (var message in messagesEnumerable) Fail(message);
    }

    public virtual void Fail(ServiceResult? result)
    {
        Fail(result?.Messages);
    }

    public virtual void Fail(Exception ex)
    {
        switch (ex)
        {
            case ValidationException validationException:
                Fail(validationException);
                break;
            default:
                Fail(ex.Message);
                break;
        }
    }

    private void Fail(ValidationException validationException)
    {
        Fail(validationException.ExceptionCode, validationException.Message);
    }

    #endregion Error
}