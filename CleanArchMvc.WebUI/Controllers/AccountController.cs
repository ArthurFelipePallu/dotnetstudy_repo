using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authentication;
        public AccountController(IAuthenticate autentication)
        {
            _authentication = autentication;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result =await _authentication.Authenticate(model.Email,model.Password);
            if(result)
                return Redirect("/");
            else
            {
                ModelState.AddModelError(string.Empty,"Invalid REGISTER attempt.(password must be wrong)");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Login(string returnurl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl=returnurl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authentication.Authenticate(model.Email,model.Password);
            if(result)
            {
                if(string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction("Index","Home");
                }
                return RedirectToAction(model.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty,"Invalid login attempt.(password must be wrong)");
                return View(model);
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            return View();
        }





    }
}