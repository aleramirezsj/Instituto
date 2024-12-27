using InstitutoServices.Class;
using System.Linq.Expressions;

public static class BuilderPredicate
{
    public static Expression<Func<T, bool>> GetExpression<T>(List<FilterDTO> filters)
    {
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

        return expression != null ? Expression.Lambda<Func<T, bool>>(expression, parameter) : x => true;
    }

    private static Expression BuildExpression(ParameterExpression parameter, FilterDTO filter)
    {
        if (string.IsNullOrWhiteSpace(filter.PropertyName))
        {
            if (filter.SubFilters == null || filter.SubFilters.Count == 0)
            {
                throw new ArgumentException("El FilterDTO con PropertyName vacío debe tener SubFilters.", nameof(filter.SubFilters));
            }

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
                        _ => throw new NotSupportedException($"La operación lógica {filter.Operation} no es compatible.")
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

            var constant = Expression.Constant(Convert.ChangeType(filter.Value, member.Type));

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
                _ => throw new NotSupportedException($"La operación {filter.Operation} no es compatible.")
            };
        }
    }
}
