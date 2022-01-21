using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }

        //O endereco id será passado como chave estrangeira, mostrando q para criar um cinema, é necessário um endereço (id)
        public int EnderecoId { get; set; }

        [JsonIgnore]
        public virtual Gerente Gerente { get; set; }

        public int GerenteId { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }

    }
}
