using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.GerenteDTO;
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
    public class GerenteController : ControllerBase
    {
        GerenteService _servicegerente;

        public GerenteController(GerenteService service)
        {
            _servicegerente = service;
        }

        [HttpGet("api/getAll")]
        public IEnumerable ListarGerentes()
        {
            return _servicegerente.ListarGerentesService();
        }

        [HttpPost("api/postGerente")]
        public IActionResult PublicarNovoGerente([FromBody] PostGerenteDTO gerenteDTO)
        {
            ReadGerenteDTO gerDTO = _servicegerente.PublicarNovoGerenteService(gerenteDTO);
            return CreatedAtAction(nameof(BuscarGerentePorId), new { Id = gerDTO.Id }, gerDTO);
        }

        [HttpGet("api/getById/{id}")]
        public IActionResult BuscarGerentePorId(int id)
        {
            ReadGerenteDTO gerDTO = _servicegerente.BuscarGerentePorIdService(id);
            if (gerDTO == null)
            {
                return NotFound();
            }
            return Ok(gerDTO);
        }

        [HttpPut("api/AlterarGerente/{id}")]
        public IActionResult AlterarGerentePorId(int id, [FromBody] PostGerenteDTO gerenteDTO)
        {
            Result success = _servicegerente.AlterarGerentePorIdService(id, gerenteDTO);
            if(success == Result.Ok())
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("api/delete/{id}")]
        public IActionResult DeleterGerentePorId(int id)
        {
            Result success = _servicegerente.DeletarGerentePorIdService(id);
            if (success == Result.Ok()) ;
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
