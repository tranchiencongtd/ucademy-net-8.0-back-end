namespace Domain.Interfaces.Specifications;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

/// <summary>
/// Base class for specifications to provide a common implementation of the ISpecifications interface.
/// </summary>
/// <typeparam name="T">The type of entity being queried.</typeparam>
public abstract class BaseSpecification<T> : ISpecifications<T>
{
    protected BaseSpecification()
    {
        Criteria = _ => true; // Default criteria that matches any entity
        Includes = new List<Expression<Func<T, object>>>();
    }
    
    protected BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
        Includes = new List<Expression<Func<T, object>>>();
    }

    /// <summary>
    /// Gets the conditional expression used to filter entities.
    /// </summary>
    public Expression<Func<T, bool>> Criteria { get; }

    /// <summary>
    /// Gets the list of related objects to include in the query.
    /// </summary>
    public List<Expression<Func<T, object>>> Includes { get; }

    /// <summary>
    /// Gets or sets the expression for ordering the result in ascending order.
    /// </summary>
    public Expression<Func<T, object>> OrderBy { get; private set; }

    /// <summary>
    /// Gets or sets the expression for ordering the result in descending order.
    /// </summary>
    public Expression<Func<T, object>> OrderByDescending { get; private set; }

    /// <summary>
    /// Gets or sets the number of records to return.
    /// </summary>
    public int Take { get; private set; }

    /// <summary>
    /// Gets or sets the number of records to skip.
    /// </summary>
    public int Skip { get; private set; }

    /// <summary>
    /// Determines whether pagination is enabled.
    /// </summary>
    public bool IsPagingEnabled { get; private set; }

    /// <summary>
    /// Adds a related object to include in the query.
    /// </summary>
    /// <param name="includeExpression">The expression for the related object.</param>
    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    /// <summary>
    /// Sets the order by expression.
    /// </summary>
    /// <param name="orderByExpression">The order by expression.</param>
    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    /// <summary>
    /// Sets the order by descending expression.
    /// </summary>
    /// <param name="orderByDescExpression">The order by descending expression.</param>
    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }

    /// <summary>
    /// Enables pagination and sets the number of records to return and skip.
    /// </summary>
    /// <param name="take">The number of records to take.</param>
    /// <param name="skip">The number of records to skip.</param>
    protected void ApplyPaging(int take, int skip)
    {
        Take = take;
        Skip = skip;
        IsPagingEnabled = true;
    }
}
