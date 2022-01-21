using System;

namespace FilmesAPI.Data.Dtos.Sessao
{
    public class PostSessaoDTO
    {
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime EncerramentoSessao { get; set; }
    }
}
