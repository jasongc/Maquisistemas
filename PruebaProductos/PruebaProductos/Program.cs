using AccesoDatos.Clases;
using AccesoDatos.Interfaces;
using ApisTerceros;
using Entidades.Conexion;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using Middleware;
using Negocios.Clases;
using Negocios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddMemoryCache();
builder.Services.AddTransient<PruebaProductoContext>();
builder.Services.AddTransient<IProductoNEG, ProductoNEG>();
builder.Services.AddTransient<IProductoACD, ProductoACD>();
builder.Services.AddSingleton<IDatosCacheACD, DatosCacheACD>();
builder.Services.AddHttpClient();
builder.Services.AddTransient<IMockApiAT, MockApiAT>();
//builder.Services.AddTransient<IMemoryCache>();

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

app.UseMiddleware<TiempoRespuestaMDW>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
