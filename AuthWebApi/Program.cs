using AuthWebApi.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AutWebApiExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "auth";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);//Sistemde kaç dakika kalacak
                options.LoginPath = "/api/login";//sistem hangi sayfa üzerinden giriş yapacak
                options.AccessDeniedPath = "/api/acces-denied";//yetkisiz giriş sayfası yönlendirmesi
            });

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(build =>
    {
        build.WithOrigins("*")
.AllowAnyMethod()
.AllowAnyHeader()
.AllowCredentials();
    });
            });
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string is not found");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();//Kullanıcı girişine izin verme
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}