using AccesoDatos.Clases;
using AccesoDatos.Interfaces;
using Entidades.Conexion;
using Negocios.Clases;
using Negocios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<PruebaProductoContext>();
builder.Services.AddTransient<IProductoNEG, ProductoNEG>();
builder.Services.AddTransient<IProductoACD, ProductoACD>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
