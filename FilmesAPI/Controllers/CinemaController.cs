using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Models.Dtos;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaservice;
        
        public CinemaController(CinemaService cinemaservice)
        {
            _cinemaservice = cinemaservice;
        }

        [HttpGet("api/getAll")]
        public IActionResult GetAllCinema([FromQuery] string nomeDoFilme)
        {
            //Aplicando lógica que irá listar todos cinemas que possuem sessão com o filme passado na query
            List<CinemaGetIDDTO> lista = _cinemaservice.GetAllCinemaService(nomeDoFilme);
            if(lista == null)
            {
                return NotFound();
            }
            return Ok(lista);
        }

        [HttpPost("api/post")]
        public IActionResult PublicarNovoCinema([FromBody] CinemaPostDTO cinemaDTO)
        {
            CinemaGetIDDTO cineDTO = _cinemaservice.PublicarNovoCinemaDTO(cinemaDTO);
            return CreatedAtAction(nameof(ConsultarCinemaById), new { Id = cineDTO.Id }, cineDTO);

        }

        [HttpGet("api/getById/{id}")]
        public IActionResult ConsultarCinemaById(int id)
        {
            CinemaGetIDDTO cineDTO = _cinemaservice.ConsultarCinemaById(id);
            if(cineDTO == null)
            {
                return NotFound();
            }
            return Ok(cineDTO);
        }

        [HttpPut("api/alterarCinema/{id}")]
        public IActionResult AlterarCinema(int id, [FromBody] CinemaPostDTO cinemaDTO)
        {
            Result success = _cinemaservice.AlterarCinemaService(id, cinemaDTO);
            if(success == Result.Ok())
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("api/deleteCinema/{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Result success = _cinemaservice.DeletarCinemaService(id);
            if(success == Result.Ok())
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
