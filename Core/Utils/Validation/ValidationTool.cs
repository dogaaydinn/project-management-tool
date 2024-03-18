using FluentValidation;
using ValidationException = Core.ExceptionHandling.ValidationException;

namespace Core.Utils.Validation.FluentValidation;

public class ValidationTool
{
    public static void Validate(IValidator validator, object entity)
    {
        var context = new ValidationContext<object>(entity);
        var result = validator.Validate(context);

        if (!result.IsValid)
            throw new ValidationException(
                result.Errors.FirstOrDefault()?.ErrorMessage ?? ValidationConstants.DefaultValidationExceptionMessage,
                ValidationConstants.DefaultValidationExceptionCode);
    }
}