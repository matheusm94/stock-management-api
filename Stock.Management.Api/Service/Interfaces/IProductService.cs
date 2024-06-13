using Stock.Management.Api.Models;
using Stock.Management.Api.Utils;

namespace Stock.Management.Api.Service.Interfaces;

public interface IProductService
{
    Task<ServiceResult<IEnumerable<ProductModel>>> GetProductsAsync();
}
