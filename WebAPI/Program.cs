using Business.DependencyResolvers;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utils.DI;
using DataAccess.Context.EntityFramework;
using DataAccess.DependencyResolvers;
using Domain.DependencyResolvers;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
const string corsPolicyName = "AllowOrigin";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencyResolvers(
    new IDependencyInjectionModule[]
    {
        new CoreModule(),
        new DomainModule(),
        new BusinessModule(),
        new DataAccessModule()
    });

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
    .AddUserSecrets<Program>();

// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("EfDbConnectionString");

// Use the connection string to configure your database context
builder.Services.AddDbContext<EfDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 3, 0))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSeeder();
}

app.UseCors(corsPolicyName);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();