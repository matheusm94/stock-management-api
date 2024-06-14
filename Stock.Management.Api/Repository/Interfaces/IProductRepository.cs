using Stock.Management.Api.Models;

namespace Stock.Management.Api.Repository.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<ProductGetModel>> GetProductsAsync();
    Task<ProductGetModel> GetProductByIdAsync(int Id);
    Task CreateProductAsync(ProductModel productModel);
    //Task UpdateProduct(ProductGetModel productModel);
    public void UpdateProduct(ProductGetModel productModel);
}
