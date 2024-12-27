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
                // Obtener la propiedad del modelo
                var property = Expression.Property(parameter, filter.PropertyName);

                // Convertir el valor al tipo de la propiedad
                var constant = Expression.Constant(Convert.ChangeType(filter.Value, property.Type));

                // Crear la expresión de comparación o método
                Expression comparison = filter.Operation switch
                {
                    // Operaciones de comparación
                    "Equals" => Expression.Equal(property, constant),
                    "NotEquals" => Expression.NotEqual(property, constant),
                    "GreaterThan" => Expression.GreaterThan(property, constant),
                    "GreaterThanOrEquals" => Expression.GreaterThanOrEqual(property, constant),
                    "LessThan" => Expression.LessThan(property, constant),
                    "LessThanOrEquals" => Expression.LessThanOrEqual(property, constant),

                    // Métodos de cadenas
                    "Contains" => Expression.Call(property, typeof(string).GetMethod("Contains", new[] { typeof(string) })!, constant),
                    "StartsWith" => Expression.Call(property, typeof(string).GetMethod("StartsWith", new[] { typeof(string) })!, constant),
                    "EndsWith" => Expression.Call(property, typeof(string).GetMethod("EndsWith", new[] { typeof(string) })!, constant),

                    // Operadores lógicos (se pueden expandir según necesidad)
                    "AndAlso" => body == null ? constant : Expression.AndAlso(body, constant),
                    "OrElse" => body == null ? constant : Expression.OrElse(body, constant),

                    // Otros operadores no soportados
                    _ => throw new NotSupportedException($"Operation {filter.Operation} is not supported")
                };

                // Combinar la nueva comparación con el cuerpo existente
                body = body == null ? comparison : Expression.AndAlso(body, comparison);
            }

            if (body == null)
            {
                throw new InvalidOperationException("No filters provided to build the predicate.");
            }

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

    }
}
