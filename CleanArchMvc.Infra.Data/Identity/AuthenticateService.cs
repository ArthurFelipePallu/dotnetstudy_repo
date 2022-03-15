using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;

        public AuthenticateService(UserManager<ApplicationUser> usermanager,SignInManager<ApplicationUser> signinmanager)
        {
            _userManager=usermanager;
            _signinManager=signinmanager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signinManager.PasswordSignInAsync(email,password,false,lockoutOnFailure:false);
            return result.Succeeded;
        }

        public async Task LogOut()
        {
            await _signinManager.SignOutAsync();
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationuser = new ApplicationUser{UserName=email,Email=email,};
            var result = await _userManager.CreateAsync(applicationuser,password);
            if(result.Succeeded)
            {
                await _signinManager.SignInAsync(applicationuser,isPersistent:false);
            }
            return result.Succeeded;
        }
    }
}