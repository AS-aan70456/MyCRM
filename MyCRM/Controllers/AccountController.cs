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
using Microsoft.AspNetCore.Authorization;

namespace MyCRM.Controllers
{
    // Controller for handling user authentication and registration
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // Interface for user repository
        public IAllUsers UsersRep { get; set; }

        // Constructor to inject user repository
        public AccountController(IAllUsers Users)
        {
            this.UsersRep = Users;
        }

        // Display the login form
        [HttpGet]
        public IActionResult Login() => View(new LoginViewModel());

        // Display the registration form
        [HttpGet]
        public IActionResult Register() => View(new RegisterViewModel());

        // Handle login form submission
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Find user by username
            var user = UsersRep.GetUser().FirstOrDefault(x => x.Name == model.UserName);

            // Check if user exists and password matches
            if (user == null)
            {
                ModelState.AddModelError("UserName", "Invalid username");
                return View(model);
            }
            if (user.Password != HashPasswordHelper.HashPassword(model.password))
            {
                ModelState.AddModelError("password", "Invalid password");
                return View(model);
            }

            // Authenticate user and sign them in using a cookie-based authentication scheme
            ClaimsIdentity claims = Autheticate(user);
            await HttpContext.SignInAsync("Cookie", new ClaimsPrincipal(claims));

            return RedirectToAction("Home", "Home");
        }

        // Handle registration form submission
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Check if terms checkbox is checked
            if (model.IsCheckBox == false)
            {
                ModelState.AddModelError("IsCheckBox", "Please accept the terms.");
                return View(model);
            }

            // Check if username is already taken
            var user = UsersRep.GetUser().FirstOrDefault(i => i.Name == model.UserName);
            if (user != null)
            {
                ModelState.AddModelError("UserName", "Username already taken");
                return View(model);
            }

            // Create a new user entity with hashed password and other details
            var newUser = new User()
            {
                Name = model.UserName,
                Password = HashPasswordHelper.HashPassword(model.password),
                Email = model.Email,
                bill = 0,
                Role = Role.User
            };

            // Save the new user and authenticate them
            UsersRep.SaveUser(newUser);
            ClaimsIdentity claims = Autheticate(newUser);
            await HttpContext.SignInAsync("Cookie", new ClaimsPrincipal(claims));

            return RedirectToAction("Home", "Home");
        }

        // Logout the user
        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        // Authenticate a user by creating claims and returning a ClaimsIdentity
        private ClaimsIdentity Autheticate(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
            };
            return new ClaimsIdentity(claims, "Cookie");
        }
    }
}
