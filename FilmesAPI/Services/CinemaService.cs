using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Models.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        AppDbContext _context;
        IMapper _mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CinemaGetIDDTO> GetAllCinemaService(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if (cinemas == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao =>
                                            sessao.Filme.Nome == nomeDoFilme)
                                            select cinema;
                cinemas = query.ToList();
            }
            List<CinemaGetIDDTO> cinemaDTO = _mapper.Map<List<CinemaGetIDDTO>>(cinemas);
            return cinemaDTO;
        }

        public CinemaGetIDDTO PublicarNovoCinemaDTO(CinemaPostDTO cinemaDTO)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
            _context.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<CinemaGetIDDTO>(cinema);
        }

        public CinemaGetIDDTO ConsultarCinemaById(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(item => item.Id == id);
            if(cinema == null)
            {
                return null;
            }
            return _mapper.Map<CinemaGetIDDTO>(cinema);
        }

        public Result AlterarCinemaService(int id, CinemaPostDTO cinemaDTO)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(item => item.Id == id);
            if(cinema == null)
            {
                return Result.Fail("Cinema não encontrado");
            }
            _mapper.Map(cinemaDTO, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarCinemaService(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(item => item.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado");
            }
            _context.Remove(cinema);
            return Result.Ok();
        }
    }
}
