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
        if (filter.SubFilters != null && filter.SubFilters.Any())
        {
            Expression? subExpression = null;
            foreach (var subFilter in filter.SubFilters)
            {
                var subFilterExpression = BuildExpression(parameter, subFilter);
                if (subExpression == null)
                {
                    subExpression = subFilterExpression;
                }
                else
                {
                    subExpression = filter.Operation switch
                    {
                        "AndAlso" => Expression.AndAlso(subExpression, subFilterExpression),
                        "OrElse" => Expression.OrElse(subExpression, subFilterExpression),
                        _ => throw new NotSupportedException($"La operación lógica {filter.Operation} no es compatible.")
                    };
                }
            }
            return subExpression!;
        }
        else
        {
            var member = Expression.Property(parameter, filter.PropertyName);
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
