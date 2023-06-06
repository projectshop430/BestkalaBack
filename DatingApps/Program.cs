using Data.Context;
using Microsoft.EntityFrameworkCore;
using IOCConfig.Dependencis;
using DatingApps.Services.Interface;
using DatingApps.Services.Implemention;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DatingApps.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.addapplicationservice(builder.Configuration);
DependencyContainer.callDependencyContainer(builder.Services);

builder.Services.AddCors();

builder.Services.addIdentityservice(builder.Configuration); 
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
