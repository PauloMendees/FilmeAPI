using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.DTO;
using UsuariosAPI.Model;

namespace UsuariosAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<PostUsuario, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
            CreateMap<Usuario, CustomIdentityUser>();
            CreateMap<IdentityUser<int>, Usuario>();
            CreateMap<CustomIdentityUser, Usuario>();
        }
    }
}
