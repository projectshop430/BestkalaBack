using Data.Context;
using IOC.Dependencies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Add services

builder.Services.RegisterServices();

#endregion

#region Add db context

builder.Services.AddDbContext<DatingAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatingAppConnectionString"));
});

#endregion

#region Add cors

builder.Services.AddCors();

#endregion

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

#region Use cors

app.UseCors(p=>p.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

#endregion

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
