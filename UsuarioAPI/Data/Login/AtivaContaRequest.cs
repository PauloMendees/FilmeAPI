using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Login
{
    public class AtivaContaRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string CodigoDeAtivacao { get; set; }
    }
}
