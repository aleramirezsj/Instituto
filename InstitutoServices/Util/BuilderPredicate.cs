using InstitutoServices.Class;
using System.Linq.Expressions;

public static class BuilderPredicate
{
    public static Expression<Func<T, bool>> GetExpression<T>(List<FilterDTO> filters)
    {
        if (filters == null || !filters.Any())
            return x => true;

        var parameter = Expression.Parameter(typeof(T), "x");
        Expression? expression = null;

        foreach (var filter in filters)
        {
            var filterExpression = BuildExpression(parameter, filter);
            if (expression == null)
            {
                expression = filterExpression;
            }
            else
            {
                expression = Expression.AndAlso(expression, filterExpression);
            }
        }

        return Expression.Lambda<Func<T, bool>>(expression!, parameter);
    }

    private static Expression BuildExpression(ParameterExpression parameter, FilterDTO filter)
    {
        if (string.IsNullOrWhiteSpace(filter.PropertyName))
        {
            if (filter.SubFilters == null || !filter.SubFilters.Any())
                throw new ArgumentException("FilterDTO with empty PropertyName must have SubFilters.");

            Expression? combinedExpression = null;
            foreach (var subFilter in filter.SubFilters)
            {
                var subExpression = BuildExpression(parameter, subFilter);
                if (combinedExpression == null)
                {
                    combinedExpression = subExpression;
                }
                else
                {
                    combinedExpression = filter.Operation switch
                    {
                        "AndAlso" => Expression.AndAlso(combinedExpression, subExpression),
                        "OrElse" => Expression.OrElse(combinedExpression, subExpression),
                        _ => throw new NotSupportedException($"Operación lógica no soportada: {filter.Operation}")
                    };
                }
            }
            return combinedExpression!;
        }
        else
        {
            Expression member = parameter;
            foreach (var property in filter.PropertyName.Split('.'))
            {
                member = Expression.Property(member, property);
            }

            var constant = GetConstantExpression(filter.Value, member.Type);

            return filter.Operation switch
            {
                "Equals" => Expression.Equal(member, constant),
                "NotEquals" => Expression.NotEqual(member, constant),
                "GreaterThan" => Expression.GreaterThan(member, constant),
                "GreaterThanOrEquals" => Expression.GreaterThanOrEqual(member, constant),
                "LessThan" => Expression.LessThan(member, constant),
                "LessThanOrEquals" => Expression.LessThanOrEqual(member, constant),
                "Contains" => Expression.Call(member, typeof(string).GetMethod("Contains", new[] { typeof(string) })!, constant),
                "StartsWith" => Expression.Call(member, typeof(string).GetMethod("StartsWith", new[] { typeof(string) })!, constant),
                "EndsWith" => Expression.Call(member, typeof(string).GetMethod("EndsWith", new[] { typeof(string) })!, constant),
                _ => throw new NotSupportedException($"Operación no soportada: {filter.Operation}")
            };
        }
    }

    private static Expression GetConstantExpression(string? value, Type targetType)
    {
        if (string.IsNullOrEmpty(value))
            return Expression.Constant(null, targetType);

        // Handle Convert(value, type) pattern
        if (value.StartsWith("Convert(") && value.EndsWith(")"))
        {
            var content = value.Substring(8, value.Length - 9);
            var parts = content.Split(new[] { ',' }, 2);
            if (parts.Length == 2)
            {
                value = parts[0].Trim();
            }
        }

        // Handle Enum types
        if (targetType.IsEnum)
        {
            // Try to parse the numeric value
            if (int.TryParse(value, out int enumValue))
            {
                var enumResult = Enum.ToObject(targetType, enumValue);
                return Expression.Constant(enumResult, targetType);
            }
            // If it's not a number, try parsing the enum string value
            return Expression.Constant(Enum.Parse(targetType, value), targetType);
        }

        // Handle nullable Enum types
        if (targetType.IsGenericType &&
            targetType.GetGenericTypeDefinition() == typeof(Nullable<>) &&
            Nullable.GetUnderlyingType(targetType)?.IsEnum == true)
        {
            var underlyingType = Nullable.GetUnderlyingType(targetType);
            if (underlyingType != null)
            {
                // Try to parse the numeric value
                if (int.TryParse(value, out int enumValue))
                {
                    var enumResult = Enum.ToObject(underlyingType, enumValue);
                    return Expression.Constant(enumResult, targetType);
                }
                // If it's not a number, try parsing the enum string value
                return Expression.Constant(Enum.Parse(underlyingType, value), targetType);
            }
        }

        // Handle other nullable types
        if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            var underlyingType = Nullable.GetUnderlyingType(targetType);
            if (underlyingType != null)
            {
                var convertedValue = Convert.ChangeType(value, underlyingType);
                return Expression.Constant(convertedValue, targetType);
            }
        }

        var directConvertedValue = Convert.ChangeType(value, targetType);
        return Expression.Constant(directConvertedValue, targetType);
    }
}