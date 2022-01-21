using AutoMapper;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            //Convertendo SessaoDTO para Sessao
            CreateMap<PostSessaoDTO, Sessao>();
            //Calcula automaticamente o horario de inicio com base no horario de encerramento e duração do filme
            CreateMap<Sessao, GetByIdSessao>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto => dto.EncerramentoSessao.AddMinutes(dto.Filme.Duracao * (-1))));
            CreateMap<PutSessaoDTO, Sessao>();
        }
    }
}
