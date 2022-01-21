using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Models.Dtos;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            //Convertendo CinemaDTO para Cinema
            CreateMap<CinemaPostDTO, Cinema>();

            //Convertendo Cinema para GetCinemaIdDTO
            CreateMap<Cinema, CinemaGetIDDTO>();
        }
    }
}
