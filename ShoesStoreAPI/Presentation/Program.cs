using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Presentation.Services;
using StoreData.Data;
using StoreData.Services;

namespace Presentation
{
    public class Program
    {
        /// <summary>Настраивает и запускает API.</summary>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("ShoesStore")
                ?? throw new InvalidOperationException("Укажите подключение к базе.");
            var secret = builder.Configuration["Jwt:Key"];
            if (secret is null || Encoding.UTF8.GetByteCount(secret) < 32)
                throw new InvalidOperationException("Укажите ключ входа длиной от 32 байт.");

            var settings = new JwtSettings(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)));
            builder.Services.AddSingleton(settings);
            builder.Services.AddSingleton(TimeProvider.System);
            builder.Services.AddSingleton<JwtSecurityTokenHandler>();
            builder.Services.AddSingleton<TokenService>();
            builder.Services.AddDbContext<ShoesStoreContext>(options => options.UseSqlServer(connection));
            builder.Services.AddTransient<AccountService>();
            builder.Services.AddTransient<CatalogService>();
            builder.Services.AddTransient<OrderService>();
            builder.Services.AddTransient<ProductEditor>();
            builder.Services.AddControllers();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.MapInboundClaims = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = settings.Issuer,
                        ValidAudience = settings.Audience,
                        IssuerSigningKey = settings.Key,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };
                });

            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
