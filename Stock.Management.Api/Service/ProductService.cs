using Stock.Management.Api.Models;
using Stock.Management.Api.Repository.Interfaces;
using Stock.Management.Api.Service.Interfaces;
using Stock.Management.Api.Utils;

namespace Stock.Management.Api.Service;

public class ProductService(IProductRepository productRepository): IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<ServiceResult<IEnumerable<ProductModel>>> GetProductsAsync()
    {
        var result = new ServiceResult<IEnumerable<ProductModel>>();

        var products = await _productRepository.GetProductsAsync();

        return result.SetSuccess(products);
    }
}
