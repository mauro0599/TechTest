using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Shared;
namespace Test.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto login)
        {
            SesionDTO sesionDTO = new SesionDTO();
            if (login.Username=="Admin" && login.Password=="Admin")
            {
                sesionDTO.Username = "Admin";
                sesionDTO.Rol = "Admin";
            }
            else
            {
                sesionDTO.Username = "Normal";
                sesionDTO.Rol = "Normal";
            }

            return StatusCode(StatusCodes.Status200OK, sesionDTO);
        }
    }
}
