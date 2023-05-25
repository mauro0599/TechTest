using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorCrud.Server.Models;
using BlazorCrud.Shared;
using Microsoft.EntityFrameworkCore;
using BlazorCrud.Server.Context;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Lista")]
        public async Task <IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<ProductoDTO>>();
            var listaProductoDTO = new List<ProductoDTO>();
            try
            {
                foreach (var item in await _context.Producto.ToListAsync())
                {
                    listaProductoDTO.Add(new ProductoDTO
                    {
                        Descripcion = item.Descripcion,
                        Foto = item.Foto,
                        IdProducto = item.IdProducto,
                        Modelo = item.Modelo,
                        Precio = item.Precio
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaProductoDTO;
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);

        }
        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task <IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<ProductoDTO>();


            try
            {
                var producto = _context.Producto.FirstOrDefault(x => x.IdProducto == id);
                ProductoDTO productoDTO = new ProductoDTO
                {
                    Descripcion = producto.Descripcion,
                    Foto = producto.Foto,
                    IdProducto = producto.IdProducto,
                    Modelo = producto.Modelo,
                    Precio = producto.Precio
                };
                if(producto != null)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = productoDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No se encontro ningun producto.";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }
        [HttpPost]
        [Route("Guardar")]

        public async Task <IActionResult> Guardar(ProductoDTO productoModel)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbProducto = new Producto
                {
                    Descripcion = productoModel.Descripcion,
                    Modelo = productoModel.Modelo,
                    Precio = productoModel.Precio,
                    Foto = productoModel.Foto,
                };
                _context.Producto.Add(dbProducto);
                await _context.SaveChangesAsync();
                if (dbProducto.IdProducto != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbProducto.IdProducto;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No guardado";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Edit(ProductoDTO productoModel, int id)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbProducto = await _context.Producto.FirstOrDefaultAsync(x => x.IdProducto == id);

                if (dbProducto.IdProducto != null)
                {
                    dbProducto.Modelo = productoModel.Modelo;
                    dbProducto.Descripcion = productoModel.Descripcion;
                    dbProducto.Precio = productoModel.Precio;
                    dbProducto.Foto = productoModel.Foto;

                    _context.Producto.Update(dbProducto);
                    await _context.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbProducto.IdProducto;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Producto no encontrado";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }
        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbProducto = await _context.Producto.FirstOrDefaultAsync(x => x.IdProducto == id);

                if (dbProducto.IdProducto != null)
                {
                    _context.Producto.Remove(dbProducto);
                    await _context.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Producto no encontrado";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}