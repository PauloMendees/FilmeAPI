using AutoMapper;
using FilmesAPI.Models;
using FilmesAPI.Models.Dtos;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {

            //Converte um PostFilmeDTO para filme
            CreateMap<PostFilmeDTO, Filme>();

            //Converte um Filme para um FilmeById
            CreateMap<Filme, GetByIdFilmeDTO>();

            //Converte um PutFilme para Filme
            CreateMap<PutFilmeDTO, Filme>();
        }
    }
}
