using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityServer4.Services;
using MyCRM.Domain.Reposetory.interfeises;
using MyCRM.ViewModel;
using MyCRM.Domain.Entity;
using System.Linq;
using MyCRM.Service;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace MyCRM.Controllers
{
    public class AccountController : Controller {

        public IAllUsers UsersRep { get; set; }

        public AccountController(IAllUsers Users) {
            this.UsersRep = Users;
        }

        [HttpGet]
        public IActionResult Login() => View(new LoginViewModel());

        [HttpGet]
        public IActionResult Register() => View(new RegisterViewModel());

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model){
            if (!ModelState.IsValid)
                return View(model);

            var user = UsersRep.GetUser().FirstOrDefault(x => x.Name == model.UserName);
            if (user == null){
                ModelState.AddModelError("UserName", "Неверний логин");
                return View(model);
            }
            if (user.Password != HashPasswordHelper.HashPassword(model.password)){
                ModelState.AddModelError("password", "Неверний пароль");
                return View(model);
            }
            ClaimsIdentity claims = Autheticate(user);

             await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims));

            return RedirectToAction("Home", "Home");
        }
        
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model){
            if (!ModelState.IsValid)
                return View(model);

            var user = UsersRep.GetUser().FirstOrDefault(i => i.Name == model.UserName);
            if (user != null) {
                ModelState.AddModelError("UserName", "Логин уже занят");
                return View(model);
            }

            var newUser = new User(){
                Name = model.UserName,
                Password = HashPasswordHelper.HashPassword(model.password),
                Email = model.Email,
                Role = Role.User
            };

            UsersRep.SaveUser(newUser);
            ClaimsIdentity claims = Autheticate(newUser);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims));

            return RedirectToAction("Home","Home");
        }

        [ValidateAntiForgeryToken]
        public IActionResult Logout() {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");

        }

        private ClaimsIdentity Autheticate(User user) {
            var claims = new List<Claim>() {
                new Claim(ClaimsIdentity.DefaultNameClaimType,user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Role.ToString())
            };

            return new ClaimsIdentity(claims,"ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        
        }

    }
}
