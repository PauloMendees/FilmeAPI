using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosAPI.Data.Login;
using UsuariosAPI.Model;

namespace UsuariosAPI.Services
{
    public class LoginService
    {
        //Service para geração de token
        private TokenService _tokenService;
        //Lib para controle de login
        private SignInManager<CustomIdentityUser> _manager;

        public LoginService(SignInManager<CustomIdentityUser> manager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _manager = manager;
        }

        public Result LogarUsuarioService(LoginRequest user)
        {
            //Realizando o login
            var resultadoLogin = _manager.PasswordSignInAsync(user.UserName, user.Password, false, false).Result;
            if (resultadoLogin.Succeeded)
            {
                //Gerando o token já incluindo roles
                CustomIdentityUser identityUser = _manager.UserManager.Users.FirstOrDefault(usuario => usuario.NormalizedUserName == user.UserName.ToUpper());
                Token token = _tokenService.CreateToken(identityUser, _manager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login não pode ser executado");
        }

        public Result RedefinirSenhaService(RedefinirSenhaRequest request)
        {
            CustomIdentityUser usuario = _manager.UserManager.Users.FirstOrDefault(user => user.NormalizedEmail == request.Email.ToUpper());
            if(usuario != null)
            {
                string codeRecuperacao = _manager.UserManager.GeneratePasswordResetTokenAsync(usuario).Result;
                return Result.Ok().WithSuccess(codeRecuperacao);
            }
            return Result.Fail("Falha ao solicitar redefinição de senha");
        }

        public Result EfetuarMudancaDeSenhaService(MudarSenha request)
        {
            CustomIdentityUser usuario = _manager.UserManager.Users.FirstOrDefault(user => user.NormalizedEmail == request.Email.ToUpper());
            IdentityResult result = _manager.UserManager.ResetPasswordAsync(usuario, request.Token, request.Password).Result;
            if (result.Succeeded) return Result.Ok();
            return Result.Fail("Houve algum erro");
        }
    }
}
