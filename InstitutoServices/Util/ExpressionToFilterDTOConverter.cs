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
            else if (expression is MemberExpression memberExpression)
            {
                filters.Add(new FilterDTO
                {
                    PropertyName = GetFullPropertyPath(memberExpression),
                    Operation = "Equals",
                    Value = null
                });
            }
            else
            {
                throw new NotSupportedException($"La expresión no es compatible: {expression}");
            }
        }

        private static FilterDTO? CreateFilterFromBinaryExpression(BinaryExpression binaryExpression)
        {
            var left = binaryExpression.Left;
            var right = binaryExpression.Right;
            string? value = null;

            if (right is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Convert)
            {
                value = $"Convert({((ConstantExpression)unaryExpression.Operand).Value}, {unaryExpression.Type.Name})";
                right = unaryExpression.Operand;
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
            {
                return constantExpression.Value?.ToString();
            }
            if (expression is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Convert)
            {
                return $"Convert({GetValueFromExpression(unaryExpression.Operand)}, {unaryExpression.Type.Name})";
            }
            throw new NotSupportedException($"La expresión no es compatible: {expression}");
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
