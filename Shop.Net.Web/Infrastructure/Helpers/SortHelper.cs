namespace Shop.Net.Web.Infrastructure.Helpers
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;

    public static class SortHelper
    {
        public static IOrderedQueryable<T> ObjectSort<T>(this IQueryable<T> entities, Expression<Func<T, object>> expression, string order = "asc")
        {
            var sortOrder = order == "asc" ? SortOrder.Ascending : SortOrder.Descending;
            return entities.ObjectSort(expression, sortOrder);
        }

        public static IOrderedQueryable<T> ObjectSort<T>(this IQueryable<T> entities, Expression<Func<T, object>> expression, SortOrder order = SortOrder.Ascending)
        {
            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                var propertyExpression = (MemberExpression)unaryExpression.Operand;
                var parameters = expression.Parameters;

                if (propertyExpression.Type == typeof(DateTime))
                {
                    var newExpression = Expression.Lambda<Func<T, DateTime>>(propertyExpression, parameters);
                    return order == SortOrder.Ascending ? entities.OrderBy(newExpression) : entities.OrderByDescending(newExpression);
                }

                if (propertyExpression.Type == typeof(DateTime?))
                {
                    var newExpression = Expression.Lambda<Func<T, DateTime?>>(propertyExpression, parameters);
                    return order == SortOrder.Ascending ? entities.OrderBy(newExpression) : entities.OrderByDescending(newExpression);
                }

                if (propertyExpression.Type == typeof(int))
                {
                    var newExpression = Expression.Lambda<Func<T, int>>(propertyExpression, parameters);
                    return order == SortOrder.Ascending ? entities.OrderBy(newExpression) : entities.OrderByDescending(newExpression);
                }

                if (propertyExpression.Type == typeof(int?))
                {
                    var newExpression = Expression.Lambda<Func<T, int?>>(propertyExpression, parameters);
                    return order == SortOrder.Ascending ? entities.OrderBy(newExpression) : entities.OrderByDescending(newExpression);
                }

                if (propertyExpression.Type == typeof(bool))
                {
                    var newExpression = Expression.Lambda<Func<T, bool>>(propertyExpression, parameters);
                    return order == SortOrder.Ascending ? entities.OrderBy(newExpression) : entities.OrderByDescending(newExpression);
                }

                throw new NotSupportedException("Object type resolution not implemented for this type");
            }
            return order == SortOrder.Ascending ? entities.OrderBy(expression) : entities.OrderByDescending(expression);
        }
    }
}