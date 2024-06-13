using Stock.Management.Api.Models;
using Stock.Management.Api.Utils;

namespace Stock.Management.Api.Repository.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<ProductModel>> GetProductsAsync();
}
