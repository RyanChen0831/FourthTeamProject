using FourthTeamProject.Data;
using FourthTeamProject.Models;
using FourthTeamProject.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FourthTeamProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("PetHeavenConnection") ?? throw new InvalidOperationException("Connection string 'PetHeavenConnection' not found.");
            builder.Services.AddDbContext<PetHeavenDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<PetHeavenDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("PetHeavenConnection"));
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) //���Ҿ���
                .AddCookie(opt =>
                {
                    opt.LoginPath = "/t_Employees/EmployeeLogin";
                    
                    opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                });
            builder.Services.AddTransient<EncryptService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.MapRazorPages();

            app.Run();
        }
    }
}