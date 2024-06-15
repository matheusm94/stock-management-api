using Stock.Management.Api.DTOs;
using Stock.Management.Api.Utils;

namespace Stock.Management.Api.Service.Interfaces;

public interface IProductService
{
    Task<ServiceResult<IEnumerable<ProductGetDto>>> GetProductsAsync();
    Task<ServiceResult<ProductGetDto>> GetProductByIdAsync(int productId);
    Task<ServiceResult<bool>> CreateProductAsync(ProductDto productDto);
    Task<ServiceResult<bool>> UpdateProductAsync(int productId, ProductDto productDto);
}
