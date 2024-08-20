using Microsoft.EntityFrameworkCore;
using System.Configuration;
using MovieApplicationWebAPI.Services;
using MovieApplicationWebAPI.DataAccess;
using MovieApplicationWebAPI.Utilities;
using MovieApplicationWebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddDebug();

builder.Services.AddControllers();
builder.Services.AddDbContext<MyDBContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=movieapplicationwebapi;Trusted_Connection=True;"));
builder.Services.AddScoped<LogWriter>();
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<StudioService>();
builder.Services.AddScoped<DistributionService>();
builder.Services.AddScoped<MyDBContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<CustomMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();