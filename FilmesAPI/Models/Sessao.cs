using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
        public int CinemaId { get; set; }

        [JsonIgnore]
        public virtual Filme Filme { get; set; }
        public int FilmeId { get; set; }

        public DateTime EncerramentoSessao { get; set; } 
    }
}
