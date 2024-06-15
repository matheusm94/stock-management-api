using Microsoft.EntityFrameworkCore;
using Stock.Management.Api.Database;
using Stock.Management.Api.Database.Entities;
using Stock.Management.Api.DTOs;
using Stock.Management.Api.Repository.Interfaces;

namespace Stock.Management.Api.Repository;

public class ProductRepository(DbStockContext context) : IProductRepository
{
    private readonly DbStockContext _context = context;

    public async Task<IEnumerable<ProductGetDto>> GetProductsAsync()
    {
        return await (from p in _context.Products
                      select new ProductGetDto
                      {
                          ProductId = p.Productid,
                          Price = p.Price,
                          Name = p.Name,
                          Maturitydate = p.Maturitydate
                      }).ToListAsync().ConfigureAwait(false);
    }

    public async Task<ProductGetDto> GetProductByIdAsync(int productId)
    {
        var products = await (from p in _context.Products
                              where p.Productid == productId
                              select new ProductGetDto
                              {
                                  ProductId = p.Productid,
                                  Price = p.Price,
                                  Name = p.Name,
                                  Maturitydate = p.Maturitydate
                              }).FirstOrDefaultAsync().ConfigureAwait(false);

        return products;
    }

    public async Task CreateProductAsync(Product product)
    {
        await _context.AddAsync(product);
    }

    public async Task UpdateProduct(ProductDto productParameter, int productId)
    {
        var product = await _context.Products.Where(p => p.Productid == productId).FirstOrDefaultAsync();

        product.Name = productParameter.Name;
        product.Maturitydate = productParameter.Maturitydate;
        product.Price = productParameter.Price;
    }
}
