using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TelefonSatis.Repository;

namespace TelefonSatis.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<TelefonSatisDB>();

            #region DB baðlantýsý
            //.Net Core her projede kullanýlacak yapý için bu sayfaya (Program.cs) tanýmlanmasýný bekler
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
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}