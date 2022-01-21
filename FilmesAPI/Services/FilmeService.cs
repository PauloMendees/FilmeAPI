using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;
using FilmesAPI.Models.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        //Instanciando nosso contexto
        private AppDbContext _context;

        //Instanciando nosso mapper  -->  usa de base nossos profiles
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetByIdFilmeDTO PostFilme(PostFilmeDTO filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<GetByIdFilmeDTO>(filme);
        }

        public GetByIdFilmeDTO RecuperarFilmePorIdService(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return null;
            }
            //Convertendo nosso filme para um filmeDTO
            GetByIdFilmeDTO filmeDTO = _mapper.Map<GetByIdFilmeDTO>(filme);
            return filmeDTO;
        }

        public List<Filme> GetAll()
        {
            return _context.Filmes.ToList();
        }

        public Result AlterarFilmePorID(int id, PutFilmeDTO filmeAlteradoDTO)
        {
           Filme filme = _context.Filmes.FirstOrDefault(item => item.Id == id);
            if(filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _mapper.Map(filmeAlteradoDTO, filme);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleterFilmePorID(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(item => item.Id == id);
            if(filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
