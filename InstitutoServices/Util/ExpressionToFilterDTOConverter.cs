using InstitutoServices.Class;
using System.Linq.Expressions;

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
            switch (expression)
            {
                case BinaryExpression binaryExpression when IsLogicalOperator(binaryExpression.NodeType):
                    ProcessLogicalExpression(binaryExpression, filters);
                    break;
                case BinaryExpression binaryExpression:
                    var filter = CreateFilterFromBinaryExpression(binaryExpression);
                    if (filter != null) filters.Add(filter);
                    break;
                case MethodCallExpression methodCallExpression:
                    var methodFilter = CreateFilterFromMethodCallExpression(methodCallExpression);
                    if (methodFilter != null) filters.Add(methodFilter);
                    break;
                case MemberExpression memberExpression:
                    filters.Add(new FilterDTO
                    {
                        PropertyName = GetFullPropertyPath(memberExpression),
                        Operation = "Equals",
                        Value = null
                    });
                    break;
                default:
                    throw new NotSupportedException($"Expresión no soportada: {expression.GetType()}");
            }
        }

        private static void ProcessLogicalExpression(BinaryExpression expression, List<FilterDTO> filters)
        {
            var operation = expression.NodeType == ExpressionType.AndAlso ? "AndAlso" : "OrElse";

            var filter = new FilterDTO
            {
                PropertyName = "",
                Operation = operation,
                SubFilters = new List<FilterDTO>()
            };

            ProcessExpression(expression.Left, filter.SubFilters);
            ProcessExpression(expression.Right, filter.SubFilters);

            filters.Add(filter);
        }

        private static bool IsLogicalOperator(ExpressionType nodeType)
        {
            return nodeType == ExpressionType.AndAlso || nodeType == ExpressionType.OrElse;
        }

        private static FilterDTO? CreateFilterFromBinaryExpression(BinaryExpression binaryExpression)
        {
            var left = binaryExpression.Left;
            var right = binaryExpression.Right;
            string? value = null;

            if (right is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Convert)
            {
                value = $"Convert({((ConstantExpression)unaryExpression.Operand).Value}, {unaryExpression.Type.Name})";
            }
            else if (right is ConstantExpression constantExpression)
            {
                value = constantExpression.Value?.ToString();
            }

            if (left is MemberExpression memberExpression && value != null)
            {
                return new FilterDTO
                {
                    PropertyName = GetFullPropertyPath(memberExpression),
                    Operation = GetOperationFromExpressionType(binaryExpression.NodeType),
                    Value = value
                };
            }
            return null;
        }

        private static FilterDTO? CreateFilterFromMethodCallExpression(MethodCallExpression methodCallExpression)
        {
            // Si es un Contains (u otro método de string) que tiene como objeto un ToString
            if (methodCallExpression.Method.DeclaringType == typeof(string) &&
                methodCallExpression.Object is MethodCallExpression innerMethod &&
                innerMethod.Method.Name == "ToString" &&
                innerMethod.Object is MemberExpression memberExpr)
            {
                return new FilterDTO
                {
                    PropertyName = GetFullPropertyPath(memberExpr),
                    Operation = $"ToString.{methodCallExpression.Method.Name}",
                    Value = ((ConstantExpression)methodCallExpression.Arguments[0]).Value?.ToString()
                };
            }

            // Manejar ToString() directo
            if (methodCallExpression.Method.Name == "ToString" &&
                methodCallExpression.Object is MemberExpression memberExpr2)
            {
                return new FilterDTO
                {
                    PropertyName = GetFullPropertyPath(memberExpr2),
                    Operation = "ToString",
                    Value = null
                };
            }

            // Manejar Equals en objetos
            if (methodCallExpression.Method.Name == "Equals" &&
                methodCallExpression.Object is MemberExpression memberExpression)
            {
                var valueExpression = methodCallExpression.Arguments[0];
                var value = GetValueFromExpression(valueExpression);

                return new FilterDTO
                {
                    PropertyName = GetFullPropertyPath(memberExpression),
                    Operation = "Equals",
                    Value = value
                };
            }

            // Manejar métodos de string (Contains, StartsWith, EndsWith) directos
            if (methodCallExpression.Method.DeclaringType == typeof(string))
            {
                if (methodCallExpression.Object is MemberExpression memberExpression2 &&
                    methodCallExpression.Arguments[0] is ConstantExpression constantExpression2)
                {
                    return new FilterDTO
                    {
                        PropertyName = GetFullPropertyPath(memberExpression2),
                        Operation = methodCallExpression.Method.Name,
                        Value = constantExpression2.Value?.ToString()
                    };
                }
            }

            return null;
        }
        private static string GetValueFromExpression(Expression expression)
        {
            if (expression is ConstantExpression constantExpression)
                return constantExpression.Value?.ToString() ?? "";

            if (expression is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Convert)
                return $"Convert({GetValueFromExpression(unaryExpression.Operand)}, {unaryExpression.Type.Name})";

            throw new NotSupportedException($"Expresión no soportada: {expression}");
        }

        private static string GetFullPropertyPath(MemberExpression memberExpression)
        {
            var propertyPath = new List<string>();
            Expression? currentExpression = memberExpression;

            while (currentExpression is MemberExpression currentMember)
            {
                propertyPath.Insert(0, currentMember.Member.Name);
                currentExpression = currentMember.Expression;
            }

            return string.Join(".", propertyPath);
        }

        private static string GetOperationFromExpressionType(ExpressionType expressionType)
        {
            return expressionType switch
            {
                ExpressionType.Equal => "Equals",
                ExpressionType.NotEqual => "NotEquals",
                ExpressionType.GreaterThan => "GreaterThan",
                ExpressionType.GreaterThanOrEqual => "GreaterThanOrEquals",
                ExpressionType.LessThan => "LessThan",
                ExpressionType.LessThanOrEqual => "LessThanOrEquals",
                ExpressionType.AndAlso => "AndAlso",
                ExpressionType.OrElse => "OrElse",
                ExpressionType.Not => "Not",
                ExpressionType.Add => "Add",
                ExpressionType.Subtract => "Subtract",
                ExpressionType.Multiply => "Multiply",
                ExpressionType.Divide => "Divide",
                ExpressionType.Modulo => "Modulo",
                ExpressionType.And => "BitwiseAnd",
                ExpressionType.Or => "BitwiseOr",
                ExpressionType.ExclusiveOr => "ExclusiveOr",
                ExpressionType.Coalesce => "Coalesce",
                ExpressionType.Conditional => "Conditional",
                _ => throw new NotSupportedException($"La operación {expressionType} no es compatible.")
            };
        }
    }
}
