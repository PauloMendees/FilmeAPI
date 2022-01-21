using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models.Dtos
{
    public class GetByIdFilmeDTO
    {
        [Key]
        [Required(ErrorMessage = "Id não está sendo passado/Gerado")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo gênero é obrigatório")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "Campo duração é requerido")]
        [Range(1, 600, ErrorMessage = "A duração não pode exceder 600")]
        public int Duracao { get; set; }
        public DateTime MomentoDaConsulta { get; set; }
    }
}
