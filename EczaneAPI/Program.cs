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


// Logger Servisleri
builder.Services.AddLogging();
builder.Logging.AddConsole();

// Kullanici Servisleri
builder.Services.AddScoped<IIlacRepository, IlacRepository>();


// Veri Tabani Eklemesi
builder.Services.AddDbContext<EczaneContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EczaneConnection") ?? "" ));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
