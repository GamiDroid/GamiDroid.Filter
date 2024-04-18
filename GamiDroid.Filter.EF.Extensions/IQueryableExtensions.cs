using System.Linq.Expressions;
using System.Reflection;

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
            Expression propExpr = Expression.Property(paramExpr, property);

            if (property.PropertyType != typeof(string))
                propExpr = Expression.Call(propExpr, s_toStringMethodInfo);

            var constant = Expression.Constant(searchText);
            Expression predicateExpr = Expression.Call(propExpr, s_stringContainsMethodInfo, constant);

            totalPredicateExpr = (totalPredicateExpr is null) ? predicateExpr : Expression.OrElse(totalPredicateExpr, predicateExpr);
        }

        var whereExpression = Expression.Lambda<Func<T, bool>>(totalPredicateExpr!, paramExpr);
        return query.Where(whereExpression);
    }

    private static readonly MethodInfo s_toStringMethodInfo =
        typeof(object).GetMethod("ToString")!;
     
    private static readonly MethodInfo s_stringContainsMethodInfo =
        typeof(string).GetMethods().Single(m => m.Name == nameof(string.Contains) && 
        m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(string));

    private static readonly MethodInfo s_containsMethodInfo =
        typeof(Enumerable).GetMethods().Single(m => m.Name == nameof(Enumerable.Contains) &&
            m.GetParameters().Length == 2).MakeGenericMethod(typeof(object));
}
