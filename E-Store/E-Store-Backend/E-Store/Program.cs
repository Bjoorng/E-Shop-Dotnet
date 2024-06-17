using E_Store.Consts;
using E_Store.Infrastructure.Data;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//var bytes = Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JwtSecret"]!);

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();
//builder.Services.AddAuthentication().AddJwtBearer(options =>
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(bytes),
//        ValidAudience = builder.Configuration["Authentication:ValidAudience"],
//        ValidIssuer = builder.Configuration["Authentication:ValidIssuer"]
//    }
//);
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
