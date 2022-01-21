using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.GerenteDTO
{
    public class PostGerenteDTO
    {
        [Required]
        public string Nome { get; set; }
    }
}
