using Microsoft.EntityFrameworkCore;
using VictorRuiz_Examen.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FutbolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FutbolDBConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Jugadores}/{action=Index}/{id?}");

app.Run();
