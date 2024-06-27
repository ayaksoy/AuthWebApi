using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using AuthWebApi.Model;
using AuthWebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AutWebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public AuthController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var isUser = await db.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
            if (isUser != null)
            {
                var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Email,isUser.Email),
            new Claim(ClaimTypes.Name,isUser.Name),
            new Claim(ClaimTypes.Role,"admin")
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    //role kısıtlama gösterilcek veya dışlanacak sayfa veya metodlar
                };

                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

                return Ok(new { succes = true, message = "Giriş Başarılı" });
            }
            return Unauthorized(new { succes = false, message = "Kullanıcı adı veya şifre hatalı" });
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { success = true });
        }
    }
}