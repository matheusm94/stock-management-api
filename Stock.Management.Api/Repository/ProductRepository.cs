using Microsoft.EntityFrameworkCore;
using Stock.Management.Api.Database;
using Stock.Management.Api.Database.Entities;
using Stock.Management.Api.Models;
using Stock.Management.Api.Repository.Interfaces;

namespace Stock.Management.Api.Repository;

public class ProductRepository(DbStockContext context) : IProductRepository
{
    private readonly DbStockContext _context = context;

    public async Task<IEnumerable<ProductGetModel>> GetProductsAsync()
    {
        return await (from p in _context.Products
                      select new ProductGetModel
                      {
                          Productid = p.Productid,
                          Price = p.Price,
                          Name = p.Name,
                          Maturitydate = p.Maturitydate
                      }).ToListAsync().ConfigureAwait(false);
    }

    public async Task<ProductGetModel> GetProductByIdAsync(int Id)
    {
        var products = await (from p in _context.Products
                              where p.Productid == Id
                              select new ProductGetModel
                              {
                                  Productid = p.Productid,
                                  Price = p.Price,
                                  Name = p.Name,
                                  Maturitydate = p.Maturitydate
                              }).FirstOrDefaultAsync().ConfigureAwait(false);

        return products;
    }

    public async Task CreateProductAsync(ProductModel productModel)
    {
        Product product = new()
        {
            Name = productModel.Name,
            Maturitydate = productModel.Maturitydate,
            Price = productModel.Price,
        };
        await _context.AddAsync(product);

        await _context.SaveChangesAsync();
    }

    public void UpdateProduct(Product product)
    {
        //var product = GetProductAsync(productModel.Productid).Result; 

        //product.Name = productModel.Name;
        //product.Maturitydate = productModel.Maturitydate;
        //product.Price = productModel.Price;
        //
        _context.Entry(product).State = EntityState.Modified;
       // _context.SaveChanges();
    }

    public async Task<Product> GetProductAsync(int id) => await _context.Products
        .Where(p => p.Productid == id).FirstOrDefaultAsync().ConfigureAwait(false);
}
