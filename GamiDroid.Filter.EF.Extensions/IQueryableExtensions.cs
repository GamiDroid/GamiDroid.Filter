
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;

namespace GamiDroid.Filter.EF.Extensions;
public static class IQueryableExtensions
{
    public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, Filter filter)
    {
        query = query.ApplySearch(filter.SearchText);
        return query;
    }

    public static IQueryable<T> ApplySearch<T>(this IQueryable<T> query, string? searchText)
    {
        if (string.IsNullOrEmpty(searchText))
            return query;

        // get first character of the type name
        var paramName = typeof(T).Name[..1].ToLower();

        var paramExpr = Expression.Parameter(typeof(T), paramName);

        var properties = typeof(T).GetProperties();

        if (properties.Length == 0)
            throw new InvalidProgramException($"Type {typeof(T).Name} does not have any properties to search on.");

        Expression? totalPredicateExpr = null;
        foreach (var property in properties)
        {
            var propExpr = Expression.Property(paramExpr, property);

            var constant = Expression.Constant(searchText);
            Expression predicateExpr = Expression.Call(s_containsMethodInfo, propExpr, constant);

            totalPredicateExpr = (totalPredicateExpr is null) ? predicateExpr : Expression.OrElse(totalPredicateExpr, predicateExpr);
        }

        var whereExpression = Expression.Lambda<Func<T, bool>>(totalPredicateExpr!, paramExpr);
        return query.Where(whereExpression);
    }

    private static readonly MethodInfo s_containsMethodInfo =
        typeof(Enumerable).GetMethods().Single(m => m.Name == nameof(Enumerable.Contains) &&
            m.GetParameters().Length == 2).MakeGenericMethod(typeof(object));
}
