using Microsoft.EntityFrameworkCore;
using System.Configuration;
using MovieApplicationWebAPI.Services;
using MovieApplicationWebAPI.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MyDBContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=movieapplicationwebapi;Trusted_Connection=True;"));
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<StudioService>();
builder.Services.AddScoped<DistributionService>();
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
