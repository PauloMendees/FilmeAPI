using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UsuariosAPI.Data.DTO;
using UsuariosAPI.Data.Login;
using UsuariosAPI.Model;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    //Modelo padrão de construção de controller
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private UserService _service;

        public CadastroController(UserService service)
        {
            _service = service;
        }

        //Função post que recebe nosso DTO de POST
        [HttpPost("/api/criarUsuario")]
        public IActionResult CadastrarUsuario(PostUsuario userDTO)
        {
            //Chamando nosso service
            Result resultado = _service.CadastrarUsuarioService(userDTO);

            //Tratando respostas do service
            if (resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes);
        }

        [HttpPost("/api/ativarConta")]
        public IActionResult AtivarConta([FromQuery] AtivaContaRequest conta)
        {
            Result result = _service.AtivarContaService(conta);
            if(result.IsFailed) return StatusCode(500);
            return Ok();
        }

        [HttpGet("/api/getAll")]
        public IActionResult ListarUsuarios()
        {
            List<CustomIdentityUser> usuarios = _service.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpDelete("/api/delete/{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            Result result = _service.DeletarUsuario(id);
            if (result.IsFailed) return StatusCode(500);
            return Ok("Usuário deletado com sucesso");
        }
    }
}
