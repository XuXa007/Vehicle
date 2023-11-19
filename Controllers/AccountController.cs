using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly DBContext _dbContext;
        private readonly ILogger<AccountController> _logger;
        
        public AccountController(DBContext dbContext, ILogger<AccountController> logger)
        
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginPost(User model)
        {
            _logger.LogInformation($"Attempting login for user: {model.Username}");
            
            if (ModelState.IsValid)
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == model.Username);

                if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        // Добавьте другие необходимые клеймы
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("MainPage", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View("Login", model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            _logger.LogInformation($"Attempting registration for user: {model.Username}");
            if (ModelState.IsValid)
            {
                // Проверьте, не существует ли пользователь с таким же именем
                if (await _dbContext.Users.AnyAsync(u => u.Username == model.Username))
                {
                    ModelState.AddModelError("Username", "This username is already taken");
                    return View(model);
                }

                // Хэшируйте пароль перед сохранением в базе данных
                model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

                // Добавьте пользователя в базу данных
                _dbContext.Users.Add(model);
                await _dbContext.SaveChangesAsync();

                // После успешной регистрации перенаправьте пользователя на страницу входа
                return RedirectToAction("Login");
            }

            // Если модель не прошла валидацию, верните пользователя на страницу регистрации
            return View("Register", model);
        }
    }
}
