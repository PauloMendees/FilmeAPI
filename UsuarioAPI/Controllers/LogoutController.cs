using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    //Modelo padrão de controller
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private LogoutService _service;

        public LogoutController(LogoutService service)
        {
            _service = service;
        }

        //Função post
        [HttpPost("api/logout")]
        public IActionResult DeslogarUsuario()
        {
            //Chamando nosso service
            Result resultado = _service.DeslogarUsuarioService();
            if(resultado.IsFailed) return Unauthorized();
            return Ok(resultado.Successes);
        }
    }
}
