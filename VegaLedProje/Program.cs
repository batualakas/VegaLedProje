using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VegaLedProje.Business.Managers;
using VegaLedProje.Business.Services;
using VegaLedProje.Data.Context;
using VegaLedProje.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VegaLedProjeContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IOurServicesService, OurServicesManager>();

builder.Services.AddDataProtection();

// Configure the HTTP request pipeline.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.LogoutPath = new PathString("/");
    options.AccessDeniedPath = new PathString("/");
});
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{Controller=Dashboard}/{Action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: ("{Controller=Home}/{Action=Index}/{id?}")
    );



app.Run();

