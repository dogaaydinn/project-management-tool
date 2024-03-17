using DataAccess.Context.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();