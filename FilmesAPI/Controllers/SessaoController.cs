using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        AppDbContext _context;
        IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("api/getAll")]
        public IEnumerable RecuperarSessoes()
        {
            return _context.Sessoes;
        }

        [HttpPost("api/post")]
        public IActionResult AdicionarSessao([FromBody] PostSessaoDTO sessaoDTO)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDTO);
            _context.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarSessaoById), new {Id = sessao.Id}, sessao);
        }

        [HttpGet("api/getById/{id}")]
        public IActionResult RecuperarSessaoById(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(item => item.Id == id);
            if(sessao == null)
            {
                return NotFound();
            }
            GetByIdSessao sessaoDTO = _mapper.Map<GetByIdSessao>(sessao);
            return Ok(sessaoDTO);
        }

        [HttpPut("api/alterar/{id}")]
        public IActionResult AlterarSessao(int id, [FromBody] PostSessaoDTO sessaoDTO)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(item => item.Id == id);
            if( sessao == null)
            {
                return NotFound();
            }
            _mapper.Map(sessaoDTO, sessao);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("api/delete/{id}")]
        public IActionResult DeletarSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(item => item.Id == id);
            if(sessao == null)
            {
                return NotFound();
            }
            _context.Remove(sessao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
