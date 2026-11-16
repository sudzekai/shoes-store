using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using StoreData.Data;
using StoreData.Services;

namespace StoreWeb
{
    public class Program
    {
        /// <summary>Настраивает и запускает сайт.</summary>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("ShoesStore")
                ?? throw new InvalidOperationException("Укажите подключение к базе.");

            builder.Services.AddDbContext<ShoesStoreContext>(options => options.UseSqlServer(connection));
            builder.Services.AddSingleton(TimeProvider.System);
            builder.Services.AddTransient<CatalogService>();
            builder.Services.AddTransient<AccountService>();
            builder.Services.AddTransient<OrderService>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.LoginPath = "/account/login");

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
