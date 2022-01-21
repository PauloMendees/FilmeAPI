using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Login;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    //Modelo padrão de controller
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginservice;

        public LoginController(LoginService loginservice)
        {
            _loginservice = loginservice;
        }

        //Post que recebe nosso DTO de login
        [HttpPost("api/login")]
        public IActionResult LogarUsuario(LoginRequest user)
        {
            //Chamando o service
            Result result = _loginservice.LogarUsuarioService(user);
            if(result.IsFailed) return Unauthorized("Login ou senha inválidos");
            return Ok(result.Successes);
        }

        [HttpPost("api/solicitaRedefinicao")]
        public IActionResult RedefinirSenha(RedefinirSenhaRequest request)
        {
            Result result = _loginservice.RedefinirSenhaService(request);
            if (result.IsFailed) return Unauthorized("E-mail inválido");
            return Ok(result.Successes);
        }

        [HttpPost("api/realizaRedefinicao")]
        public IActionResult EfetuarMudancaDeSenha(MudarSenha request)
        {
            Result result = _loginservice.EfetuarMudancaDeSenhaService(request);
            if (result.IsFailed) return Unauthorized("Operação não realizada, contate o suporte");
            return Ok(result.Successes);
        }
    }
}
