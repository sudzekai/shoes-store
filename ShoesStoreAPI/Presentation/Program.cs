using Sudzekai.AspNetCore.Toolkit.Core;
using Sudzekai.AspNetCore.Toolkit.Core.Extensions;
using Sudzekai.AspNetCore.Toolkit.Logging.Console.Module;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var toolkit = Toolkit.Create();

            var builder = WebApplication.CreateBuilder(args);

            toolkit.Modules.AddModule<ConsoleLoggingModule>();
            var module = toolkit.Modules.GetModule<ConsoleLoggingModule>();

            module.Configure(o => o.ConfigureToolkit(t => { }) );

            module.Enable();

            toolkit.Modules.ApplyHostBuilderModules(builder);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
