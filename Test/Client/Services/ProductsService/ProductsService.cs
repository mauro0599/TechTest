using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Test.Client.Pages;
using Test.Shared;
using Product = Test.Shared.Product;

namespace Test.Client.Services.ProductsService
{
    public class ProductsService : IProductsService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public ProductsService(HttpClient http,NavigationManager navigationManager)
        {
            _http=http;
            _navigationManager=navigationManager;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public async Task GetProducts()
        {
            var result = await _http.GetFromJsonAsync<List<Product>>("api/Products");
            if (result!=null)
            {
                Products=result;
            }
        }   

        public async Task<Product?> GetProductById(int id)
        {
            var result = await _http.GetAsync($"api/Products/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Product>();
            }

            return null;
        }

        public async Task CreateProduct(Product product)
        {
            await _http.PostAsJsonAsync("api/Products", product);
             _navigationManager.NavigateTo("products");
        }

        public async Task UpdateProduct(int id, Product product)
        {
            await _http.PutAsJsonAsync($"api/Products/{id}", product);
            _navigationManager.NavigateTo("products");

        }

        public async Task DeleteProduct(int id)
        {
            await _http.DeleteAsync($"api/Products/{id}");
            _navigationManager.NavigateTo("products");
        }
    }
}
