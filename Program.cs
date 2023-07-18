using alpha_api.Data;
using alpha_api.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer();

builder.Services.AddDbContext<AlphaContext>
    (options => options.UseMySQL(builder.Configuration.GetConnectionString("dbConnection")));
builder.Services.AddTransient<IEntryRepository, EntryRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// https://stackoverflow.com/questions/44249263/optional-appsettings-local-json-in-new-format-visual-studio-project
var cf = new ConfigurationBuilder();
cf.SetBasePath(app.Environment.ContentRootPath)
   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
   .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
   .AddJsonFile($"appsettings.{app.Environment.EnvironmentName}.json", optional: true)
   .AddEnvironmentVariables();
cf.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();





///////////////// https://www.c-sharpcorner.com/article/how-to-implement-jwt-authentication-in-web-api-using-net-6-0-asp-net-core/