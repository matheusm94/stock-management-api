namespace Stock.Management.Api.Database;

public interface IUnitOfWork
{
    Task CommitAsync();
    void Dispose();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly DbStockContext _context;

    public UnitOfWork(DbStockContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
