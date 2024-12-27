using InstitutoServices.Class;
using System.Linq.Expressions;

namespace InstitutoBack.Util
{
    public static class BuilderPredicate
    {
        public static Expression<Func<T, bool>> GetExpression<T>(List<FilterDTO> filters)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            Expression? body = null;

            foreach (var filter in filters)
            {
                // Obtener la propiedad de la ruta completa
                var property = GetPropertyExpression(parameter, filter.PropertyName);

                // Convertir el valor al tipo de la propiedad
                var constant = Expression.Constant(Convert.ChangeType(filter.Value, property.Type));

                // Crear la expresión de comparación o método
                Expression comparison = filter.Operation switch
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

                body = body == null ? comparison : Expression.AndAlso(body, comparison);
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
