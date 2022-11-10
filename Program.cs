#region Not needed for minimal initialization
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using MVCPortfolio.Models.Interfaces;
using MVCPortfolio.Models.Services;
using System.Security.Claims;
using System.Net;
#endregion

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region Services (not needed for minimal initialization
// Add Weather Service
builder.Services.AddTransient<IWeatherService,WeatherService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.Events.OnRedirectToLogin = (context) => {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return Task.CompletedTask;
        };
    });
#endregion

var app = builder.Build();

app.UseRouting();

#region Not needed for minimal initialization
/*
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}*/

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapGet("/auth", async (HttpContext context) => {
    var claims = new List<Claim> {
        new Claim(ClaimTypes.Name, "Test"),
        new Claim(ClaimTypes.Role, "Administrator"),
    };

    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    await context.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

    return "Authorized";
});
app.MapGet("/logout", async (HttpContext context) => {
    await context.SignOutAsync();
    return "Logged out!";
});
#endregion

// include static files -> images, css,...
app.UseStaticFiles();

// Set default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
