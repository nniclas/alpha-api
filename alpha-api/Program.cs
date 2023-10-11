using alpha_api.Core.Visualization;
using alpha_api.Data;
using alpha_api.Models;
using alpha_api.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Identity:Audience"],
        ValidIssuer = builder.Configuration["Identity:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Identity:Key"]))
    };
});
builder.Services.AddDbContext<AlphaContext>();

builder.Services.AddTransient<IRepository<Entry>, EntryRepository>();
builder.Services.AddTransient<IRepository<Unit>, UnitRepository>();
builder.Services.AddTransient<IRepository<Stat>, StatRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IEntryService, EntryService>();
builder.Services.AddTransient<IUnitService, UnitService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IStatService, StatService>();

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();





///////////////// https://www.c-sharpcorner.com/article/how-to-implement-jwt-authentication-in-web-api-using-net-6-0-asp-net-core/