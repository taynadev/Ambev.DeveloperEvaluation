using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Provides query extensions with support for filtering, ordering, and pagination.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Applies filtering, ordering and pagination based on API query parameters.
        /// </summary>
        /// <typeparam name="T">The entity type being queried.</typeparam>
        /// <param name="query">The initial queryable.</param>
        /// <param name="queryParams">A dictionary of query string parameters.</param>
        /// <returns>The updated queryable after applying filters, ordering, and pagination.</returns>
        public static async Task<(List<T> Items, int TotalCount)> ApplyQueryParametersAsync<T>(
            this IQueryable<T> query,
            Dictionary<string, string?> queryParams) where T : class
        {
            // Filtering
            foreach (var param in queryParams)
            {
                var key = param.Key;
                var value = param.Value;

                if (string.IsNullOrWhiteSpace(value)) continue;

                if (key.StartsWith("_")) continue; // skip special params for now

                if (value.Contains("*"))
                {
                    var cleanValue = value.Replace("*", "");
                    query = query.Where(BuildLikePredicate<T>(key, cleanValue));
                }
                else
                {
                    query = query.Where(BuildEqualsPredicate<T>(key, value));
                }
            }

            // Range Filtering
            foreach (var param in queryParams)
            {
                if (param.Key.StartsWith("_min"))
                {
                    var prop = param.Key[4..];
                    query = query.Where(BuildRangePredicate<T>(prop, param.Value, isMin: true));
                }
                else if (param.Key.StartsWith("_max"))
                {
                    var prop = param.Key[4..];
                    query = query.Where(BuildRangePredicate<T>(prop, param.Value, isMin: false));
                }
            }

            // Ordering
            if (queryParams.TryGetValue("_order", out var orderValue) && !string.IsNullOrWhiteSpace(orderValue))
            {
                var orders = orderValue.Split(',');
                bool first = true;

                foreach (var ord in orders)
                {
                    var trimmed = ord.Trim();
                    var parts = trimmed.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var prop = parts[0];
                    var descending = parts.Length > 1 && parts[1].Equals("desc", StringComparison.OrdinalIgnoreCase);

                    query = first
                        ? (descending ? query.OrderByDescending(GetPropertyExpression<T>(prop)) : query.OrderBy(GetPropertyExpression<T>(prop)))
                        : (descending ? ((IOrderedQueryable<T>)query).ThenByDescending(GetPropertyExpression<T>(prop)) : ((IOrderedQueryable<T>)query).ThenBy(GetPropertyExpression<T>(prop)));

                    first = false;
                }
            }

            // Pagination
            int page = queryParams.TryGetValue("_page", out var p) && int.TryParse(p, out var pg) ? pg : 1;
            int size = queryParams.TryGetValue("_size", out var s) && int.TryParse(s, out var sz) ? sz : 10;

            int total = await query.CountAsync();
            var items = await query.Skip((page - 1) * size).Take(size).ToListAsync();

            return (items, total);
        }

        private static Expression<Func<T, bool>> BuildLikePredicate<T>(string propertyName, string value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyName);
            var method = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;
            var constant = Expression.Constant(value);
            var contains = Expression.Call(property, method, constant);
            return Expression.Lambda<Func<T, bool>>(contains, parameter);
        }

        private static Expression<Func<T, bool>> BuildEqualsPredicate<T>(string propertyName, string? value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyName);
            var constant = Expression.Constant(Convert.ChangeType(value, property.Type));
            var equal = Expression.Equal(property, constant);
            return Expression.Lambda<Func<T, bool>>(equal, parameter);
        }

        private static Expression<Func<T, bool>> BuildRangePredicate<T>(string propertyName, string? value, bool isMin)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyName);
            var convertedValue = Convert.ChangeType(value, property.Type);
            var constant = Expression.Constant(convertedValue);

            var comparison = isMin
                ? Expression.GreaterThanOrEqual(property, constant)
                : Expression.LessThanOrEqual(property, constant);

            return Expression.Lambda<Func<T, bool>>(comparison, parameter);
        }

        private static Expression<Func<T, object>> GetPropertyExpression<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyName);
            var converted = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<T, object>>(converted, parameter);
        }
    }

}
