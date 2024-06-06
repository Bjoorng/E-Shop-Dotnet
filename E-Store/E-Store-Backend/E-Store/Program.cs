using E_Store.Consts;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
 using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddCors(options =>
{
    var origins = builder.Configuration.GetValue<string>("Cors:WithOrigins")?.Split(";") ?? Array.Empty<string>();
    options.AddPolicy(name: Constants.MY_ALLOW_SPECIFIC_ORIGINS,
                      policy =>
                      {
                          policy.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddFastEndpoints().SwaggerDocument();
builder.Services.AddDbContext<ApplicationDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(Constants.MY_ALLOW_SPECIFIC_ORIGINS);
app.UseFastEndpoints().UseSwaggerGen();

app.MapGet("/", () => "Hello World");

app.UseAuthorization();

app.Run();
