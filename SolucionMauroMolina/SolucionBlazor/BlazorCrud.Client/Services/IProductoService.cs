using BlazorCrud.Shared;

namespace BlazorCrud.Client.Services
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> Lista();
        Task<ProductoDTO> Buscar(int id);
        Task<int> Guardar(ProductoDTO empleado);
        Task<int> Editar(ProductoDTO empleado);
        Task<bool> Eliminar(int id);
    }
}
