using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using AuthWebApi.Model;
using AuthWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using AuthWebApi.Dto;

namespace AutWebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Policy")]
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
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { success = true });
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserCreateRequest newUser)
        {
            var securityCheck = await db.Users.FirstOrDefaultAsync(x => x.Email == newUser.Email);
            if (securityCheck != null)
                return BadRequest("Girdiginiz Emaile ait bir hesap bulunmakta. Farkli bir email ile kayit olmayi deneyin");
            var user = new User();
            user.Email = newUser.Email;
            user.Password = newUser.Password;
            user.Username = newUser.Username;
            user.Name = newUser.Name;
            user.Surname = newUser.Surname;
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(new { succes = true, message = "Kullanıcı başarıyla oluşturuldu" });
        }
        [HttpPut("update")]
        public async Task<IActionResult> ChangePassword([FromBody] UpdateUserRequest newPassword)
        {
            var securityCheck = await db.Users.FirstOrDefaultAsync(x => x.Email == newPassword.Email);
            if (securityCheck == null)
                return BadRequest(new { succes = false, message = "Girdiginiz Emaile ait bir hesap bulunamadi" });
            if (securityCheck.Password != newPassword.OldPassword)
                return BadRequest(new { succes = false, message = "Girdiginiz sifre Hatali" });
            securityCheck.Password = newPassword.NewPassword;
            await db.SaveChangesAsync();
            return Ok(new { succes = true, message = "Sifre başarıyla degistirildi" });
        }
    }
}