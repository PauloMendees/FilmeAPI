using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Login
{
    public class RedefinirSenhaRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
