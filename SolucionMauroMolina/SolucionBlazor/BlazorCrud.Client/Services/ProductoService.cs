using BlazorCrud.Shared;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Services
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _http;
        public ProductoService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ProductoDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<ProductoDTO>>($"api/Producto/Buscar/{id}");
            if (result!.EsCorrecto)
            {
                return result.Valor!;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }

        public async Task<int> Editar(ProductoDTO producto)
        {
            var result = await _http.PutAsJsonAsync($"api/Producto/Editar/{producto.IdProducto}", producto);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.EsCorrecto)
            {
                return response.Valor!;
            }
            else
            {
                throw new Exception(response.Mensaje);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Producto/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.EsCorrecto)
            {
                return response.EsCorrecto!;
            }
            else
            {
                throw new Exception(response.Mensaje);
            }
        }

        public async Task<int> Guardar(ProductoDTO producto)
        {
            var result = await _http.PostAsJsonAsync($"api/Producto/Guardar", producto);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.EsCorrecto)
            {
                return response.Valor!;
            }
            else
            {
                throw new Exception(response.Mensaje);
            }
        }

        public async Task<List<ProductoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ProductoDTO>>>("api/Producto/Lista");
            if (result!.EsCorrecto)
            {
                return result.Valor!;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }
    }
}
