using EczaneAPI.Interfaces;
using EczaneAPI.Models;
using EczaneAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Api Servisleri
builder.Services.AddControllers()
    .AddNewtonsoftJson(option => 
        option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhostClient", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Buraya izin vermek istediğin adresi yaz
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Logger Servisleri
builder.Services.AddLogging();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

// Kullanici Servisleri
builder.Services.AddScoped<IIlacRepository, IlacRepository>();
builder.Services.AddScoped<ISatisRepository, SatisRepository>();
builder.Services.AddScoped<ISatisIlacRepository, SatisIlacRepository>();


// Veri Tabani Eklemesi
builder.Services.AddDbContext<EczaneContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EczaneConnection") ?? "",
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("AllowLocalhostClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
