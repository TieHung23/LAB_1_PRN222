using EVDMS.BLL.Services.Abstractions;
using EVDMS.BLL.Services.Implementations;
using EVDMS.BLL.WrapConfiguration;
using EVDMS.DAL.Repositories.Abstractions;
using EVDMS.DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add BBL DI
builder.Services.AddDatabaseDAL(builder.Configuration);

builder.Services.AddRepositoryDAL();

builder.Services.AddServices();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/Home/AccessDenied";
    });

var passwordToHash = "12345"; // <-- Thay bằng mật khẩu bạn muốn đặt
var hashedPassword = BCrypt.Net.BCrypt.HashPassword(passwordToHash);
Console.WriteLine($"\n\n--- HASHED PASSWORD ---\n{hashedPassword}\n-----------------------\n\n");

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();



app.Run();
