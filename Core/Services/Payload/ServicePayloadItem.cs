namespace Core.Services.Payload;

public class ServicePayloadItem(string key, object value)
{
    public string Key { get; set; } = key;
    public object Value { get; set; } = value;
}