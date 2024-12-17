using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;
using UserApplication.Repository;
using UserApplication.Service;


var builder = WebApplication.CreateBuilder(args);


//Session
//Cookie 

builder.Services.AddControllersWithViews();

builder.Services.AddRepository(builder.Configuration);
builder.Services.AddService();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,opt =>
    {
        opt.Cookie.Name = "UserApplication";
        opt.LoginPath = "/Authentication/Login";
        opt.LogoutPath = "/Authentication/Login";
        opt.AccessDeniedPath = "/Error/AccessDenied";
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();//Kimlik Kontrolü
app.UseAuthorization();//Yetki Kontrolü

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
