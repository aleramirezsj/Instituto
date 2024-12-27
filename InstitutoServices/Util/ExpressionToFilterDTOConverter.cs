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
            if (expression is BinaryExpression binaryExpression)
            {
                var filter = CreateFilterFromBinaryExpression(binaryExpression);
                if (filter != null)
                {
                    filters.Add(filter);
                }
            }
            else if (expression is MethodCallExpression methodCallExpression)
            {
                var filter = CreateFilterFromMethodCallExpression(methodCallExpression);
                if (filter != null)
                {
                    filters.Add(filter);
                }
            }
            else if (expression is BinaryExpression logicalExpression &&
                     (logicalExpression.NodeType == ExpressionType.AndAlso || logicalExpression.NodeType == ExpressionType.OrElse))
            {
                ProcessExpression(logicalExpression.Left, filters);
                ProcessExpression(logicalExpression.Right, filters);
            }
            else
            {
                throw new NotSupportedException($"La expresión no es compatible: {expression}");
            }
        }

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

        private static FilterDTO? CreateFilterFromMethodCallExpression(MethodCallExpression methodCallExpression)
        {
            if (methodCallExpression.Method.Name == "Equals" &&
        methodCallExpression.Object is MemberExpression memberExpression &&
        methodCallExpression.Arguments[0] is ConstantExpression constantExpression)
            {
                // Manejar el caso de a.CarreraId.Equals(1)
                return new FilterDTO
                {
                    PropertyName = memberExpression.Member.Name,
                    Operation = "Equals", // Siempre es Equals en este caso
                    Value = constantExpression.Value?.ToString()
                };
            }
            if (methodCallExpression.Method.DeclaringType == typeof(string))
            {
                // Manejar métodos de cadenas como Contains, StartsWith, EndsWith
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
