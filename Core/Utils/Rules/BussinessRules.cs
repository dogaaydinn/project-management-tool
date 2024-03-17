using Core.ExceptionHandling;
using Core.Extensions;
using Core.Models.Entities.Abstract;

namespace Core.Utils.Rules;

public class BusinessRules
{
    public static void Run(params (string errCode, string? msg)[] checkResults)
    {
        foreach (var (errCode, msg) in checkResults)
            if (!string.IsNullOrEmpty(msg))
                throw new ValidationException(errCode, msg);
    }

    public static string? CheckEntityNull<TEntity>(TEntity? obj, string customError)
        where TEntity : IEntity
    {
        if (obj is not null) return null;

        if (string.IsNullOrEmpty(customError))
            customError = BusinessRulesMessages.NullObjectPassed;

        return customError;
    }

    public static string? CheckEntityNull<TEntity>(TEntity? obj)
        where TEntity : IEntity
    {
        return CheckEntityNull(obj, $"{typeof(TEntity).Name} Not Found!");
    }

    public static string? CheckDtoNull<TDto>(TDto? obj, string customError = BusinessRulesMessages.NullObjectPassed)
        where TDto : IDto
    {
        if (obj is not null) return null;

        if (string.IsNullOrEmpty(customError))
            customError = BusinessRulesMessages.NullObjectPassed;

        return customError;
    }

    public static string? CheckId<TEntity>(TEntity obj)
        where TEntity : IEntity
    {
        if (obj is EntityBase entity)
            return CheckId(entity.Id.ToString());

        return null;
    }

    public static string? CheckId(Guid? id, bool allowNull = false)
    {
        if (allowNull) return null;

        return id is not null ? null : BusinessRulesMessages.EntityIdCannotBeBlank;
    }

    public static string? CheckId(string? id, bool allowNull = false)
    {
        if (allowNull) return null;

        if (string.IsNullOrEmpty(id)) return BusinessRulesMessages.EntityIdCannotBeBlank;

        return id.IsValidGuid() ? null : BusinessRulesMessages.IdFormatIsNotValid;
    }

    public static string? CheckEmail(string email)
    {
        return !email.IsValidEmail() ? BusinessRulesMessages.EmailFormatIsNotValid : null;
    }

    public static string? CheckStringNullOrEmpty(string? str, string? customError = null)
    {
        if (string.IsNullOrEmpty(str))
            return string.IsNullOrEmpty(customError) ? BusinessRulesMessages.StringCannotBeNullOrEmpty : customError;

        return null;
    }
}