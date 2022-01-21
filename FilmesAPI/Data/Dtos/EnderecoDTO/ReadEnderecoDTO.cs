using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Data.Dtos
{
    public class ReadEnderecoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numero é obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Logradouro é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro { get; set; }

        [JsonIgnore] //Evita ciclos
        public virtual Cinema Cinema { get; set; }
    }
}
