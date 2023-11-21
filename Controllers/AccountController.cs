using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using WebApplication3.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Linq;
using WebApplication3.Data;
using WebApplication3.Enum;

namespace WebApplication3.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly DBContext _dbContext;

        public AccountController(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        
        
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {            
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, "login");
                    var principal = new ClaimsPrincipal(identity);

                    // Установка аутентификационных куки
                    HttpContext.SignInAsync(principal);

                    if (user.Role == UserRole.Admin)
                    {
                        return RedirectToAction("AdminPage", "Admin");
                    }
                    else if (user.Role == UserRole.User) 
                    {
                        return RedirectToAction("UserPage", "User");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }

                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            
            if (_dbContext.Users.Any(u => u.Username == model.Username))
            {
                ModelState.AddModelError(nameof(RegisterViewModel.Username), "This username is already taken.");
                return View(model);
            }
            
            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                };

                _dbContext.Users.Add(newUser);
                _dbContext.SaveChanges();
                
                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError(string.Empty, "Invalid registration attempt.");
            return View(model);
        }
        
        [Authorize] // Атрибут Authorize требуется для доступа к методу выхода
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(); // Выход пользователя
            return RedirectToAction("Login", "Account"); // Перенаправление на страницу входа
        }
    }
}


