using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        EnderecoService _serviceendereco;

        public EnderecoController(EnderecoService service)
        {
            _serviceendereco = service;
        }

        [HttpGet("api/getAll")]
        public IEnumerable ListarEnderecos()
        {
            return _serviceendereco.ListarEnderecosService();
        }

        [HttpPost("api/adicionarEndereco")]
        public IActionResult AdicionarEndereco([FromBody] EnderecoDTO enderecoDTO)
        {
            ReadEnderecoDTO endDTO = _serviceendereco.AdicionarEnderecoService(enderecoDTO);
            return CreatedAtAction(nameof(VisualizarEnderecoById), new { Id = endDTO.Id }, endDTO);
        }

        [HttpGet("api/getById/{id}")]
        public IActionResult VisualizarEnderecoById(int id)
        {
            ReadEnderecoDTO endDTO = _serviceendereco.VisualizarEnderecoByIdService(id);
            if (endDTO == null)
            {
                return NotFound();
            }
            return Ok(endDTO);
        }

        [HttpPut("api/alterarEndereco/{id}")]
        public IActionResult AlterarEndereco(int id, [FromBody] EnderecoDTO enderecoDTO)
        {
            Result success = _serviceendereco.AlterarEnderecoService(id, enderecoDTO);
            if(success == Result.Ok())
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("api/deleteEndereco/{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            Result success = _serviceendereco.DeletarUsuarioService(id);
            if (success == Result.Ok())
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
