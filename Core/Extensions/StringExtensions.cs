using System.Net.Mail;

namespace Core.Extensions;

public static class StringExtensions
{
    public static bool IsValidEmail(this string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public static bool IsValidGuid(this string guid)
    {
        return Guid.TryParse(guid, out _);
    }
}