using MVCPortfolio.Models.Interfaces;
using MVCPortfolio.Models.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region Services (not needed for minimal initialization
// Add Weather Service
builder.Services.AddTransient<IWeatherService,WeatherService>();
#endregion

var app = builder.Build();

#region Not needed for minimal initialization
/*
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}*/

//app.UseHttpsRedirection();
//app.UseAuthorization();
#endregion

// include static files -> images, css,...
app.UseStaticFiles();

app.UseRouting();

// Set default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
