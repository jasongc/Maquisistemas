using VetAdminAD.Clases;
using VetAdminAD.Interfaces;
using VetAdminEN.Conexion;
using VetAdminNE.Clases;
using VetAdminNE.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<VetAdminContext>();
builder.Services.AddTransient<IPersonaNE, PersonaNE>();
builder.Services.AddTransient<IPersonaAD, PersonaAD>();
//builder.Services.AddTransient<IPublicacionSE, PublicacionSE>();

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
