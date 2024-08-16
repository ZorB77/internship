using MovieApp;
using MovieApp.Services;
using MovieApplication.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<MovieContext>();
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<StudioService>();
builder.Services.AddScoped<MovieStudioService>();

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// SWAGGER
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
