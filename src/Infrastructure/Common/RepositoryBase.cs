using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Common;

public class RepositoryBase<T, K, TContext>(TContext dbContext, IUnitOfWork<TContext> unitOfWork)
    : RepositoryQueryBase<T, K, TContext>(dbContext), IRepositoryBase<T, K, TContext>
    where T : BaseEntity<K>
    where TContext : DbContext
{
    private readonly TContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private readonly IUnitOfWork<TContext> _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task<K> CreateAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity.Id;
    }

    public async Task<IList<K>> CreateListAsync(IEnumerable<T> entities)
    {
        await _dbContext.Set<T>().AddRangeAsync(entities);  
        return entities.Select(x => x.Id).ToList();
    }

    public Task UpdateAsync(T entity)
    {
        if(_dbContext.Entry(entity).State == EntityState.Unchanged) return Task.CompletedTask;
        T? exist = _dbContext.Set<T>().Find(entity.Id);
        if (exist == null) throw new InvalidOperationException($"Entity with Id '{entity.Id}' not found.");
        _dbContext.Entry(exist).CurrentValues.SetValues(entity);
        return Task.CompletedTask;  
    }
    public Task UpdateListAsync(IEnumerable<T> entities) => _dbContext.Set<T>().AddRangeAsync(entities);

    public Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public Task DeleteListAsync(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().RemoveRange(entities);
        return Task.CompletedTask;
    }

    public Task<int> SaveChangesAsync() => _unitOfWork.CommitAsync(); 
  

    public Task<IDbContextTransaction> BeginTransactionAsync() => _dbContext.Database.BeginTransactionAsync();

    public async Task EndTransactionAsync()
    {
        await SaveChangesAsync();
        await _dbContext.Database.CommitTransactionAsync();
    }

    public Task RollbackTransactionAsync() => _dbContext.Database.RollbackTransactionAsync();
}
