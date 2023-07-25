using alpha_api.Data;
using alpha_api.Models;
using alpha_api.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer();


// https://stackoverflow.com/questions/44249263/optional-appsettings-local-json-in-new-format-visual-studio-project
var config = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddSingleton<IConfiguration>(config);

builder.Services.AddDbContext<AlphaContext>
    (options => options.UseMySQL(config.GetConnectionString("AlphaDatabase")));
builder.Services.AddTransient<IEntryRepository, EntryRepository>();
builder.Services.AddTransient<IUnitRepository, UnitRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IEntryService, EntryService>();
builder.Services.AddTransient<IUnitService, UnitService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var corsPolicyName = "defaultName";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: corsPolicyName,
//                      policy =>
//                      {
//                          policy.WithOrigins("http://localhost:3000",
//                                             "http://www.contoso.com");
//                      });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseCors(corsPolicyName);

app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());

app.UseAuthorization();
app.MapControllers();

app.Run();





///////////////// https://www.c-sharpcorner.com/article/how-to-implement-jwt-authentication-in-web-api-using-net-6-0-asp-net-core/