using EmpolyeeSystem.BLL.Mapping;
using EmpolyeeSystem.BLL.Services.Abstraction;
using EmpolyeeSystem.BLL.Services.Impelmentation;
using EmpolyeeSystem.DAl.DB;
using EmpolyeeSystem.DAl.Entities;
using EmpolyeeSystem.DAl.Repo.Abstraction;
using EmpolyeeSystem.DAl.Repo.Impelemntation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace EmpolyeeSystem.PLL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("name=DefaultConnection"));
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                // Identity options here
                options.SignIn.RequireConfirmedAccount = false; // Adjust as per your needs
            })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();
            // Identity
            // Authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.LoginPath = new PathString("/Account/SignUp");
                    options.AccessDeniedPath = new PathString("/Account/SignUp");
                });
            ////----
            builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
                            .AddEntityFrameworkStores<AppDbContext>()
                            .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

            //builder.Services.AddIdentity<User, IdentityRole>(options =>
            //{
            //    // Default Password settings.
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireNonAlphanumeric = true;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequiredUniqueChars = 0;
            //}).AddEntityFrameworkStores<AppDbContext>();
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

}

