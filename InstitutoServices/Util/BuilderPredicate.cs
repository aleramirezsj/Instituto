using InstitutoServices.Class;
using System.Linq.Expressions;

namespace InstitutoServices.Util
{
    public static class BuilderPredicate
    {
        public static Expression<Func<T, bool>> GetExpression<T>(List<FilterDTO> filters)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            Expression? body = null;
            Expression? currentExpression = null;

            foreach (var filter in filters)
            {
                if (string.IsNullOrEmpty(filter.PropertyName))
                {
                    // Es un conector lógico (AND/OR)
                    if (filter.Operation == "AndAlso" && currentExpression != null)
                    {
                        body = body == null ? currentExpression : Expression.AndAlso(body, currentExpression);
                    }
                    else if (filter.Operation == "OrElse" && currentExpression != null)
                    {
                        body = body == null ? currentExpression : Expression.OrElse(body, currentExpression);
                    }
                    currentExpression = null; // Resetear la expresión actual
                }
                else
                {
                    // Es una expresión de comparación
                    var property = GetPropertyExpression(parameter, filter.PropertyName);
                    var constant = Expression.Constant(Convert.ChangeType(filter.Value, property.Type));

                    currentExpression = filter.Operation switch
                    {
                        "Equals" => Expression.Equal(property, constant),
                        "NotEquals" => Expression.NotEqual(property, constant),
                        "GreaterThan" => Expression.GreaterThan(property, constant),
                        "GreaterThanOrEquals" => Expression.GreaterThanOrEqual(property, constant),
                        "LessThan" => Expression.LessThan(property, constant),
                        "LessThanOrEquals" => Expression.LessThanOrEqual(property, constant),
                        "Contains" => Expression.Call(property, typeof(string).GetMethod("Contains", new[] { typeof(string) })!, constant),
                        "StartsWith" => Expression.Call(property, typeof(string).GetMethod("StartsWith", new[] { typeof(string) })!, constant),
                        "EndsWith" => Expression.Call(property, typeof(string).GetMethod("EndsWith", new[] { typeof(string) })!, constant),
                        _ => throw new NotSupportedException($"Operation {filter.Operation} is not supported")
                    };

                    // Si body ya tiene una expresión, combinarla con la actual usando AND
                    if (body != null)
                    {
                        body = Expression.AndAlso(body, currentExpression);
                    }
                    else
                    {
                        body = currentExpression;
                    }
                }
            }

            // Si hay una expresión pendiente, agregarla al cuerpo
            if (currentExpression != null)
            {
                body = body == null ? currentExpression : Expression.AndAlso(body, currentExpression);
            }

            return Expression.Lambda<Func<T, bool>>(body!, parameter);
        }

        private static Expression GetPropertyExpression(Expression parameter, string propertyName)
        {
            var propertyNames = propertyName.Split('.'); // Separar por puntos para manejar propiedades anidadas
            Expression propertyExpression = parameter;

            foreach (var property in propertyNames)
            {
                propertyExpression = Expression.Property(propertyExpression, property); // Navegar por la propiedad
            }

            return propertyExpression;
        }
    }
}
