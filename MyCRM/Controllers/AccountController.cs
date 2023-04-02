using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityServer4.Services;
//using MyCRM.Domain.Reposetory.interfeises;
using MyCRM.ViewModel;
//using MyCRM.Domain.Entity;
using System.Linq;
using MyCRM.Service;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MyCRM.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller {

        //private readonly UserManager<IdentityUser> userManager;
        //private readonly SignInManager<IdentityUser> signInManager;

        public AccountController() {
            
        }

        [HttpGet]
        public IActionResult Login() => View(new LoginViewModel());
        [HttpGet]
        public IActionResult Register() => View(new RegisterViewModel());

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model){
            if (!ModelState.IsValid) return View(model);

            var claims = new List<Claim>{
                new Claim("Demo","Vaule")
            };
            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);
            return Redirect("/Home/Home");
        }
        
        [HttpPost]
        public IActionResult Register(RegisterViewModel model){
            if (!ModelState.IsValid) return View(model);

            return Redirect("/Home/Home");
        }

        [ValidateAntiForgeryToken]
        public IActionResult Logout() {

            return View();
        }

    }
}
