using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Login
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
