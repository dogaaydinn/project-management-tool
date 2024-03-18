using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;
using Core.Models.Entities.Abstract;
using Core.Services;

namespace Core.Extensions;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>>? ToExpression<T>(this IServiceFilterModel<T> modelBase)
        where T : class, IEntity, new()
    {
        Expression<Func<T, bool>>? expression = null;

        object? result = null;
        var argParam = Expression.Parameter(typeof(T), "p");

        var objProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var calculatedDates = new List<string>();
        foreach (var prop in modelBase.GetType().GetProperties())
        {
            if (prop.GetCustomAttribute(typeof(NotMappedAttribute)) is not null)
                continue;

            var propVal = prop.GetValue(modelBase);
            if (propVal is null)
                continue;

            Expression? exp = null;
            Expression? expProp;

            switch (prop.PropertyType.Name)
            {
                case nameof(DateTime):
                    var isLow = prop.Name.EndsWith("Low");
                    var isHigh = prop.Name.EndsWith("High");
                    if (isLow || isHigh)
                    {
                        var name = prop.Name.Replace("Low", "").Replace("High", "");

                        if (objProperties.Any(p => p.Name == name))
                            if (!calculatedDates.Contains(name))
                            {
                                calculatedDates.Add(name);

                                var lowValue = isLow
                                    ? propVal
                                    : modelBase.GetType().GetProperty($"{name}Low")?.GetValue(modelBase);
                                var highValue = isLow
                                    ? modelBase.GetType().GetProperty($"{name}High")?.GetValue(modelBase)
                                    : propVal;

                                expProp = Expression.Property(argParam, name);
                                var expLowConst = Expression.Constant(lowValue);
                                var expHighConst = Expression.Constant(highValue);

                                if (lowValue is not null && highValue is not null
                                                         && (DateTime)lowValue != DateTime.MinValue &&
                                                         (DateTime)highValue != DateTime.MinValue)
                                {
                                    Expression expLow = Expression.GreaterThanOrEqual(expProp, expLowConst);
                                    Expression expHigh = Expression.LessThanOrEqual(expProp, expHighConst);
                                    exp = Expression.AndAlso(expLow, expHigh);
                                }
                                else
                                {
                                    if (lowValue is not null && (DateTime)lowValue != DateTime.MinValue)
                                        exp = Expression.GreaterThanOrEqual(expProp, expLowConst);
                                    else if (highValue is not null && (DateTime)highValue != DateTime.MinValue)
                                        exp = Expression.LessThanOrEqual(expProp, expHighConst);
                                }
                            }
                    }

                    break;

                default:
                    var isQueryStr = false;

                    var propName = prop.Name;
                    if (propVal is string && prop.Name.EndsWith("Query"))
                    {
                        propName = prop.Name.Replace("Query", "");
                        isQueryStr = true;
                    }

                    if (objProperties.Any(p => p.Name == propName))
                    {
                        expProp = Expression.Property(argParam, propName);

                        if (isQueryStr)
                        {
                            var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                            var someValue = Expression.Constant(propVal, typeof(string));

                            if (method != null)
                                exp = Expression.Call(expProp, method, someValue).Reduce();
                        }
                        else
                        {
                            var expConst = Expression.Constant(propVal);
                            exp = Expression.Equal(expProp, expConst);
                        }
                    }

                    break;
            }

            if (exp is not null)
                result = result is null
                    ? exp
                    : Expression.AndAlso((Expression)result, exp);
        }

        if (result is not null) expression = Expression.Lambda<Func<T, bool>>((Expression)result, argParam);

        return expression;
    }
}