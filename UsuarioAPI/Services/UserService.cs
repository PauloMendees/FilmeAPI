using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuariosAPI.Data;
using UsuariosAPI.Data.DTO;
using UsuariosAPI.Data.Login;
using UsuariosAPI.Model;

namespace UsuariosAPI.Services
{
    public class UserService
    {
        private IMapper _mapper;
        //Library que faz o controlle de usuarios
        private UserManager<CustomIdentityUser> _userManager;
        private UserDbContext _context;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public UserService(IMapper mapper, UserManager<CustomIdentityUser> userManager, UserDbContext context, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _context = context;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        //CustomIdentityUser é o tipo que deve ser salvo no banco de dados
        public Result CadastrarUsuarioService(PostUsuario userDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(userDTO);
            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager
                .CreateAsync(usuarioIdentity, userDTO.Password);
            //Adicionando a role no usuário criado
            _userManager.AddToRoleAsync(usuarioIdentity, "regular");
            if (resultadoIdentity.Result.Succeeded)
            {
                //Quando o usuario for criado, enviara um email para confirmar ele, com o codigo de ativação
                var code = _userManager
                    .GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);
                //Enviando o email
                _emailService.EnviarEmail(new[] { usuarioIdentity.Email },
                    "Link de Ativação", usuarioIdentity.Id, encodedCode);
                _context.Add(usuario);
                _context.SaveChanges();
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result DeletarUsuario(int id)
        {
            CustomIdentityUser usuario = _userManager.Users.FirstOrDefault(u => u.Id == id);
            var result = _userManager.DeleteAsync(usuario).Result;
            if (result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao deletar Usuário");
        }

        public Result AtivarContaService(AtivaContaRequest conta)
        {
            CustomIdentityUser identityUser = _userManager.Users.FirstOrDefault(user => user.Id == conta.UserId);
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, conta.CodigoDeAtivacao).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar o usuário");
        }

        public List<CustomIdentityUser> ListarUsuarios()
        {
            return _userManager.Users.ToList();
        }
    }
}
