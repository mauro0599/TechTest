using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Server.Services;
using Test.Shared;

namespace Test.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService=productsService;
        }
        // GET: ProductsController

        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            return await _productsService.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<Product?> GetProductById(int id)
        {
            return await _productsService.GetProductById(id);
        }

        [HttpPost]
        public async Task<Product?> CreateProduct(Product product)
        {
            return await _productsService.CreateProduct(product);
        }

        [HttpPut("{id}")]
        public async Task<Product?> UpdateProduct(int id,Product product)
        {
            return await _productsService.UpdateProduct(id, product);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteProduct(int id)
        {
            return await _productsService.DeleteProduct(id);
        }
    }
}
