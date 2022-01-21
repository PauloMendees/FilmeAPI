using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Login
{
    public class MudarSenha
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Senhas não equivalem")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }

    }
}
