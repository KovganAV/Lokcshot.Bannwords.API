using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Lokcshot.Bannwords.API.Core.Interfaces;
using Lokcshot.Bannwords.API.Core.Service;
using Lokcshot.Bannwords.Data.Repositories;
using Lokcshot.Bannwords.Data.DataBaseContext;
using Lokcshot.Bannwords.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ClientWebApi",
        policy =>
        {
            policy.WithOrigins("http://192.168.17.57:7100", "http://localhost:5290", "http://192.168.17.57:3001")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddScoped<ICountryBannedWordsService, CountryBannedWordsService>();
builder.Services.AddScoped<CountryBannedWordsRepository>();
builder.Services.AddScoped<ICountryService, CountryServise>();
builder.Services.AddScoped<BaseRepository<CountryEntity>>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseCors("ClientWebApi");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
try
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    if ((await context.Database.GetPendingMigrationsAsync()).Any())
    {
        context.Database.Migrate();
    }
    else
    {
        context.Database.EnsureCreated();
    }

}
catch (Exception ex)
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while migrating the database.");
}

app.Run();