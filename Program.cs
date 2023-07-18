using Microsoft.EntityFrameworkCore;
using MSIT147API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers

builder.Services.AddControllers().AddXmlSerializerFormatters();

builder.Services.AddDbContext<NorthwindContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnection"))
    );

//�]�wCORS Policy
builder.Services.AddCors(
   options =>
   {
       options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
   });

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

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
