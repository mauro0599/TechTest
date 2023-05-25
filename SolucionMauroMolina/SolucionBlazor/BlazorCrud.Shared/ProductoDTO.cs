using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrud.Shared
{
    public class ProductoDTO
    {
        [Key]
        public int IdProducto { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string Foto { get; set; }
    }
}
