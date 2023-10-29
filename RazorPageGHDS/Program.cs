using GestorHorasDeServicios.DataAccess;
using GestorHorasDeServicios.Repository;
using GestorHorasDeServicios.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();



// Add DTO
builder.Services.AddAutoMapper(typeof(Program));
//Conexion a base de datos
builder.Services.AddDbContext<GestorDbContext>
    (options => options.UseSqlServer("name=ConnectionStrings:Connection"));
//Add registros servicios
builder.Services.AddScoped<ITrabajosRepository, TrabajosRepository>();
builder.Services.AddScoped<ITrabajosServices, TrabajosServices>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
