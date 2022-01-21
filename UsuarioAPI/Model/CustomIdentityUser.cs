using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Model
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        [Required]
        public DateTime DataDeNascimento { get; set; }
    }
}
