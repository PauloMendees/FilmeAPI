using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;
using FilmesAPI.Models.Dtos;
using FilmesAPI.Profiles;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        FilmeService _filmeservice;

        //Construtor do nosso controller pegando usando nosso contexto
        public FilmesController(FilmeService filmeservice)
        {
            _filmeservice = filmeservice;
        }

        //Método GET que retorna todos os filmes inseridos
        [HttpGet("api/getAll")]
        [Authorize(Roles = "admin, regular")]
        public IEnumerable<Filme> GetAll()
        {
            return _filmeservice.GetAll();
        }

        //Método post que adiciona filme na lista retornada pelos métodos GET
        [HttpPost("api/post")]
        [Authorize(Roles = "admin")] //Informando que para realizar essa ação é necessáro conter a Role de Admin
        public IActionResult PostFilme([FromBody] PostFilmeDTO filmeDTO)
        {
            GetByIdFilmeDTO filme = _filmeservice.PostFilme(filmeDTO);
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id }, filme);
        }

        //Método GET que busca um filme pelo ID inserido
        [HttpGet("api/findById/{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            GetByIdFilmeDTO filmeDTO = _filmeservice.RecuperarFilmePorIdService(id);
            if(filmeDTO == null)
            {
                return NotFound();
            }
            return Ok(filmeDTO);
        }

        //Método que altera o filme correspondente ao ID passado
        [HttpPut("api/put/{id}")]
        public IActionResult AlterarFilmePorID(int id, [FromBody] PutFilmeDTO filmeAlteradoDTO)
        {
            Result success = _filmeservice.AlterarFilmePorID(id, filmeAlteradoDTO);
            if(success == Result.Ok())
            {
                return NoContent();
            }
            return NotFound();
        }

        //Método para Deletar um filme
        [HttpDelete("api/delete/{id}")]
        public IActionResult DeletarFilmePorID(int id)
        {
            Result success = _filmeservice.DeleterFilmePorID(id);
            if(success == Result.Ok())
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
