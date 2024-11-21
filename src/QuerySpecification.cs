using System.Linq.Expressions;

namespace Nett.Core;

public abstract class QuerySpecification<TEntity>
{
    public Expression<Func<TEntity, bool>>? Query { get; set; }
    public Expression<Func<TEntity, object>>? OrderBy { get; set; }
    public Expression<Func<TEntity, object>>? OrderByDesceding { get; set; }
    public List<Expression<Func<TEntity, object>>> Includes { get; } = [];
    public bool IsSplitQuery { get; set; } = false;
    public bool IgnoreGlobalFilters { get; set; } = false;

    protected virtual void AddInclude(Expression<Func<TEntity, object>> includeExpression) =>
        Includes?.Add(includeExpression);
}

public abstract class QuerySpecification<T, TResult> : QuerySpecification<T>
{
    public Expression<Func<T, TResult>>? Selector { get; set; }
}