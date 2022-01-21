using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Model;

namespace UsuariosAPI.Services
{
    public class LogoutService
    {
        //Lib para controle de login e logout
        private SignInManager<CustomIdentityUser> _siginManager;

        public LogoutService(SignInManager<CustomIdentityUser> siginManager)
        {
            _siginManager = siginManager;
        }

        public Result DeslogarUsuarioService()
        {
            //Realizando o logout
            var result = _siginManager.SignOutAsync();
            if (result.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Logou falhou");
        }
    }
}
