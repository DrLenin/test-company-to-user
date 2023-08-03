namespace TestApp.Store.Repositories;

public interface IBaseRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    Task AddRangeAsync<T>(ICollection<T> collection, CancellationToken cancellationToken = default) where T : class;
        
    void UpdateRange<T>(ICollection<T> collection) where T : class;
        
    ValueTask<T> AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;
}
public class BaseRepository : IBaseRepository, IDisposable
{
    public readonly TestAppContext DbContext;

    protected BaseRepository(TestAppContext dbContext) => DbContext = dbContext;

    private bool _disposed;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task AddRangeAsync<T>(ICollection<T> collection, CancellationToken cancellationToken = default) where T : class
    {
        await DbContext.Set<T>().AddRangeAsync(collection, cancellationToken);
    }

    public void UpdateRange<T>(ICollection<T> collection) where T : class
    {
        DbContext.Set<T>().UpdateRange(collection);
    }

    public async ValueTask<T> AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
    {
        var result = await DbContext.Set<T>().AddAsync(entity, cancellationToken);
            
        return result.Entity;
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if(!_disposed && disposing)
            DbContext.Dispose();

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
    }
}