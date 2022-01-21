using AutoMapper;
using FilmesAPI.Data.Dtos.GerenteDTO;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            //Convertendo GerenteDTO para Gerente
            CreateMap<PostGerenteDTO, Gerente>();
            CreateMap<Gerente, ReadGerenteDTO>();

        }
    }
}
