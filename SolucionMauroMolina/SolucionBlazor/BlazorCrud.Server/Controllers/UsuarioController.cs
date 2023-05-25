using BlazorCrud.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
          SesionDTO sesionDTO = new SesionDTO();

            if(login.correo == "admin@gmail.com" && login.clave == "admin")
            {
                sesionDTO.Nombre = "admin";
                sesionDTO.Correo =login.correo;
                sesionDTO.Rol = "Administrador";
            }
            else
            {
                sesionDTO.Nombre = "empleado";
                sesionDTO.Correo = login.correo;
                sesionDTO.Rol = "Empleado";
            }
            return StatusCode(StatusCodes.Status200OK, sesionDTO);

        }
    }
}
