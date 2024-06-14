using Stock.Management.Api.Models;
using Stock.Management.Api.Repository.Interfaces;
using Stock.Management.Api.Service.Interfaces;
using Stock.Management.Api.Utils;

namespace Stock.Management.Api.Service;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<ServiceResult<IEnumerable<ProductGetModel>>> GetProductsAsync()
    {
        var result = new ServiceResult<IEnumerable<ProductGetModel>>();

        var products = await _productRepository.GetProductsAsync();

        return result.SetSuccess(products);
    }

    public async Task<ServiceResult<ProductGetModel>> GetProductByIdAsync(int Id)
    {
        var result = new ServiceResult<ProductGetModel>();

        var products = await _productRepository.GetProductByIdAsync(Id);

        return result.SetSuccess(products);
    }

    public async Task<ServiceResult<bool>> CreateProductAsync(ProductModel productModel)
    {
        var result = new ServiceResult<bool>();

        if (productModel.Maturitydate < DateTime.Now)
            return result.SetError("Data de maturidade não pode ser menor que a data atual");

        if (productModel.Price == 0)
            return result.SetError("Preço não pode ser 0");

        await _productRepository.CreateProductAsync(productModel);

        result.SetSuccess();

        return result;
    }

    public async Task<ServiceResult<bool>> UpdateProductAsync(ProductGetModel productModel)
    {
        var result = new ServiceResult<bool>();

        if (productModel.Maturitydate < DateTime.Now)
            return result.SetError("Data de maturidade não pode ser menor que a data atual");

        if (productModel.Price == 0)
            return result.SetError("Preço não pode ser 0");

        var product = await _productRepository.GetProductByIdAsync(productModel.Productid);

        if(product == null)
            return result.SetError("O produto nao existe");

        _productRepository.UpdateProduct(productModel);

        result.SetSuccess();

        return result;
    }
}
