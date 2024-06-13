using Microsoft.EntityFrameworkCore;
using Stock.Management.Api.Database;
using Stock.Management.Api.Models;
using Stock.Management.Api.Repository.Interfaces;
using Stock.Management.Api.Utils;

namespace Stock.Management.Api.Repository;

public class ProductRepository(DbStockContext context) : IProductRepository
{
    private readonly DbStockContext _context = context;

    public async Task<IEnumerable<ProductModel>> GetProductsAsync()
    {
        return await (from p in _context.Products
                      select new ProductModel
                      {
                          Productid = p.Productid,
                          Price = p.Price,
                          Name = p.Name,
                          Maturitydate = p.Maturitydate
                      }).ToListAsync().ConfigureAwait(false);
    }

}
