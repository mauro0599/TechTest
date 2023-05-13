using Test.Shared;

namespace Test.Server.Services
{
    public interface IProductsService
    {
        List<Product> Products { get; set; }
        Task<List<Product>> GetProducts();
        Task<Product?> GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(int id, Product product);
        Task<bool>DeleteProduct(int id);
    }
}
