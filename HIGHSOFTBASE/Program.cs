using HIGHSOFT.Models;
using HIGHSOFTBASE.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    // db.Database.Migrate(); // si quieres forzar migraciones en runtime
    if (!db.CategoriaServicios.Any())
    {
        db.CategoriaServicios.AddRange(
            new CategoriaServicio { Nombre = "Masajes", Descripcion = "Masajes relajantes y terapéuticos" },
            new CategoriaServicio { Nombre = "Estética", Descripcion = "Tratamientos faciales y corporales" },
            new CategoriaServicio { Nombre = "Peluquería", Descripcion = "Corte y peinado" }
        );
        db.SaveChanges();
    }
}


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
