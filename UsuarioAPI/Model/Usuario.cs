using System;
using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Model
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime DataDeNascimento { get; set; }
    }
}
