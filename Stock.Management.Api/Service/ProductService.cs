using AutoMapper;
using Stock.Management.Api.Database;
using Stock.Management.Api.Database.Entities;
using Stock.Management.Api.DTOs;
using Stock.Management.Api.Repository.Interfaces;
using Stock.Management.Api.Service.Interfaces;
using Stock.Management.Api.Utils;

namespace Stock.Management.Api.Service;

public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<ServiceResult<IEnumerable<ProductGetDto>>> GetProductsAsync()
    {
        var result = new ServiceResult<IEnumerable<ProductGetDto>>();

        var products = await _productRepository.GetProductsAsync();

        return result.SetSuccess(products);
    }

    public async Task<ServiceResult<ProductGetDto>> GetProductByIdAsync(int productId)
    {
        var result = new ServiceResult<ProductGetDto>();

        var product = await _productRepository.GetProductByIdAsync(productId);

        return result.SetSuccess(product);
    }

    public async Task<ServiceResult<bool>> CreateProductAsync(ProductDto productDto)
    {
        var result = new ServiceResult<bool>();

        var product = _mapper.Map<Product>(productDto);

        await _productRepository.CreateProductAsync(product);

        await _unitOfWork.CommitAsync();

        result.SetSuccess();

        return result;
    }

    public async Task<ServiceResult<bool>> UpdateProductAsync(int productId, ProductDto productDto)
    {
        var result = new ServiceResult<bool>();

        if (productDto.Maturitydate < DateTime.Now)
            return result.SetError("Data de maturidade não pode ser menor que a data atual");

        var product = await _productRepository.GetProductByIdAsync(productId);

        if (product != null)
            await _productRepository.UpdateProduct(productDto, productId);

        await _unitOfWork.CommitAsync();

        result.SetSuccess();

        return result;
    }
}