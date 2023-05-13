using Microsoft.EntityFrameworkCore;
using Test.Server.Data;
using Test.Shared;

namespace Test.Server.Services
{
    public class ProductsService: IProductsService
    {
        private readonly DataContext _context;

        public ProductsService(DataContext context)
        {
            _context=context;
        }

        public List<Product> Products { get; set; }
        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            var dbProduct = await _context.Products.FindAsync(id);
            return dbProduct;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var dbProduct = await _context.Products.FindAsync(id);

            if (dbProduct != null)
            {
                dbProduct.Name = product.Name;
                dbProduct.Price = product.Price;
                dbProduct.Description = product.Description;

                await _context.SaveChangesAsync();

                return dbProduct;
            }
            throw new ArgumentException("Invalid product id.");
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var dbProduct = await _context.Products.FindAsync(id);

            if (dbProduct != null)
            {
                _context.Products.Remove(dbProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
