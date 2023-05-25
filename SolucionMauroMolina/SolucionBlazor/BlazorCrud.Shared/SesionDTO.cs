using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCrud.Shared
{
    public class SesionDTO
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
    }
}
