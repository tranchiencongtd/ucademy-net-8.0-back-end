using System.Linq.Expressions;

namespace Domain.Interfaces.Specifications;

/// <summary>
/// Interface for defining specifications to query data.
/// </summary>
/// <typeparam name="T">The type of entity being queried.</typeparam>
public interface ISpecifications<T>
{
    /// <summary>
    /// Gets the conditional expression used to filter entities.
    /// </summary>
    Expression<Func<T, bool>> Criteria { get; }

    /// <summary>
    /// Gets the list of related objects to include in the query.
    /// </summary>
    List<Expression<Func<T, object>>> Includes { get; }

    /// <summary>
    /// Gets the expression for ordering the result in ascending order.
    /// </summary>
    Expression<Func<T, object>> OrderBy { get; }

    /// <summary>
    /// Gets the expression for ordering the result in descending order.
    /// </summary>
    Expression<Func<T, object>> OrderByDescending { get; }

    /// <summary>
    /// Gets the number of records to return.
    /// </summary>
    int Take { get; }

    /// <summary>
    /// Gets the number of records to skip.
    /// </summary>
    int Skip { get; }

    /// <summary>
    /// Determines whether pagination is enabled.
    /// </summary>
    bool IsPagingEnabled { get; }
}
