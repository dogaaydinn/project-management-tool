using Newtonsoft.Json;

namespace Core.Services.Result;

public class ServiceObjectResult<T> : ServiceResult
{
    [JsonProperty] public bool HasData { get; private set; }

    [JsonProperty] public T? Data { get; private set; }

    public void SetData(T? data, string? message = null)
    {
        if (data == null)
        {
            Fail(ServiceResultConstants.NotFound);
        }
        else
        {
            Data = data;
            DataType = typeof(T).Name;
            HasData = true;

            Success(message ?? ServiceResultConstants.Success);
        }
    }

    # region Fail Overloads

    public override void Fail()
    {
        base.Fail();
        Data = default;
        HasData = false;
    }

    public override void Fail(string code, string description)
    {
        base.Fail(code, description);
        Data = default;
        HasData = false;
    }

    public override void Fail(string description)
    {
        base.Fail(description);
        Data = default;
        HasData = false;
    }

    public override void Fail(ServiceResult? result)
    {
        base.Fail(result);
        Data = default;
        HasData = false;
    }

    public override void Fail(Exception ex)
    {
        base.Fail(ex);
        Data = default;
        HasData = false;
    }

    # endregion Fail Overloads
}