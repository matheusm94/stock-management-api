using Stock.Management.Api.Models;
using Stock.Management.Api.Utils;

namespace Stock.Management.Api.Service.Interfaces;

public interface IProductService
{
    Task<ServiceResult<IEnumerable<ProductGetModel>>> GetProductsAsync();
    Task<ServiceResult<ProductGetModel>> GetProductByIdAsync(int Id);
    Task<ServiceResult<bool>> CreateProductAsync(ProductModel productModel);
    Task<ServiceResult<bool>> UpdateProductAsync(ProductGetModel productModel);
}
