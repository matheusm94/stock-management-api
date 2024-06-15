using Stock.Management.Api.Database.Entities;
using Stock.Management.Api.DTOs;

namespace Stock.Management.Api.Repository.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<ProductGetDto>> GetProductsAsync();
    Task<ProductGetDto> GetProductByIdAsync(int productId);
    Task CreateProductAsync(Product product);
    Task UpdateProduct(ProductDto productParameter, int productId);
}
