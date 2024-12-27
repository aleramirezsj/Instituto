using InstitutoServices.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoServices.Util
{
    public static class ExpressionToFilterDTOConverter
    {
        public static List<FilterDTO> Convert<T>(Expression<Func<T, bool>> expression)
        {
            var filters = new List<FilterDTO>();
            ProcessExpression(expression.Body, filters);
            return filters;
        }

        private static void ProcessExpression(Expression expression, List<FilterDTO> filters)
        {
            // Si la expresión es lógica (AND/OR)
            if (expression is BinaryExpression logicalExpression &&
                (logicalExpression.NodeType == ExpressionType.AndAlso || logicalExpression.NodeType == ExpressionType.OrElse))
            {
                // Procesar las expresiones lógicas
                var leftFilters = new List<FilterDTO>();
                var rightFilters = new List<FilterDTO>();

                ProcessExpression(logicalExpression.Left, leftFilters);
                ProcessExpression(logicalExpression.Right, rightFilters);

                // Agregar las expresiones lógicas con su tipo
                filters.AddRange(leftFilters);
                filters.AddRange(rightFilters);
                filters.Add(new FilterDTO
                {
                    PropertyName = string.Empty,  // El campo vacío para representar la expresión lógica
                    Operation = GetOperationFromExpressionType(logicalExpression.NodeType),
                    Value = string.Empty  // No es necesario un valor en expresiones lógicas
                });
            }
            // Si la expresión es binaria (como Equals, NotEquals, etc.)
            else if (expression is BinaryExpression binaryExpression)
            {
                var filter = CreateFilterFromBinaryExpression(binaryExpression);
                if (filter != null)
                {
                    filters.Add(filter);
                }
                else
                {
                    // Si la expresión es lógica, procesamos ambos lados (AND/OR)
                    ProcessExpression(binaryExpression.Left, filters);
                    ProcessExpression(binaryExpression.Right, filters);
                }
            }
            // Si la expresión es una llamada de método (por ejemplo, Equals, Contains, StartsWith, etc.)
            else if (expression is MethodCallExpression methodCallExpression)
            {
                var filter = CreateFilterFromMethodCallExpression(methodCallExpression);
                if (filter != null)
                {
                    filters.Add(filter);
                }
            }
            else
            {
                throw new NotSupportedException($"La expresión no es compatible: {expression}");
            }
        }

        // Manejo de expresiones binarias simples (por ejemplo, a.Equals(1))
        private static FilterDTO? CreateFilterFromBinaryExpression(BinaryExpression binaryExpression)
        {
            if (binaryExpression.Left is MemberExpression memberExpression &&
                binaryExpression.Right is ConstantExpression constantExpression)
            {
                return new FilterDTO
                {
                    PropertyName = GetFullPropertyPath(memberExpression), // Ruta completa de la propiedad
                    Operation = GetOperationFromExpressionType(binaryExpression.NodeType),
                    Value = constantExpression.Value?.ToString()
                };
            }
            return null;
        }

        // Manejo de llamadas a métodos (como Equals, Contains, StartsWith)
        private static FilterDTO? CreateFilterFromMethodCallExpression(MethodCallExpression methodCallExpression)
        {
            // Manejo de métodos Equals
            if (methodCallExpression.Method.Name == "Equals" &&
                methodCallExpression.Object is MemberExpression memberExpression &&
                methodCallExpression.Arguments[0] is ConstantExpression constantExpression)
            {
                return new FilterDTO
                {
                    PropertyName = GetFullPropertyPath(memberExpression), // Ruta completa de la propiedad
                    Operation = "Equals", // Siempre es Equals en este caso
                    Value = constantExpression.Value?.ToString()
                };
            }
            // Manejo de métodos de cadenas como Contains, StartsWith, EndsWith
            if (methodCallExpression.Method.DeclaringType == typeof(string))
            {
                if (methodCallExpression.Object is MemberExpression memberExpression2 &&
                    methodCallExpression.Arguments[0] is ConstantExpression constantExpression2)
                {
                    return new FilterDTO
                    {
                        PropertyName = GetFullPropertyPath(memberExpression2), // Ruta completa de la propiedad
                        Operation = methodCallExpression.Method.Name, // e.g., "Contains", "StartsWith", etc.
                        Value = constantExpression2.Value?.ToString()
                    };
                }
            }

            return null;
        }

        // Obtiene la ruta completa de la propiedad para propiedades anidadas (e.g., "Direccion.Ciudad")
        private static string GetFullPropertyPath(MemberExpression memberExpression)
        {
            var propertyPath = new List<string>();

            Expression? currentExpression = memberExpression;
            while (currentExpression is MemberExpression currentMember)
            {
                propertyPath.Insert(0, currentMember.Member.Name); // Agregar al inicio para invertir el orden
                currentExpression = currentMember.Expression;
            }

            return string.Join(".", propertyPath); // Combinar las propiedades con "."
        }

        // Mapea los operadores de la expresión a operaciones de filtro (Equals, GreaterThan, AndAlso, etc.)
        private static string GetOperationFromExpressionType(ExpressionType expressionType)
        {
            return expressionType switch
            {
                // Operaciones de comparación
                ExpressionType.Equal => "Equals",
                ExpressionType.NotEqual => "NotEquals",
                ExpressionType.GreaterThan => "GreaterThan",
                ExpressionType.GreaterThanOrEqual => "GreaterThanOrEquals",
                ExpressionType.LessThan => "LessThan",
                ExpressionType.LessThanOrEqual => "LessThanOrEquals",

                // Operadores lógicos
                ExpressionType.AndAlso => "AndAlso",
                ExpressionType.OrElse => "OrElse",
                ExpressionType.Not => "Not",

                // Operaciones aritméticas
                ExpressionType.Add => "Add",
                ExpressionType.Subtract => "Subtract",
                ExpressionType.Multiply => "Multiply",
                ExpressionType.Divide => "Divide",
                ExpressionType.Modulo => "Modulo",

                // Operadores bit a bit
                ExpressionType.And => "BitwiseAnd",
                ExpressionType.Or => "BitwiseOr",
                ExpressionType.ExclusiveOr => "ExclusiveOr",

                // Otros operadores
                ExpressionType.Coalesce => "Coalesce",
                ExpressionType.Conditional => "Conditional",

                _ => throw new NotSupportedException($"La operación {expressionType} no es compatible.")
            };
        }
    }
}
