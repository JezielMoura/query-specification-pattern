using Microsoft.EntityFrameworkCore;

namespace Nett.Core;

public static class QuerySpecificationBuilder
{
    public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> input, QuerySpecification<TEntity> specification) where TEntity : class
    {
        IQueryable<TEntity> queryable = input;

        if (specification.Query is {} query)
            queryable = queryable.Where(query);

        if (specification.OrderBy is {} orderBy)
            queryable = queryable.OrderBy(orderBy);

        if (specification.OrderByDesceding is {} orderByDesceding)
            queryable = queryable.OrderByDescending(orderByDesceding);

        if (specification.Includes.Count > 0)
            queryable = specification.Includes.Aggregate(queryable, (current, include) => current.Include(include));

        if (specification.IsSplitQuery)
            queryable = queryable.AsSplitQuery();

        if (specification.IgnoreGlobalFilters)
            queryable = queryable.IgnoreQueryFilters();

        return queryable;
    }

    public static IQueryable<TResult> GetQuery<TEntity, TResult>(IQueryable<TEntity> input, QuerySpecification<TEntity, TResult> specification) where TEntity : class
    {
        var queryable = GetQuery<TEntity>(input, specification);

        if (specification.Selector is null)
            throw new ArgumentException("Selector cannot be null");

        return queryable.Select(specification.Selector);
    }
}
