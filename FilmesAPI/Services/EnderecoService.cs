using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        AppDbContext _context;
        IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Endereco> ListarEnderecosService()
        {
            return _context.Enderecos.ToList();
        }

        public ReadEnderecoDTO AdicionarEnderecoService(EnderecoDTO enderecoDTO)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);
            _context.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDTO>(endereco);
        }

        public ReadEnderecoDTO VisualizarEnderecoByIdService(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(item => item.Id == id);
            if(endereco == null)
            {
                return null;
            }
            return _mapper.Map<ReadEnderecoDTO>(endereco);
        }

        public Result AlterarEnderecoService(int id, EnderecoDTO enderecoDTO)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(item => item.Id == id);
            if(endereco == null)
            {
                return Result.Fail("Endereço não encontrado");
            }
            _mapper.Map(enderecoDTO, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarUsuarioService(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(item => item.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereço não encontrado");
            }
            _context.Remove(endereco);
            return Result.Ok();
        }
    }
}
