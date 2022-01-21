using System;
using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.DTO
{
    public class PostUsuario
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Senhas não coincidem")]
        public string PasswordConfirmation { get; set; }

        [Required]
        public DateTime DataDeNascimento { get; set; }
    }
}
