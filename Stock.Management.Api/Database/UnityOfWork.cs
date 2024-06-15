namespace Stock.Management.Api.Database;


public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
}

public class UnitOfWork(DbStockContext context) : IUnitOfWork
{
    private readonly DbStockContext _context = context;

    public async Task CommitAsync() => await _context.SaveChangesAsync();

    void IDisposable.Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
