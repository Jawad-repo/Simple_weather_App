using Minimal_Prac_1;
using System.Runtime.CompilerServices;
using MyClassLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3001", "https://localhost:3001")
             .AllowAnyHeader()
             .AllowAnyMethod();
    });
});

builder.Services.AddSingleton<WeatherForcasting>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCorsPolicy");

app.MapGet("/weatherforecast", (WeatherForcasting myClassLib) =>
{
    return myClassLib.GetWeatherData();

})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();



