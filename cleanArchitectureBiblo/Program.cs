
using Application.Data;
using Application.MapperConfig;
using Application.Repository;
using Infrastructure.Contrat;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("StringConnection");

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyContext>(c=>c.UseSqlServer(connection));
builder.Services.AddScoped(typeof(IGenerique<>),typeof(GeneriqueEmpl<>));
builder.Services.AddAutoMapper(typeof(MapperConfig));




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
