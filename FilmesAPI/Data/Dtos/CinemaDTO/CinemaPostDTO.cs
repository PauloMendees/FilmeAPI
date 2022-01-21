using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models.Dtos
{
    public class CinemaPostDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
