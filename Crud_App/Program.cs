using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Crud_App.Data;
namespace Crud_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Crud_AppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Crud_AppContext") ?? throw new InvalidOperationException("Connection string 'Crud_AppContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}