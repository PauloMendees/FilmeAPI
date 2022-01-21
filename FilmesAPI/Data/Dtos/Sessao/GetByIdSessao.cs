using FilmesAPI.Models;
using System;

namespace FilmesAPI.Data.Dtos.Sessao
{
    public class GetByIdSessao
    {
        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorarioDeInicio { get; set; }
        public DateTime EncerramentoSessao { get; set; }
    }
}
