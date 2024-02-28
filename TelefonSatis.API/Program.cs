using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TelefonSatis.Repository;

namespace TelefonSatis.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            #region DB ba�lant�s�
            //.Net Core her projede kullan�lacak yap� i�in bu sayfaya (Program.cs) tan�mlanmas�n� bekler
            builder.Services.AddDbContext<TelefonSatisDB>(k =>
            {
                k.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(TelefonSatisDB)).GetName().Name);
                });

            });


            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}