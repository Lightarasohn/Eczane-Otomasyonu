using EczaneAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddLogging();
builder.Logging.AddConsole();

builder.Services.AddDbContext<EczaneContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EczaneConnection") ?? "" ));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
