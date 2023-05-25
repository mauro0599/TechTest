using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.Server.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string Foto { get; set; }
    }
}
