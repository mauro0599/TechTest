using Test.Shared;

namespace Test.Client.Services.ProductsService;

public interface IProductsService
{
    List<Product> Products { get; set; }
    Task  GetProducts();
    Task<Product?> GetProductById(int id);
    Task CreateProduct(Product product);
    Task UpdateProduct(int id,Product product);
    Task DeleteProduct(int id);
}