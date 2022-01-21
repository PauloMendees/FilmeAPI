using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.GerenteDTO;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Gerente> ListarGerentesService()
        {
            return _context.Gerentes.ToList();
        }

        public ReadGerenteDTO PublicarNovoGerenteService(PostGerenteDTO gerenteDTO)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDTO);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDTO>(gerente);
        }

        public ReadGerenteDTO BuscarGerentePorIdService(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(item => item.Id == id);
            if (gerente == null)
            {
                return null;
            }
            return _mapper.Map<ReadGerenteDTO>(gerente);
        }

        public Result AlterarGerentePorIdService(int id, PostGerenteDTO gerenteDTO)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(item => item.Id == id);
            if(gerente == null)
            {
                return Result.Fail("Gerente não encontrado");
            }
            _mapper.Map(gerenteDTO, gerente);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarGerentePorIdService(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(item => item.Id == id);
            if(null == gerente)
            {
                return Result.Fail("Gerente não encontrado");
            }
            _context.Remove(gerente);
            return Result.Ok();
        }
    }
}
